using Pk3DSRNGTool.RNG;
using System.Collections.Generic;

namespace Pk3DSRNGTool.Core
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

        private static List<string> RNGStateStr = new List<string>();

        public static bool Considerdelay;
        public static int DelayTime;

        public static void CreateBuffer(int buffersize, IRNG rng)
        {
            if (rng is IRNG64)
            {
                RandList64.Clear();
                for (int i = 0; i < buffersize; i++)
                    RandList64.Add((rng as IRNG64).Nextulong());
                return;
            }
            RandList.Clear();
            RNGStateStr.Clear();
            for (int i = 0; i < buffersize; i++)
            {
                RandList.Add(rng.Nextuint());
                RNGStateStr.Add((rng as RNGState)?.CurrentState() ?? "");
            }
        }

        public static void Next(IRNG rng)
        {
            if (rng is IRNG64)
            {
                RandList64.RemoveAt(0);
                RandList64.Add((rng as IRNG64).Nextulong());
                return;
            }
            RandList.RemoveAt(0);
            RandList.Add(rng.Nextuint());
            RNGStateStr.RemoveAt(0);
            RNGStateStr.Add((rng as RNGState)?.CurrentState() ?? "");
        }

        public static Pokemon PM;
        public static byte RNGmethod;
        public static StationaryRNG sta_rng;
        public static EventRNG event_rng;
        public static WildRNG wild_rng;
        public static EggRNG egg_rng;

        public static RNGResult Generate6()
        {
            index = Considerdelay ? DelayTime : 0;
            var result = getresult6();
            (result as Result6).RandNum = RandList[0];
            (result as Result6).Status = RNGStateStr[0];
            return result;
        }

        public static RNGResult getresult6()
        {
            switch (RNGmethod)
            {
                case 00: return (sta_rng as Stationary6).Generate();
                case 01: return (event_rng as Event6).Generate();
            }
            return null;
        }

        public static RNGResult Generate7()
        {
            index = 0;
            int frameshift = getframeshift();
            var result = getresult7();
            (result as Result7).RandNum = RandList64[0];
            (result as Result7).frameshift = frameshift;
            if (SolLunaReset) modelnumber = 7;
            return result;
        }

        public static RNGResult GenerateEgg7()
        {
            index = 0;
            var result = (egg_rng as Egg7).Generate();
            (result as EggResult).RandNum = RandList[0];
            (result as EggResult).Status = RNGStateStr[0];
            (result as EggResult).FramesUsed = index;
            return result;
        }

        public static RNGResult getresult7()
        {
            switch (RNGmethod)
            {
                case 00: return (sta_rng as Stationary7).Generate();
                case 01: return (event_rng as Event7).Generate();
                case 02: return (wild_rng as Wild7).Generate();
                case 03: return (sta_rng as Stationary7).GenerateMainRNGPID(firstegg);
            }
            return null;
        }

        #region Gen7 Time keeping

        public static bool IsSolgaleo, IsLunala, SolLunaReset;
        public static byte modelnumber;
        public static int[] remain_frame;

        public static bool route17, phase;
        public static int PreHoneyCorrection;

        public static void ResetModelStatus()
        {
            remain_frame = new int[modelnumber];
            phase = false;
        }

        public static void CopyStatus(ModelStatus st)
        {
            remain_frame = (int[])st.remain_frame.Clone();
            phase = st.phase;
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
                            remain_frame[i] = (int)(getrand64 % 3) == 0 ? 36 : 30;
                        continue;
                    }
                    if ((int)(getrand64 & 0x7F) == 0)                //Not Blinking
                        remain_frame[i] = -5;
                }
                if (route17 && (phase = !phase))
                    Advance(2);
            }
        }

        //model # changes when screen turns black
        private static void SolLunaRearrange()
        {
            modelnumber = 5;//2 guys offline...
            int[] order = new[] { 0, 1, 2, 5, 6 };
            for (int i = 0; i < 5; i++)
                remain_frame[i] = remain_frame[order[i]];
        }

        private static void time_delay()
        {
            time_elapse(2); // Buttom press delay
            if (IsSolgaleo || IsLunala)
            {
                int crydelay = IsSolgaleo ? 79 : 76;
                time_elapse(DelayTime - crydelay - 19);
                if (modelnumber == 7) SolLunaRearrange();
                time_elapse(19);
                Advance(1);     //Cry Inside Time Delay
                time_elapse(crydelay);
                return;
            }
            time_elapse(DelayTime);
        }

        public static int getframeshift()
        {
            if (Considerdelay)
                time_delay();
            else
                ResetModelStatus();

            if (RNGmethod == 2) //Wild
            {
                ResetModelStatus();
                if (route17) Advance(2);
                time_elapse(1);              //Blink process also occurs when loading map
                index += PreHoneyCorrection - modelnumber;  //Pre-HoneyCorrection
                time_elapse(93);
            }
            return index;
        }

        // MainRNGEgg
        public static EggResult firstegg = new EggResult();
        #endregion
    }
}
