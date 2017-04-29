namespace pkm3dsRNG.Core
{
    public abstract class EventRNG : IPKM, IGenerator
    {
        public uint TSV { get; set; }
        public byte IVsCount { get; set; }
        public bool YourID { get; set; }
        public bool IsEgg { get; set; }
        public byte PIDType { get; set; }
        public bool AbilityLocked { get; set; }
        public bool NatureLocked { get; set; }
        public bool GenderLocked { get; set; }
        public bool OtherInfo { get; set; }
        public int TID { get; set; } = -1;
        public int SID { get; set; } = -1;
        public uint EC { get; set; }
        public uint PID { get; set; }

        public abstract RNGResult Generate();
    }
}
