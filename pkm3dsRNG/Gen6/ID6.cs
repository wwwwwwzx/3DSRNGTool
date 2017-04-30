using pkm3dsRNG.Core;

namespace pkm3dsRNG
{
    public class ID6 : IDResult
    {
        public uint RandNum;

        public ushort TID { get; set; }
        public ushort SID { get; set; }
        public ushort TSV { get; set; }

        public ID6(uint rand)
        {
            RandNum = rand;
            TID = (ushort)(RandNum & 0xFFFF);
            SID = (ushort)(RandNum >> 16);
            TSV = (ushort)((TID ^ SID) >> 4);
        }
    }
}
