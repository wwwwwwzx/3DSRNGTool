using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool.Core
{
    internal static class RNGPool
    {
        // Queue
        private static uint[] RandList;
        private static ulong[] RandList64;
        private static PRNGState[] RNGStateStr;
        private static int Tail, BufferSize, Pointer;
        private static int Head => Tail == BufferSize - 1 ? 0 : Tail + 1;
        public static uint getrand => RandList[++Pointer >= BufferSize ? Pointer = 0 : Pointer];
        public static ulong getrand64 => RandList64[++Pointer >= BufferSize ? Pointer = 0 : Pointer];
        public static uint getcurrent => RandList[Head];
        public static PRNGState getcurrentstate => RNGStateStr[Head];
        public static ulong getcurrent64 => RandList64[Head];

        public static int index
        {
            get
            {
                int i = Pointer - Tail;
                if (i < 0)
                    i += BufferSize;
                return i;
            }
            private set
            {
                Pointer = Tail + value;
                if (Pointer >= BufferSize)
                    Pointer -= BufferSize;
            }
        }
        public static void Rewind(int idx)
        {
            index = idx;
        }

        public static void Advance(int d)
        {
            Pointer += d;
            if (Pointer >= BufferSize)
                Pointer -= BufferSize;
        }

        public static void Clear()
        {
            RandList = null;
            RandList64 = null;
            RNGStateStr = null;
            tinystatus = null;
            timeline = null;
            horde = null;
            DelayType = 0;
            RNGResult.IsPokemon = true;
        }

        public static void CreateBuffer(IRNG rng, int buffersize = 5000, bool AutoCheck = true)
        {
            BufferSize = buffersize;
            Tail = buffersize - 1;
            if (AutoCheck && rng is IRNG64 rng64)
            {
                RandList64 = new ulong[buffersize];
                for (int i = 0; i < buffersize; i++)
                    RandList64[i] = rng64.Nextulong();
                return;
            }
            RandList = new uint[buffersize];
            RNGStateStr = new PRNGState[buffersize];
            for (int i = 0; i < buffersize; i++)
            {
                RNGStateStr[i] = (rng as IRNGState)?.CurrentState();
                RandList[i] = rng.Nextuint();
            }
        }

        public static void AddNext(IRNG rng, bool AutoCheck = true)
        {
            if (AutoCheck && rng is IRNG64 rng64)
            {
                RandList64[Head] = rng64.Nextulong();
                if (++Tail == BufferSize) Tail = 0;
                return;
            }
            RNGStateStr[Head] = (rng as IRNGState)?.CurrentState();
            RandList[Head] = rng.Nextuint();
            if (++Tail == BufferSize) Tail = 0;
        }

        public static bool Considerdelay;
        public static int DelayTime;

        public static Pokemon PM;
        public static bool IsMainRNGEgg;
        public static IGenerator igenerator;

        public static RNGResult Generate6()
        {
            index = Considerdelay ? DelayTime : 0;
            Advance(1);
            return igenerator.Generate();
        }

        public static RNGResult[] GenerateHorde6()
        {
            index = Considerdelay ? DelayTime : 0;
            Advance(1);
            return (igenerator as Wild6).Generate_Horde(horde);
        }

        public static RNGResult GenerateEgg6()
        {
            index = Considerdelay ? DelayTime : 0;
            Advance(1);
            if (IsMainRNGEgg) Egg6.MainRNGPID = getrand; // Previous Egg PID
            return GenerateAnEgg6(new uint[] { getrand, getrand }); // New Egg Seed
        }

        public static ResultE6 GenerateAnEgg6(uint[] key)
        {
            Egg6.ReSeed(key);
            var result = igenerator.Generate() as ResultE6;
            result.EggSeed = key[0] | ((ulong)key[1] << 32);
            return result;
        }

        public static RNGResult Generate7()
        {
            Pointer = Tail;
            Gen7Delay();
            return igenerator.Generate();
        }

        public static RNGResult GenerateEgg7()
        {
            Pointer = Tail;
            return igenerator.Generate();
        }
        #region Gen6 Tiny Timeline

        // Without timeline input
        public static bool AssumeSynced;

        public static TinyStatus tinystatus;
        public static TinyTimeline timeline;
        public static HordeResults horde;

        public static void time_elapse6(int i) => tinystatus.time_elapse(i); // Only Tiny Advance according to timeline. i.e. MT not advance
        public static void AdvanceTiny() => tinystatus.Tinyrng.Next();

        #endregion

        #region Gen7 Time keeping

        public static bool raining, phase;
        public static byte modelnumber;
        public static int[] remain_frame;

        public static byte DelayType;
        public static int PreHoneyCorrection;
        public static int HoneyDelay; // SuMo 93 / USUM 63

        public static bool ultrawild;

        public static void ResetModelStatus()
        {
            remain_frame = new int[modelnumber];
            phase = false;
        }

        public static void CopyStatus(ModelStatus st)
        {
            modelnumber = st.Modelnumber;
            remain_frame = (int[])st.remain_frame.Clone();
            phase = st.phase;
        }

        public static void time_elapse7(int n)
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
                            remain_frame[i] = getrand64 % 3 == 0 ? 36 : 30;
                        continue;
                    }
                    if ((int)(getrand64 & 0x7F) == 0)              //Not Blinking
                        remain_frame[i] = -5;
                }
                if (raining && (phase = !phase))
                    Advance(2);
            }
        }

        //model # changes
        private static void Rearrange(int[] NPC)
        {
            modelnumber = (byte)NPC.Length;
            for (int i = 0; i < modelnumber; i++)
                remain_frame[i] = remain_frame[NPC[i]];
        }

        private static void ChangeModelNumber(byte N)
        {
            if (N == modelnumber)
                return;
            modelnumber = N;
            if (N > remain_frame.Length)
            {
                int[] tmp = new int[N];
                remain_frame.CopyTo(tmp, 0);
                remain_frame = (int[])tmp.Clone();
            }
            // DO NOT reset status when inactive
        }

        // Cry advance frame inside npc blinking
        private static void Cry(int idx)
        {
            for (int i = 0; i < modelnumber; i++)
            {
                if (i == idx) // Inline delay
                    Advance(1);
                if (remain_frame[i] > 1)
                {
                    remain_frame[i]--;
                    continue;
                }
                if (remain_frame[i] < 0)
                {
                    if (++remain_frame[i] == 0)
                        remain_frame[i] = getrand64 % 3 == 0 ? 36 : 30;
                    continue;
                }
                if ((int)(getrand64 & 0x7F) == 0)
                    remain_frame[i] = -5;
            }
            if (idx >= modelnumber)
                Advance(1);
        }

        public static void NormalDelay7() => time_elapse7(DelayTime);
        public static void SplittedDelay(int totaldelay, int crydelay)
        {
            time_elapse7(totaldelay - crydelay);
            Advance(1);
            time_elapse7(crydelay);
        }

        public static void StationaryDelay7()
        {
            switch (DelayType)
            {
                case 1: // SuMo Sol/Luna
                case 2:
                    int crydelay = DelayType == 1 ? 78 : 75;
                    time_elapse7(DelayTime - crydelay - 20); // 48
                    if (modelnumber == 7) Rearrange(new[] { 0, 1, 2, 5, 6 });
                    time_elapse7(19);
                    Cry(3);
                    time_elapse7(crydelay);
                    break;
                case 3: // SuMo Exeggutor
                    time_elapse7(3);
                    ChangeModelNumber(2);
                    SplittedDelay(DelayTime - 3, DelayTime - 45);
                    break;
                case 4:
                    Advance(2); // Step
                    time_elapse7(DelayTime - 2);
                    modelnumber = 1;
                    time_elapse7(2);
                    break;
                case 5: // SuMo Starter
                    time_elapse7(DelayTime - 2);
                    remain_frame[1] = remain_frame[3] = remain_frame[4] = remain_frame[5] = 0;
                    time_elapse7(2);
                    break;

                case 09: // US Sol
                    time_elapse7(DelayTime - 77);  // 8
                    Cry(8);
                    time_elapse7(76);
                    break;
                case 10: // UM Luna
                    time_elapse7(DelayTime - 74);  // 8
                    if (modelnumber == 9) Rearrange(new[] { 0, 1, 2, 6, 7, 8 });
                    SplittedDelay(74, 73);
                    break;

                // Rebattle
                case 11: // Nihilego
                    SplittedDelay(DelayTime, 36); // 33|36
                    break;
                case 12: // US Buzzwole
                    SplittedDelay(DelayTime, 51); // 40|51
                    break;
                case 13: // UM Pheromosa
                    time_elapse7(29); // 29(2)|13|2C1|34(3)
                    ChangeModelNumber(3);
                    time_elapse7(DelayTime - 64);
                    Cry(2);
                    time_elapse7(34);
                    break;
                case 14: // Xurkitree
                    time_elapse7(11);
                    ChangeModelNumber(2);
                    SplittedDelay(DelayTime - 11, 35); // 11|23(2)|35
                    break;
                case 15: // UM Celesteela
                    SplittedDelay(DelayTime, 50); // 45|50
                    break;
                case 16: // US Kartana
                    SplittedDelay(DelayTime, 43); // 24|43
                    break;
                case 17: // Guzzlord
                    SplittedDelay(DelayTime, 40); // 24|40
                    break;

                // First Encounter
                case 21: // Nihilego 
                    goto case 11; // 317|36
                case 22: // Buzzwole
                    Advance(2); // Step
                    time_elapse7(DelayTime - 376); //453(2)|214(1)|111|51(2)
                    ChangeModelNumber(1);
                    time_elapse7(214);
                    ChangeModelNumber(2);
                    SplittedDelay(162, 51);
                    break;
                case 23: // Pheromosa
                    goto case 13; // 29(2)|14|34(3)
                case 24: // Xurkitree
                    time_elapse7(DelayTime - 412); // 69(?)|42(2)|93(1)|242|35(2)
                    ChangeModelNumber(2);
                    time_elapse7(42);
                    ChangeModelNumber(1);
                    time_elapse7(93);
                    ChangeModelNumber(2);
                    SplittedDelay(277, 35);
                    break;
                case 25: // Celesteela
                    time_elapse7(66); // 66(2)|34(1)|165(2)|77(1)|195|50(2)
                    ChangeModelNumber(1);
                    time_elapse7(34);
                    ChangeModelNumber(2);
                    time_elapse7(165);
                    ChangeModelNumber(1);
                    time_elapse7(77);
                    ChangeModelNumber(2);
                    SplittedDelay(DelayTime - 342, 50);
                    break;
                case 26: // Kartana
                    time_elapse7(77); // 77(2)|34(1)|91(2)|61(3)|369(2)|71(4)|65|43(2)
                    ChangeModelNumber(1);
                    time_elapse7(34);
                    ChangeModelNumber(2);
                    time_elapse7(91);
                    ChangeModelNumber(3);
                    time_elapse7(61);
                    ChangeModelNumber(2);
                    time_elapse7(369);
                    ChangeModelNumber(4);
                    remain_frame[3] = remain_frame[2]; remain_frame[2] = 0; // Swap 3 and 4
                    time_elapse7(71);
                    ChangeModelNumber(2);
                    SplittedDelay(DelayTime - 703, 43);
                    break;
                case 27: // Guzzlord
                    time_elapse7(196); // 196(2)|101(1)|149|40(2)
                    ChangeModelNumber(1);
                    time_elapse7(101);
                    ChangeModelNumber(2);
                    SplittedDelay(DelayTime - 297, 40);
                    break;
                default:
                    NormalDelay7();
                    break;
            }
        }

        public static FishingSetting fsetting;

        public static void WildDelay7()
        {
            switch (DelayType)
            {
                case 1:  // Simple encounter
                    NormalDelay7();
                    break;
                case 2:  // Fishing CFWless
                    int fishingdelay = (int)(getrand64 % 60) + fsetting.basedelay;
                    Advance(1);
                    time_elapse7(fishingdelay);
                    RNGResult.IsPokemon = fsetting.suctioncups || (int)(getrand64 % 100) < fsetting.bitechance;
                    time_elapse7(fsetting.platdelay); // 2nd Input can be at any moment inside
                    NormalDelay7();
                    break;
                case 3:
                    Advance(2); // Step
                    NormalDelay7();
                    Advance(1);
                    break;
                case 4:
                    Advance(2); // Step
                    NormalDelay7();
                    break;
                default: // Honey
                    NormalDelay7(); // Enter the bag
                    ResetModelStatus();
                    if (ultrawild) Advance(1);    // Caused by using the item?
                    if (raining) Advance(2);
                    time_elapse7(1);              // Blink process also occurs when loading map
                    Advance(PreHoneyCorrection - modelnumber);  //Pre-HoneyCorrection
                    time_elapse7(HoneyDelay);
                    break;
            }
        }

        private static void Gen7Delay()
        {
            if (Considerdelay)
                igenerator.Delay();
            else
                ResetModelStatus();
        }

        // For fishy time travel
        private static int oldtail;
        public static void Save() { oldtail = Tail; }
        public static void Load() { Tail = oldtail; }
        public static ulong getsavepoint => RandList64[oldtail == BufferSize - 1 ? 0 : oldtail + 1];

        private static int[] remain_frame_bak;
        private static bool phase_bak;
        public static void SaveStatus()
        {
            if (remain_frame_bak?.Length != modelnumber)
                remain_frame_bak = new int[modelnumber];
            remain_frame.CopyTo(remain_frame_bak, 0);
            phase_bak = phase;
            Tail = Pointer;
        }
        public static void LoadStatus()
        {
            remain_frame_bak.CopyTo(remain_frame, 0);
            phase = phase_bak;
            index = 0;
        }
        #endregion
    }
}
