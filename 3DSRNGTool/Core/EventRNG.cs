namespace Pk3DSRNGTool.Core
{
    public abstract class EventRNG : IPKM, IGenerator
    {
        public ushort TSV { get; set; }
        public byte IVsCount { get; set; }
        public bool YourID { get; set; }
        public bool IsEgg { get; set; }
        public byte PIDType { get; set; }
        public bool AbilityLocked { get; set; }
        public bool NatureLocked { get; set; }
        public bool GenderLocked { get; set; }
        public bool OtherInfo { get; set; }
        public ushort TID { get; set; }
        public ushort SID { get; set; }
        public uint EC { get; set; }
        public uint PID { get; set; }
        
        internal bool IsRandomGender;
        internal byte SettingGender;

        public abstract RNGResult Generate();
        public virtual void GetGenderSetting()
        {
            IsRandomGender = FuncUtil.IsRandomGender(info.Gender);
            SettingGender = FuncUtil.getGenderRatio(info.Gender);
        }
    }
}
