using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Event7 : EventRNG
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen7;

        public bool NoDex;
        private static ulong getrand => RNGPool.getrand64;

        public override RNGResult Generate()
        {
            Result7 rt = new Result7();
            rt.Level = Level;

            //Encryption Constant
            rt.EC = EC > 0 ? EC : (uint)getrand;

            //PID
            switch (PIDType)
            {
                case 0: //Random PID
                    rt.PID = (uint)getrand;
                    rt.Shiny = rt.PSV == TSV;
                    break;
                case 1: //Random NonShiny
                    rt.PID = (uint)getrand;
                    if (rt.PSV == TSV)
                        rt.PID ^= 0x10000000;
                    break;
                case 2: //Random Shiny
                    rt.PID = (uint)getrand;
                    rt.Shiny = true;
                    if (OtherInfo)
                        rt.PID = (uint)(((TID ^ SID ^ (rt.PID & 0xFFFF)) << 16) + (rt.PID & 0xFFFF));
                    break;
                case 3: //Specified
                    rt.PID = PID;
                    rt.Shiny = rt.PSV == TSV;
                    break;
            }

            //IV
            rt.IVs = (int[])IVs.Clone();
            for (int i = IVsCount; i > 0;)
            {
                int tmp = (int)(getrand % 6);
                if (rt.IVs[tmp] < 0)
                {
                    i--; rt.IVs[tmp] = 31;
                }
            }
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand & 0x1F);

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
