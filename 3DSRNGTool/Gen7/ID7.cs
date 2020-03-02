using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class ID7 : IDResult
    {
        public ulong RandNum { get; }

        public ushort TID { get; }
        public ushort SID { get; }
        public ushort TSV { get; }
        public byte TRV { get; }
        public uint G7TID { get; }

        public byte Clock { get; }

        public ID7(ulong rand)
        {
            RandNum = rand;
            uint tmp = (uint)RandNum;
            TID = (ushort)tmp;
            SID = (ushort)(tmp >> 16);
            TSV = (ushort)((TID ^ SID) >> 4);
            TRV = (byte)((TID ^ SID) & 0xF);
            G7TID = tmp % 1000000;
            Clock = (byte)(rand % 17);
        }
    }
}