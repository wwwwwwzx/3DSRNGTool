using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class ID7 : IDResult
    {
        public ulong RandNum { get; }

        public ushort TID { get; }
        public ushort SID { get; }
        public ushort TSV { get; }
        public uint G7TID { get; }

        public byte Clock { get; }

        public ID7(ulong rand)
        {
            RandNum = rand;
            uint tmp = (uint)(RandNum & 0xFFFFFFFF);
            TID = (ushort)(tmp & 0xFFFF);
            SID = (ushort)(tmp >> 16);
            TSV = (ushort)((TID ^ SID) >> 4);
            G7TID = tmp % 1000000;
            Clock = (byte)(rand % 17);
        }
    }
}