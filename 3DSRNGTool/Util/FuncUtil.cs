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
        private static byte[] blinkflaglist;

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
                st.Nextulong();
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
                    blink_flag = 0; st.Nextulong(); // Reset and advance
                }
                if ((int)(rand & 0x7F) == 0)
                    blink_flag = blinkflaglist[i - min] = 1;
            }
        }

        private static void MarkMultipleNPCFlag(SFMT st, int min, int max, int ModelNumber)
        {
            int Model_n = ModelNumber;
            int blink_flag = 0;
            int[] Unsaferange = new[] { 35 * (Model_n - 1), 41 * (Model_n - 1) };
            List<ulong> Randlist = new List<ulong>();
            int Min = Math.Max(min - Unsaferange[1], 418);
            for (int i = 0; i < Min; i++)
                st.Nextulong();
            for (int i = 0; i <= (Model_n - 1) * 5 + 1; i++) // Create Buffer for checkafter
                Randlist.Add(st.Nextulong());
            for (int i = Min; i <= max; i++, Randlist.RemoveAt(0), Randlist.Add(st.Nextulong()))
            {
                if ((Randlist[0] & 0x7F) == 0)
                {
                    blink_flag = Unsaferange[blink_flag == 0 ? Checkafter(Randlist) : 1];
                    if (i >= min) blinkflaglist[i - min] = (byte)(blink_flag == 0 ? 1 : 3);
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

        public static void MarkResults(Result7 result, int blinkidx = -1)
        {
            // Mark Blink
            if (0 <= blinkidx && blinkidx < blinkflaglist.Length)
                result.Blink = blinkflaglist[blinkidx];
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
        #endregion
    }
}
