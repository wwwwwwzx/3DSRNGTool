using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    internal class Frame_ID : IDResult
    {
        IDResult id;

        public Frame_ID(IDResult sc, int frame)
        {
            id = sc;
            FrameNum = frame;
        }

        public int FrameNum { get; private set; }
        public ushort TSV => id.TSV;
        public ushort TID => id.TID;
        public ushort SID => id.SID;

        // Gen6
        public uint Rand => (id as ID6)?.RandNum ?? 0;
        public PRNGState Status => (id as ID6)?.Status ?? new PRNGState(0);
        public ulong Mod100 => (Rand * (ulong)100) >> 32;

        // Gen7
        public ulong Rand64 => (id as ID7)?.RandNum ?? 0;
        public static byte correction;
        public uint G7TID => (id as ID7)?.G7TID ?? 0;
        public int Clock => correction < 0xFF ? ((id as ID7).Clock + correction) % 17 : 0;
    }
}
