namespace Gen6RNGTool.RNG
{
    public class RNGResult
    {
        public byte Nature;
        public uint PID, EC;
        public uint PSV => ((PID >> 16) ^ (PID & 0xFFFF)) >> 4;
        public uint randnum;
        public int[] IVs;
        public byte hiddenpower;
        public byte Lv;
        public byte Gender;
        public int[] Stats;
        public bool Shiny;
        public bool Synchronize;
    }
}
