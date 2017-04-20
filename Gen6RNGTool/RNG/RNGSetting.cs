using System;
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
        public static bool ShinyLocked;
        public static bool ShinyCharm;

        public static byte PokeLv;
        public static bool nogender;
        public static byte gender_ratio;

        public static MersenneTwister mtrng;
        public static List<uint> RandList;
        public static int index;
        public uint getrand => RandList[index++];

        public static void CreateBuffer(int buffersize, MersenneTwister rng)
        {
            mtrng = rng;
            RandList.Clear();
            for (int i = 0; i < buffersize; i++)
                RandList.Add(mtrng.Nextuint());
        }

        public RNGResult generate()
        {
            RNGResult rt = new RNGResult();

            return rt;
        }
        // Generated Attributes
    }
}
