namespace pkm3dsRNG.Core
{
    public class RNGResult : IPKM
    {
        public uint PID, EC;
        public uint PSV => ((PID >> 16) ^ (PID & 0xFFFF)) >> 4;
        public uint RandNum;
        public byte hiddenpower;
        public int[] Stats;
        public bool Shiny;
        public bool Synchronize;
    }
}
