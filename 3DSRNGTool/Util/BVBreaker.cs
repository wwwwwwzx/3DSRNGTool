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

        public const int pkxsize = PKX.partysize; // pk6 == pk7 in party
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
        private void checkvideo()
        {
            var l1 = video1.Length;
            gen = l1 == video2.Length ? Array.IndexOf(videosize, l1) : -1;
        }

        public PKX TryGetPKM(int slot) => getPKM(video2, slot);
        
        // Encrypted Zeroes
        private static readonly byte[] ezeros = new PKX(new Byte[pkxsize]).Encrypt;

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

        public PKX getPKM(byte[] video, int slot = 0)
        {
            int slotoff = slot * pkxsize;
            int offset = partyoffset[gen] + slotoff;
            byte[] sekx = new byte[pkxsize];
            Array.Copy(video, offset, sekx, 0, pkxsize);
            for (int i = 0; i < pkxsize; i++)
                sekx[i] ^= breakstream[i + slotoff];

            PKX pkx = new PKX(PKX.DecryptArray(sekx));

            // Corruption Check
            if (pkx.IsCorrupted)
            {
                for (int i = 0; i < pkxsize; i++)
                    pkx.Data[i] ^= ezeros[i];

                if (pkx.IsCorrupted)
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