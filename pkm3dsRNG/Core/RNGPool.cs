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
                case 00: return (sta_rng as Stationary6).Generate();
                case 01: return (event_rng as Event6).Generate();
                case 16: return (sta_rng as Stationary7).Generate();
                case 17: return (event_rng as Event7).Generate();
            }
            return null;
        }


        #region Gen7 Time keeping

        public static int PreHoneyCorrection;
        public static int delaytime = 93; //For honey 186F =3.1s
        public static byte modelnumber;
        public static int[] remain_frame;

        //public static bool route17, phase;

        private static void ResetModelStatus()
        {
            remain_frame = new int[modelnumber];
            //phase = false;
        }

        public static void time_elapse(int n)
        {
            for (int totalframe = 0; totalframe < n; totalframe++)
            {
                for (int i = 0; i < modelnumber; i++)
                {
                    if (remain_frame[i] > 1)                       //Cooldown 2nd part
                    {
                        remain_frame[i]--;
                        continue;
                    }
                    if (remain_frame[i] < 0)                       //Cooldown 1st part
                    {
                        if (++remain_frame[i] == 0)                //Blinking
                            remain_frame[i] = (int)(getrand % 3) == 0 ? 36 : 30;
                        continue;
                    }
                    if ((int)(getrand & 0x7F) == 0)                //Not Blinking
                        remain_frame[i] = -5;
                }
                //if (route17 && (phase = !phase))
                //    Advance(2);
            }
        }
            
        #endregion
    }
}
