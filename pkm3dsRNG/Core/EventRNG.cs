namespace pkm3dsRNG.Core
{
    public class EventRNG : IPKM
    {
        public uint TSV;
        public byte IVsCount;
        public bool YourID;
        public bool IsEgg;
        public byte PIDType;
        public bool AbilityLocked;
        public bool NatureLocked;
        public bool GenderLocked;
        public bool OtherInfo;
        public int TID = -1;
        public int SID = -1;
        public uint EC;
        public uint PID;

        public virtual RNGResult Generate()
        {
            return new RNGResult();
        }
    }
}
