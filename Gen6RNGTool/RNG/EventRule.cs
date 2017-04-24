namespace Gen6RNGTool.RNG
{
    public class EventRule : IPKM
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

        public static uint getrand => RNGPool.getrand;

        public RNGResult Generate()
        {
            RNGResult rt = new RNGResult();
            RNGPool.ResetIndex();
            rt.RandNum = RNGPool.CurrSeed;
            rt.Lv = Level;

            //Encryption Constant
            rt.EC = EC > 0 ? EC : getrand;

            //PID
            switch (PIDType)
            {
                case 0: //Random PID
                    rt.PID = getrand;
                    break;
                case 1: //Random NonShiny
                    rt.PID = getrand;
                    if (rt.PSV == TSV)
                        rt.PID ^= 0x10000000;
                    break;
                case 2: //Random Shiny
                    rt.PID = getrand;
                    if (OtherInfo)
                        rt.PID = (uint)(((TID ^ SID ^ (rt.PID & 0xFFFF)) << 16) + (rt.PID & 0xFFFF));
                    break;
                case 3: //Specified
                    rt.PID = PID;
                    break;
            }
            rt.Shiny = PIDType != 1 && (PIDType == 2 || rt.PSV == TSV);

            //IV
            rt.IVs = (int[])IVs.Clone();
            int cnt = IVsCount;
            while (cnt > 0)
            {
                int ran = (int)(getrand % 6);
                if (rt.IVs[ran] < 0)
                {
                    rt.IVs[ran] = 31;
                    cnt--;
                }
            }
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand >> 27);

            //Ability
            rt.Ability = AbilityLocked ? Ability : (byte)(Ability == 0 ? (getrand & 1) + 1 : getrand % 3 + 1);

            //Nature
            rt.Nature = NatureLocked ? Nature : (byte)(getrand % 25);

            //Gender
            rt.Gender = GenderLocked || !IsRandomGender ? Gender : (byte)(getrand % 252 >= SettingGender ? 1 : 2);
            return rt;
        }
    }
}
