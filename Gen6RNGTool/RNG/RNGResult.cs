namespace Gen6RNGTool.RNG
{
    public class RNGResult
    {
        public byte Nature;
        public uint PID, EC;
        public uint PSV => ((PID >> 16) ^ (PID & 0xFFFF)) >> 4;
        public ulong row_r;
        public int[] IVs;
        public byte hiddenpower;
        public byte Lv;
        public int[] Stats;
        public bool Shiny;
        public bool Synchronize;
    }
}
