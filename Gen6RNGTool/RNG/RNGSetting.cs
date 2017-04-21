using System.Collections.Generic;
using System.Linq;

namespace Gen6RNGTool.RNG
{
    class RNGSetting
    {
        // Background Info (Global variables)
        public static bool AlwaysSync;
        public static byte Synchro_Stat;
        public static bool Fix3v;
        public static int TSV;
        public static bool IsShinyLocked;
        public static bool ShinyCharm;

        public static byte PokeLv;
        public static byte Gender;
        public static bool RandomGender;
        public static byte ability;
        public static int[] IVs;

        public static MersenneTwister mtrng;
        public static List<uint> RandList = new List<uint>();
        public static int index;
        public uint getrand => RandList[index++];

        public static Pokemon PM;
        public static void UseTemplate()
        {
            if (!HasTemplate)
                return;
            AlwaysSync = PM.AlwaysSync;
            Fix3v = PM.IV3;
            IsShinyLocked = PM.ShinyLocked;
            ability = PM.Ability;
            IVs = PM.IVs;
            PokeLv = PM.Level;
            ability = PM.Ability;
            Gender = getGenderRatio(PM.GenderRatio);
            RandomGender = IsRandomGender(PM.GenderRatio);
            if (PM.Nature != Nature.Random)
            {
                Synchro_Stat = (byte)(PM.Nature);
                AlwaysSync = true;
            }
        }
        // Generated Attributes
        public static bool HasTemplate => PM != null;
        public static int PerfectIVCount => Fix3v ? 3 : 0;
        public static int PIDroll_count => ShinyCharm ? 3 : 1;

        public static void CreateBuffer(int buffersize, MersenneTwister rng)
        {
            mtrng = rng;
            RandList.Clear();
            for (int i = 0; i < buffersize; i++)
                RandList.Add(mtrng.Nextuint());
        }

        public RNGResult Generate()
        {
            RNGResult rt = new RNGResult();
            index = 0;
            rt.RandNum = RandList[0];
            rt.Lv = PokeLv;

            // Sync
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

        public static byte getGenderRatio(int gender)
        {
            switch (gender)
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

        public static bool IsRandomGender(int gender) => 10 < gender && gender < 200;
    }
}
