using System;
using System.Collections.Generic;
using System.Threading;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public static class MTSeedFinder
    {
        private static int minframe1, maxframe1, minframe2, maxframe2, poolsize1, _poolsize1, poolsize2, _poolsize2, gap;
        private static int[] IV1, IV2;
        public static List<uint> seedlist = new List<uint>();
        public static List<Thread> thrds = new List<Thread>();

        public static int PreAdvance = 63;  // Misc consumption 60 + 1 + EC + PID

        public static void Abort()
        {
            foreach (var t in thrds)
                t.Abort();
        }

        public static void setFinder(int[] iv1, int min1, int max1, int[] iv2, int min2, int max2)
        {
            IV1 = iv1; minframe1 = min1; maxframe1 = max1;
            poolsize1 = max1 - min1 + 1; _poolsize1 = poolsize1 - 5;
            IV2 = iv2; minframe2 = min2; maxframe2 = max2;
            poolsize2 = max2 - min2 + 1; _poolsize2 = poolsize2 - 5;
            gap = minframe2 - maxframe1 - 1;
            seedlist.Clear();
        }

        private static int[] FindFrame(uint seed, uint[] Pool1, uint[] Pool2)
        {
            var rng = new MersenneTwister_Fast(seed);
            int[] result = new int[2];
            int i;
            for (i = 0; i < PreAdvance; i++)
                rng.Next();
            for (i = 0; i < minframe1; i++)
                rng.Next();
            for (i = 0; i < poolsize1; i++)
                Pool1[i] = rng.Nextuint() >> 27;
            for (i = 0; i < _poolsize1; i++)
            {
                if (IV1[0] == Pool1[i] && IV1[1] == Pool1[i + 1] && IV1[2] == Pool1[i + 2]
                 && IV1[3] == Pool1[i + 3] && IV1[4] == Pool1[i + 4] && IV1[5] == Pool1[i + 5])
                    break;
            }
            result[0] = i;
            if (i == _poolsize1)
                return result;
            for (i = 0; i < gap; i++)
                rng.Next();
            for (i = 0; i < poolsize2; i++)
                Pool2[i] = rng.Nextuint() >> 27;
            for (i = 0; i < _poolsize2; i++)
            {
                if (IV2[0] == Pool2[i] && IV2[1] == Pool2[i + 1] && IV2[2] == Pool2[i + 2]
                 && IV2[3] == Pool2[i + 3] && IV2[4] == Pool2[i + 4] && IV2[5] == Pool2[i + 5])
                    break;
            }
            result[1] = i + minframe2;
            return result;
        }

        private static void parseseed(uint seed, int frame1, int frame2)
        {
            var rng = new MersenneTwister_Fast(seed);
            for (int i = 0; i < PreAdvance; i++)
                rng.Next();
            for (int i = 0; i < 7; i++)
                rng.Next();
            for (int i = 0; i < frame1; i++)
                rng.Next();
            var Nature1 = (rng.Nextuint() * 25ul) >> 32;
            for (int i = frame1 + 1; i < frame2; i++)
                rng.Next();
            var Nature2 = (rng.Nextuint() * 25ul) >> 32;
            Console.WriteLine("1st:" + frame1.ToString() + " " + StringItem.naturestr[Nature1] + " 2nd:" + frame2.ToString() + " " + StringItem.naturestr[Nature2]);
        }

        private static object _locker = 0;

        private static void findseed(uint seedmin, uint seedmax)
        {
            uint[] Pool1 = new uint[poolsize1];
            uint[] Pool2 = new uint[poolsize2];
            int[] frame;
            if (seedmax == 0xFFFFFFFF) // <= 0xFFFFFFFF always true for uint
            {
                frame = FindFrame(0xFFFFFFFF, Pool1, Pool2);
                if (frame[1] != 0 && frame[1] != _poolsize2 + minframe2)
                    lock (_locker)
                    {
                        seedlist.Add(0xFFFFFFFF);
                        parseseed(0xFFFFFFFF, frame[0], frame[1]);
                    }
                seedmax--;
            }
            for (uint i = seedmin; i <= seedmax; i++)
            {
                frame = FindFrame(i, Pool1, Pool2);
                if (frame[1] != 0 && frame[1] != _poolsize2 + minframe2)
                    lock (_locker)
                    {
                        seedlist.Add(i);
                        parseseed(i, frame[0], frame[1]);
                    }
            }
        }

        public static void FullSearch()
        {
            thrds.Clear();
            thrds.Add(new Thread(() => findseed(0x00000000, 0x1FFFFFFF)));
            thrds.Add(new Thread(() => findseed(0x20000000, 0x3FFFFFFF)));
            thrds.Add(new Thread(() => findseed(0x40000000, 0x5FFFFFFF)));
            thrds.Add(new Thread(() => findseed(0x60000000, 0x7FFFFFFF)));
            thrds.Add(new Thread(() => findseed(0x80000000, 0x9FFFFFFF)));
            thrds.Add(new Thread(() => findseed(0xA0000000, 0xBFFFFFFF)));
            thrds.Add(new Thread(() => findseed(0xC0000000, 0xDFFFFFFF)));
            thrds.Add(new Thread(() => findseed(0xE0000000, 0xFFFFFFFF)));
            foreach (var t in thrds)
                t.Start();
        }
    }
}
