using System.Collections.Generic;
using System.Linq;

namespace Gen6RNGTool.RNG
{
    class RNGSetting
    {
        // Background Info (Global variables)
        public static bool AlwaysSync;
        public static byte Synchro_Stat;
        public static bool IV3;
        public static int TSV;
        public static bool IsShinyLocked;
        public static bool ShinyCharm;

        public static byte Level;
        public static byte Gender;
        public static bool RandomGender;
        public static byte Ability;
        public static int[] IVs;
        
        public static List<uint> RandList = new List<uint>();
        private static int index;
        private static uint getrand => RandList[index++];

        public static Pokemon PM;

        // Generated Attributes
        public static bool HasTemplate => PM != null;
        public static int PerfectIVCount => IV3 ? 3 : 0;
        public static int PIDroll_count => ShinyCharm ? 3 : 1;

        public static void CreateBuffer(int buffersize, MersenneTwister rng)
        {
            RandList.Clear();
            for (int i = 0; i < buffersize; i++)
                RandList.Add(rng.Nextuint());
        }

        public RNGResult Generate()
        {
            RNGResult rt = new RNGResult();
            index = 0;
            rt.RandNum = RandList[0];
            rt.Lv = Level;

            //Sync
            if (AlwaysSync)
                rt.Synchronize = true;
            else
                rt.Synchronize = (int)(getrand % 100) >= 50;

            rt.Synchronize &= Synchro_Stat < 25;

            //Encryption Constant
            rt.EC = getrand;

            //PID
            for (int i = 0; i < PIDroll_count; i++)
            {
                rt.PID = getrand;
                if (rt.PSV == TSV)
                    break;
            }
            if (IsShinyLocked && rt.PSV == TSV)
                rt.PID ^= 0x10000000;
            rt.Shiny = rt.PSV == TSV;

            //IV
            rt.IVs = (int[])IVs?.Clone() ?? new[] { -1, -1, -1, -1, -1, -1 };
            while (rt.IVs.Count(iv => iv == 31) < PerfectIVCount)
                rt.IVs[(int)(getrand % 6)] = 31;
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand >> 27);

            //Nature
            rt.Nature = (byte)(rt.Synchronize ? Synchro_Stat : getrand % 25);

            //Gender
            rt.Gender = (byte)(RandomGender ? ((int)(getrand % 252) >= Gender ? 1 : 2) : Gender);

            return rt;
        }


        public static byte getGenderRatio(int genderratio)
        {
            switch (genderratio)
            {
                // random
                case 127: return 126;
                case 031: return 030;
                case 063: return 063;
                case 191: return 189;
                // fixed
                case 0: return 1;
                case 254: return 2;
                default: return 0;
            }
        }

        public static bool IsRandomGender(int genderratio) => 10 < genderratio && genderratio < 200;

        public static void UseTemplate()
        {
            AlwaysSync = PM.AlwaysSync;
            IV3 = PM.IV3;
            IsShinyLocked = PM.ShinyLocked;
            Ability = PM.Ability;
            IVs = PM.IVs;
            Level = PM.Level;
            Gender = getGenderRatio(PM.GenderRatio);
            RandomGender = IsRandomGender(PM.GenderRatio);
            if (PM.Nature != Nature.Random)
                Synchro_Stat = (byte)(PM.Nature);
        }
    }
}
