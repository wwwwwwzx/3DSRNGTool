using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class ID6 : IDResult
    {
        public uint RandNum { get; }
        public PRNGState Status { get; }

        public ushort TID { get; }
        public ushort SID { get; }
        public ushort TSV { get; }

        public ID6(TinyMT rng)
        {
            Status = rng.CurrentState();
            RandNum = rng.Nextuint();
            TID = (ushort)(RandNum & 0xFFFF);
            SID = (ushort)(RandNum >> 16);
            TSV = (ushort)((TID ^ SID) >> 4);
        }
    }
}
