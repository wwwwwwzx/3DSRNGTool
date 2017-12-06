using System;
using System.IO;

namespace Pk3DSRNGTool
{
    public class BVBreaker
    {
        public byte[] video1;
        public byte[] video2;
        public int gen;  // -1 for invalid input
        public byte[] breakstream = new Byte[pkxsize * 6];

        public const int pkxsize = 0x104; // pk6 == pk7 in party
        public static readonly int[] partyoffset = { 0x4E18, 0x4E41 };
        public static readonly int[] videosize = { 0x6E60, 0x6BC0 };
        public static bool checkvideosize(int size) => Array.IndexOf(videosize, size) > -1;

        public BVBreaker(string v1path, string v2path)
        {
            try
            {
                video1 = File.ReadAllBytes(v1path);
                video2 = File.ReadAllBytes(v2path);
                checkvideo();
            }
            catch { gen = -1; }
        }
        public BVBreaker(byte[] v1, byte[] v2)
        {
            video1 = (byte[])v1.Clone();
            video2 = (byte[])v2.Clone();
            checkvideo();
        }
        private void checkvideo()
        {
            var l1 = video1.Length;
            gen = Array.IndexOf(videosize, l1);
            var l2 = video2.Length;
            if (l1 != l2)
                gen = -1;
        }

        public byte[] TryGetPKM(int slot)
        {
            return getslot(video2, slot);
        }

        // get TSV from pkx bytes
        public static ushort getTSV(byte[] pkx)
        {
            ushort TID = BitConverter.ToUInt16(pkx, 0x0C);
            ushort SID = BitConverter.ToUInt16(pkx, 0x0E);
            return (ushort)((TID ^ SID) >> 4);
        }

        #region Encryption Workings (from PKX.cs of PKHeX.Core)
        // LCRNG
        private static uint LCRNG(uint seed) => seed * 0x41C64E6D + 0x00006073;
        private static uint LCRNG(ref uint seed) => seed = LCRNG(seed);

        // Checksum
        private static ushort GetCHK(byte[] data)
        {
            ushort chk = 0;
            for (int i = 8; i < 232; i += 2) // Loop through the entire PKX
                chk += BitConverter.ToUInt16(data, i);
            return chk;
        }

        // Shuffle
        private static readonly byte[][] blockPosition =
        {
            new byte[] {0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 2, 3, 1, 1, 2, 3, 2, 3, 1, 1, 2, 3, 2, 3},
            new byte[] {1, 1, 2, 3, 2, 3, 0, 0, 0, 0, 0, 0, 2, 3, 1, 1, 3, 2, 2, 3, 1, 1, 3, 2},
            new byte[] {2, 3, 1, 1, 3, 2, 2, 3, 1, 1, 3, 2, 0, 0, 0, 0, 0, 0, 3, 2, 3, 2, 1, 1},
            new byte[] {3, 2, 3, 2, 1, 1, 3, 2, 3, 2, 1, 1, 3, 2, 3, 2, 1, 1, 0, 0, 0, 0, 0, 0},
        };
        private static readonly byte[] blockPositionInvert =
        {
            0, 1, 2, 4, 3, 5, 6, 7, 12, 18, 13, 19, 8, 10, 14, 20, 16, 22, 9, 11, 15, 21, 17, 23
        };
        private static byte[] ShuffleArray(byte[] data, uint sv)
        {
            byte[] sdata = new byte[data.Length];
            Array.Copy(data, sdata, 8); // Copy unshuffled bytes

            // Shuffle Away!
            for (int block = 0; block < 4; block++)
                Array.Copy(data, 8 + 56 * blockPosition[block][sv], sdata, 8 + 56 * block, 56);

            // Fill the Battle Stats back
            if (data.Length > 232)
                Array.Copy(data, 232, sdata, 232, 28);

            return sdata;
        }

        // Encrypt/Decrypt
        public static byte[] DecryptArray(byte[] ekx)
        {
            byte[] pkx = (byte[])ekx.Clone();

            uint pv = BitConverter.ToUInt32(pkx, 0);
            uint sv = (pv >> 0xD & 0x1F) % 24;

            uint seed = pv;

            // Decrypt Blocks with RNG Seed
            for (int i = 8; i < 232; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(pkx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(pkx, i);

            // Deshuffle
            pkx = ShuffleArray(pkx, sv);

            // Decrypt the Party Stats
            seed = pv;
            if (pkx.Length <= 232) return pkx;
            for (int i = 232; i < 260; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(pkx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(pkx, i);

            return pkx;
        }
        public static byte[] EncryptArray(byte[] pkx)
        {
            // Shuffle
            uint pv = BitConverter.ToUInt32(pkx, 0);
            uint sv = (pv >> 0xD & 0x1F) % 24;

            byte[] ekx = (byte[])pkx.Clone();

            ekx = ShuffleArray(ekx, blockPositionInvert[sv]);

            uint seed = pv;

            // Encrypt Blocks with RNG Seed
            for (int i = 8; i < 232; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(ekx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(ekx, i);

            // If no party stats, return.
            if (ekx.Length <= 232) return ekx;

            // Encrypt the Party Stats
            seed = pv;
            for (int i = 232; i < 260; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(ekx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(ekx, i);

            // Done
            return ekx;
        }

        // Encrypted Zeroes
        private static byte[] ezeros = EncryptArray(new Byte[pkxsize]);
        #endregion

        public void Break()
        {
            // Copy party block
            int offset = partyoffset[gen];
            Array.Copy(video1, offset, breakstream, 0, pkxsize * 6);

            // XOR them together at party offset
            byte[] xorstream = new Byte[pkxsize * 6];
            for (int i = 0; i < pkxsize * 6; i++)
                xorstream[i] = (byte)(breakstream[i] ^ video2[i + offset]);

            // Retrieve EKX_1's data
            byte[] ekx1 = new Byte[pkxsize];
            for (int i = 0; i < pkxsize; i++)
                ekx1[i] = (byte)(xorstream[i + pkxsize] ^ ezeros[i]);

            // Rectify Keystream
            for (int i = 0; i < pkxsize; i++)
                breakstream[i] ^= ekx1[i];
            for (int i = pkxsize; i < pkxsize * 6; i++)
                breakstream[i] ^= ezeros[i % pkxsize];

            // Save for other uses
            SaveKeyStream();
        }

        private void SaveKeyStream()
        {
            try
            {
                File.WriteAllBytes("BVKey_MyTeam.bin", breakstream);
            }
            catch { }
        }

        public byte[] getslot(byte[] video, int slot = 0)
        {
            int slotoff = slot * pkxsize;
            int offset = partyoffset[gen] + slotoff;
            byte[] sekx = new byte[pkxsize];
            Array.Copy(video, offset, sekx, 0, pkxsize);
            for (int i = 0; i < pkxsize; i++)
                sekx[i] ^= breakstream[i + slotoff];

            byte[] pkx = DecryptArray(sekx);

            // Corruption Check
            uint checksum = GetCHK(pkx);
            uint actualsum = BitConverter.ToUInt16(pkx, 0x06);

            if (checksum != actualsum)
            {
                for (int i = 0; i < pkxsize; i++)
                    pkx[i] ^= ezeros[i];

                checksum = GetCHK(pkx);
                if (checksum != actualsum)
                    return null;
                else
                {
                    for (int i = 0; i < pkxsize; i++)
                        breakstream[i + slotoff] ^= ezeros[i];
                    SaveKeyStream();
                }
            }

            return pkx;
        }
    }
}