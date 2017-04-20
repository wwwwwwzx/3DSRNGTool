using System.Collections.Generic;
using System.Linq;

namespace Gen6RNGTool.RNG
{
    class RNGSetting
    {
        // Background Info (Global variables)
        public static bool AlwaysSynchro;
        public static byte Synchro_Stat;
        public static bool Fix3v;
        public static int TSV;
        public static bool IsShinyLocked;
        public static bool ShinyCharm;

        public static byte PokeLv;
        public static bool nogender;
        public static byte gender_ratio;

        public static MersenneTwister mtrng;
        public static List<uint> RandList = new List<uint>();
        public static int index;
        public uint getrand => RandList[index++];

        // Generated Info
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
            if (AlwaysSynchro)
                rt.Synchronize = true;

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
            rt.IVs = new[] { -1, -1, -1, -1, -1, -1 };
            while (rt.IVs.Count(iv => iv == 31) < PerfectIVCount)
                rt.IVs[(int)(getrand % 6)] = 31;
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand >> 27);

            //Nature
            rt.Nature = (byte)(rt.Synchronize ? Synchro_Stat : getrand % 25);

            //Gender
            rt.Gender = (byte)(nogender ? 0 : ((int)(getrand % 252) >= gender_ratio ? 1 : 2));

            return rt;
        }
        // Generated Attributes
    }
}
