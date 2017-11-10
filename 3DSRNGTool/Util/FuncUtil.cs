using System;
using System.Linq;
using System.Collections.Generic;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public static class FuncUtil
    {
        #region Genderratio
        // Translate genderratio in personal table to RNGSetting format
        public static byte getGenderRatio(int genderratio)
        {
            switch (genderratio)
            {
                // random
                case 0x1F: // 030
                case 0x3F: // 062
                case 0x7F: // 126
                case 0xBF: // 190
                case 0xE1: // 224
                    return (byte)(genderratio - 1);
                // fixed
                case 0x00: return 1;
                case 0xFE: return 2;
                default: return 0; //0xFF
            }
        }

        public static bool IsRandomGender(int genderratio) => 0x0F < genderratio && genderratio < 0xEF;
        #endregion

        #region Gen7 blink flag
        public static byte[] blinkflaglist;

        public static void getblinkflaglist(int min, int max, SFMT sfmt, int ModelNumber = 1)
        {
            blinkflaglist = new byte[max - min + 2];
            SFMT st = (SFMT)sfmt.DeepCopy();
            if (ModelNumber == 1)
                MarkNoNPCFlag(st, min, max);
            else
                MarkMultipleNPCFlag(st, min, max, ModelNumber);
        }

        private static void MarkNoNPCFlag(SFMT st, int min, int max)
        {
            int blink_flag = 0;
            ulong rand;
            for (int i = 0; i < min - 2; i++)
                st.Next();
            if ((int)(st.Nextulong() & 0x7F) == 0)
                blinkflaglist[0] = (byte)((int)(st.Nextulong() % 3) == 0 ? 36 : 30);
            else if ((int)(st.Nextulong() & 0x7F) == 0)
                blink_flag = 1;
            for (int i = min; i <= max; i++)
            {
                rand = st.Nextulong();
                if (blink_flag == 1)
                {
                    blinkflaglist[i - min] = 5;
                    blinkflaglist[++i - min] = (byte)((int)(rand % 3) == 0 ? 36 : 30);
                    blink_flag = 0; st.Next(); // Reset and advance
                }
                if ((int)(rand & 0x7F) == 0)
                    blink_flag = blinkflaglist[i - min] = 1;
            }
        }

        private static void MarkMultipleNPCFlag(SFMT st, int min, int max, int ModelNumber)
        {
            int Model_n = ModelNumber;
            int blink_flag = 0;
            int[] Unsaferange = { 35 * (Model_n - 1), 41 * (Model_n - 1) };
            List<ulong> Randlist = new List<ulong>();
            int Min = Math.Max(min - Unsaferange[1], 418);
            for (int i = 0; i < Min; i++)
                st.Next();
            for (int i = 0; i <= (Model_n - 1) * 5 + 1; i++) // Create Buffer for checkafter
                Randlist.Add(st.Nextulong());
            for (int i = Min; i <= max; i++, Randlist.RemoveAt(0), Randlist.Add(st.Nextulong()))
            {
                if ((Randlist[0] & 0x7F) == 0)
                {
                    if (i >= min) blinkflaglist[i - min] = (byte)(blink_flag == 0 ? 1 : 3);
                    blink_flag = Unsaferange[blink_flag == 0 ? Checkafter(Randlist) : 1];
                    continue;
                }
                if (blink_flag > 0)
                {
                    blink_flag--;
                    if (i >= min) blinkflaglist[i - min] = 2;
                }
            }
        }

        private static byte Checkafter(List<ulong> Randlist)
        {
            if (Randlist.Skip(1).Take(Randlist.Count - 2).Any(r => (r & 0x7F) == 0))
                return 1;
            if (Randlist.Last() % 3 == 0) return 1;
            return 0;
        }
        #endregion

        #region Misc
        public static int[] CalcFrame(uint seed, int min, int max, byte ModelNumber = 1)
        {
            if (min > max)
                return CalcFrame(seed, max, min).Select(t => -t).ToArray();

            SFMT sfmt = new SFMT(seed);

            for (int i = 0; i < min; i++)
                sfmt.Next();

            //total_frame[0] Start; total_frame[1] Duration
            int[] total_frame = new int[2];
            int n_count = 0;
            int timer = 0;
            ModelStatus status = new ModelStatus(ModelNumber, sfmt);

            while (min + n_count <= max)
            {
                n_count += status.NextState();
                total_frame[timer]++;
                if (min + n_count == max)
                    timer = 1;
            }
            return total_frame;
        }

        public static string Convert2timestr(double sec)
        {
            if (sec < 60)
                return sec.ToString("F3") + "s";
            int min = (int)Math.Floor(sec) / 60;
            sec -= 60 * min;
            if (min < 60)
                return min.ToString() + "m " + sec.ToString("00.000s");
            int hour = min / 60;
            min -= 60 * hour;
            return hour.ToString() + "h " + min.ToString("D2") + "m " + sec.ToString("00.0s");
        }

        public static int[] parseIVs(string text)
        {
            try
            {
                string[] ivstr = text.Trim().Split(',', ' ', '/', '-');
                int[] ivs = ivstr.Select(str => Convert.ToInt32(str)).ToArray();
                if (ivs.Length == 6 && ivs.All(iv => 0 <= iv && iv <= 31))
                    return ivs;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static uint[] parseNatureList(string text)
        {
            try
            {
                string[] naturestrs = text.Trim().Split(',', ' ');
                uint[] natures = naturestrs.Select(str => Convert.ToUInt32(str)).ToArray();
                if (natures.All(nature => 0 <= nature && nature <= 25))
                    return natures;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static uint[] SeedStr2Array(string seed)
        {
            try
            {
                string[] Data = seed.Split(',');
                uint[] St = new uint[4];
                St[3] = Convert.ToUInt32(Data[0], 16);
                St[2] = Convert.ToUInt32(Data[1], 16);
                St[1] = Convert.ToUInt32(Data[2], 16);
                St[0] = Convert.ToUInt32(Data[3], 16);
                return St;
            }
            catch
            {
                return null;
            }
        }

        public static byte getgen6slot(uint rand)
        {
            if (rand < 0x1999999A) //0-9
                return 1;
            if (rand < 0x33333334) //10-19
                return 2;
            if (rand < 0x4CCCCCCD) //20-29
                return 3;
            if (rand < 0x66666667) //30-39
                return 4;
            if (rand < 0x80000000) //40-49
                return 5;
            if (rand < 0x9999999A) //50-59
                return 6;
            if (rand < 0xB3333333) //60-69
                return 7;
            if (rand < 0xCCCCCCCD) //70-79
                return 8;
            if (rand < 0xE6666666) //80-99
                return 9;
            if (rand < 0xF3333333) //90-94
                return 10;
            if (rand < 0xFD70A3D7) //95-98
                return 11;
            return 12; //99
        }

        public static int getstartingframe(int gameversion, int method)
        {
            if (gameversion < 5 || method == 3) // Gen6 or egg
                return 0;
            if (gameversion < 7) // SuMo
                return method == 4 ? 1012 : 418;
            return method == 4 ? 1072 : 478; // To-Do
        }
        #endregion
    }
}