using System.Collections.Generic;

namespace Gen6RNGTool.RNG
{
    class RNGPool
    {
        private static List<uint> RandList = new List<uint>();
        private static int index;

        public static uint getrand => RandList[index++];
        public static void ResetIndex() => index = 0;
        public static uint CurrSeed => RandList[0];
        public static void Advance(int d) => index += d;

        public static void CreateBuffer(int buffersize, MersenneTwister rng)
        {
            RandList.Clear();
            for (int i = 0; i < buffersize; i++)
                RandList.Add(rng.Nextuint());
        }

        public static void Next(uint rand)
        {
            RandList.RemoveAt(0);
            RandList.Add(rand);
        }

        public static Pokemon PM;
        public static bool HasTemplate => !PM.Conceptual;
        public static RNGSetting rngsetting;
        public static EventRule e;

        public static RNGResult Generate()
        {
            return e == null ? rngsetting.Generate() : e.Generate();
        }
    }
}
