using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Event6 : EventRNG
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen6;

        private static uint getrand => RNGPool.getrand;
        private static uint rand(int n) => (uint)(getrand * (ulong)n >> 32);
        private static void Advance(int n) => RNGPool.Advance(n);

        public bool IsORAS;

        public override RNGResult Generate()
        {
            if (IsORAS) Generate_Once();
            return Generate_Once();
        }

        private RNGResult Generate_Once()
        {
            Result6 rt = new Result6();
            rt.Level = Level;

            //Encryption Constant
            rt.EC = EC > 0 ? EC : getrand;

            //PID
            switch (PIDType)
            {
                case 0: //Random PID
                    rt.PID = getrand;
                    rt.Shiny = rt.PSV == TSV;
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
                    rt.Shiny = true;
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
                uint tmp = rand(6);
                if (rt.IVs[tmp] < 0)
                {
                    i--; rt.IVs[tmp] = 31;
                }
            }
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand >> 27);

            //Ability
            rt.Ability = AbilityLocked ? Ability : (byte)(rand(Ability + 2) + 1);

            //Nature
            rt.Nature = NatureLocked ? Nature : (byte)rand(25);

            //Gender
            rt.Gender = GenderLocked || !IsRandomGender ? Gender : (byte)(rand(252) >= SettingGender ? 1 : 2);

            //Advance
            rt.FrameUsed = (byte)RNGPool.index;

            return rt;
        }
    }
}
