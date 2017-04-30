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

        public byte GenderRatio => (byte)(Gender > 0 ? 2 - 2 * Gender : info.Gender); // 1/2 => 0/254
        public bool IsRandomGender => FuncUtil.IsRandomGender(GenderRatio);
        public byte SettingGender => FuncUtil.getGenderRatio(GenderRatio);

        public abstract RNGResult Generate();
    }
}
