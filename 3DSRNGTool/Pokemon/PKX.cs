using System;

namespace Pk3DSRNGTool
{
    public class PKX
    {
        public byte[] Data;
        public const int partysize = 0x104;
        public const int storedsize = 0xE8;

        public PKX(byte[] pkx)
        {
            Data = (byte[])pkx.Clone();
        }

        public byte[] Encrypt => EncryptArray(Data);
        public ushort CheckSum => BitConverter.ToUInt16(Data, 0x6);
        public int species => BitConverter.ToUInt16(Data, 0x8);
        public ushort TID => BitConverter.ToUInt16(Data, 0xC);
        public ushort SID => BitConverter.ToUInt16(Data, 0xE);
        public ushort TSV => (ushort)((TID ^ SID) >> 4);
        public byte TRV => (byte)((TID ^ SID) & 0xF);
        public bool IsCorrupted
        {
            get
            {
                ushort chk = 0;
                for (int i = 8; i < storedsize; i += 2) // Loop through the entire PKX
                    chk += BitConverter.ToUInt16(Data, i);
                return CheckSum != chk;
            }
        }

        #region Encryption
        // LCRNG
        private static uint LCRNG(uint seed) => seed * 0x41C64E6D + 0x00006073;
        private static uint LCRNG(ref uint seed) => seed = LCRNG(seed);

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
            if (data.Length > storedsize)
                Array.Copy(data, storedsize, sdata, storedsize, 28);

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
            for (int i = 8; i < storedsize; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(pkx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(pkx, i);

            // Deshuffle
            pkx = ShuffleArray(pkx, sv);

            // Decrypt the Party Stats
            seed = pv;
            if (pkx.Length <= storedsize) return pkx;
            for (int i = storedsize; i < partysize; i += 2)
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
            for (int i = 8; i < storedsize; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(ekx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(ekx, i);

            // If no party stats, return.
            if (ekx.Length <= storedsize) return ekx;

            // Encrypt the Party Stats
            seed = pv;
            for (int i = storedsize; i < partysize; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(ekx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(ekx, i);

            // Done
            return ekx;
        }
        #endregion
    }
}
