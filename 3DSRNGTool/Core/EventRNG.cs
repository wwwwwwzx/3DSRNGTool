namespace Pk3DSRNGTool.Core
{
    public abstract class EventRNG : IPKM, IGenerator
    {
        public ushort TSV;
        public byte IVsCount;
        public bool YourID;
        public bool IsEgg;
        public byte PIDType;
        public bool AbilityLocked;
        public bool NatureLocked;
        public bool GenderLocked;
        public bool OtherInfo;
        public ushort TID;
        public ushort SID;
        public uint EC;
        public uint PID;
        
        protected bool IsRandomGender;
        protected byte SettingGender;

        public abstract RNGResult Generate();
        public virtual void GetGenderSetting()
        {
            IsRandomGender = FuncUtil.IsRandomGender(info.Gender);
            SettingGender = FuncUtil.getGenderRatio(info.Gender);
        }
    }
}
