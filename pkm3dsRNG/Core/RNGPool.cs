using pkm3dsRNG.RNG;
using System.Collections.Generic;

namespace pkm3dsRNG.Core
{
    class RNGPool
    {
        private static int index;
        public static void ResetIndex() => index = 0;
        public static void Advance(int d) => index += d;

        private static List<uint> RandList = new List<uint>();
        private static List<ulong> RandList64 = new List<ulong>();
        public static uint getrand => RandList[index++];
        public static ulong getrand64 => RandList64[index++];

        public static void CreateBuffer(int buffersize, IRNG rng)
        {
            RandList.Clear();
            for (int i = 0; i < buffersize; i++)
                RandList.Add(rng.Nextuint());
        }

        public static void CreateBuffer(int buffersize, IRNG64 rng)
        {
            RandList64.Clear();
            for (int i = 0; i < buffersize; i++)
                RandList64.Add(rng.Nextulong());
        }

        public static void Next(uint rand)
        {
            RandList.RemoveAt(0);
            RandList.Add(rand);
        }

        public static void Next(ulong rand)
        {
            RandList64.RemoveAt(0);
            RandList64.Add(rand);
        }

        public static Pokemon PM;
        public static byte RNGMethod;
        public static StationaryRNG sta_rng;
        public static EventRNG event_rng;

        public static RNGResult Generate()
        {
            index = 0;
            var result = getresult();
            result.RandNum = RandList[0];
            return result;
        }

        public static RNGResult getresult()
        {
            switch (RNGMethod)
            {
                case 0: return sta_rng.Generate();
                case 1: return event_rng.Generate();
            }
            return null;
        }
    }
}
