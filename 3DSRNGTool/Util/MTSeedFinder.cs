using System;
using System.Collections.Generic;
using System.Threading;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class MTSeedFinder
    {
        private int minframe1, maxframe1, minframe2, maxframe2, poolsize1, _poolsize1, poolsize2, _poolsize2, gap;
        private int[] IV1, IV2;

        public int Cnt, Max; // Progress
        public List<Frame_Seed> seedlist = new List<Frame_Seed>();
        public List<Thread> thrds = new List<Thread>();

        public int PreAdvance = 63;  // Misc consumption 60 + 1 + EC + PID

        public event EventHandler Update;
        private void UpdateProgress(EventArgs e)
        {
            Update?.Invoke(this, e);
        }

        public void Abort()
        {
            if (thrds.Count == 0)
                return;
            foreach (var t in thrds)
                if (t.IsAlive)
                    t.Abort();
        }

        public void Clear()
        {
            seedlist.Clear();
            seedlist = new List<Frame_Seed>();
            thrds.Clear();
            Cnt = 0;
        }

        public void setFinder(int[] iv1, int min1, int max1, int[] iv2, int min2, int max2)
        {
            IV1 = iv1; minframe1 = min1; maxframe1 = max1;
            poolsize1 = max1 - min1 + 1; _poolsize1 = poolsize1 - 5;
            IV2 = iv2; minframe2 = min2; maxframe2 = max2;
            poolsize2 = max2 - min2 + 1; _poolsize2 = poolsize2 - 5;
            gap = minframe2 - maxframe1 - 1;
        }

        private int[] FindFrame(uint seed, uint[] Pool1, uint[] Pool2)
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
            if (i == _poolsize1)
                return result;
            result[0] = i + minframe1;
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
            if (i == _poolsize2)
                return result;
            result[1] = i + minframe2;
            return result;
        }

        private void parseseed(uint seed, int frame1, int frame2)
        {
            var frame = new Frame_Seed() { Seed = seed, Frame1 = frame1, Frame2 = frame2 };
            var rng = new MersenneTwister_Fast(seed);
            for (int i = 0; i < PreAdvance; i++)
                rng.Next();
            for (int i = 0; i < 7; i++)
                rng.Next();
            for (int i = 0; i < frame1; i++)
                rng.Next();
            frame.nature1 = (byte)((rng.Nextuint() * 25ul) >> 32);
            for (int i = frame1 + 1; i < frame2; i++)
                rng.Next();
            frame.nature2 = (byte)((rng.Nextuint() * 25ul) >> 32);
            seedlist.Add(frame);
            UpdateProgress(null);
        }

        private object _locker = new object();

        private void findseed(uint seedmin, uint seedmax)
        {
            uint[] Pool1 = new uint[poolsize1];
            uint[] Pool2 = new uint[poolsize2];
            int[] frame;
            for (uint i = seedmin; i <= seedmax; i++)
            {
                frame = FindFrame(i, Pool1, Pool2);
                if (frame[1] != 0)
                    lock (_locker)
                    {
                        parseseed(i, frame[0], frame[1]);
                    }
                if ((ushort)i == 0xFFFF)
                {
                    Cnt++;
                    UpdateProgress(null);
                    if (i == 0xFFFFFFFF) // 0xFFFFFFFF ++ = 0
                        break;
                }
            }
        }

        public void FullSearch()
        {
            Max = 0x10000;
            thrds.Add(new Thread(() => findseed(0x00000000, 0x1FFFFFFF)));
            thrds.Add(new Thread(() => findseed(0x20000000, 0x3FFFFFFF)));
            thrds.Add(new Thread(() => findseed(0x40000000, 0x5FFFFFFF)));
            thrds.Add(new Thread(() => findseed(0x60000000, 0x7FFFFFFF)));
            thrds.Add(new Thread(() => findseed(0x80000000, 0x9FFFFFFF)));
            thrds.Add(new Thread(() => findseed(0xA0000000, 0xBFFFFFFF)));
            thrds.Add(new Thread(() => findseed(0xC0000000, 0xDFFFFFFF)));
            thrds.Add(new Thread(() => findseed(0xE0000000, 0xFFFFFFFF)));
            foreach (var t in thrds)
            { t.IsBackground = true; t.Start(); }
        }

        private int FindFrame2(uint seed, uint[] Pool)
        {
            var rng = new MersenneTwister_Fast(seed);
            int i;
            for (i = 0; i < PreAdvance; i++)
                rng.Next();
            for (i = 0; i < minframe; i++)
                rng.Next();
            for (i = 0; i < poolsize; i++)
                Pool[i] = rng.Nextuint() >> 27;
            for (i = 0; i < _poolsize; i++)
            {
                if (
                    IVmin[0] <= Pool[i] && Pool[i] <= IVmax[0] &&
                    IVmin[1] <= Pool[i + 1] && Pool[i + 1] <= IVmax[1] &&
                    IVmin[2] <= Pool[i + 2] && Pool[i + 2] <= IVmax[2] &&
                    IVmin[3] <= Pool[i + 3] && Pool[i + 3] <= IVmax[3] &&
                    IVmin[4] <= Pool[i + 4] && Pool[i + 4] <= IVmax[4] &&
                    IVmin[5] <= Pool[i + 5] && Pool[i + 5] <= IVmax[5]
                 )
                    break;
            }
            if (i == _poolsize1)
                return 0;
            return i + minframe;
        }

        private int[] IVmin, IVmax;
        private int minframe, maxframe, poolsize, _poolsize;

        public void setFinder2(int[] iv_min, int[] iv_max, int min, int max)
        {
            IVmin = iv_min;
            IVmax = iv_max;
            minframe = min;
            maxframe = max;
            poolsize = max - min + 1;
            _poolsize = poolsize - 5;
        }

        private void parseseed2(uint seed, int frame)
        {
            var Frame = new Frame_Seed() { Seed = seed, Frame1 = frame, };
            var rng = new MersenneTwister_Fast(seed);
            for (int i = 0; i < PreAdvance; i++)
                rng.Next();
            for (int i = 0; i < 7; i++)
                rng.Next();
            for (int i = 0; i < frame; i++)
                rng.Next();
            Frame.nature1 = (byte)((rng.Nextuint() * 25ul) >> 32);
            seedlist.Add(Frame);
        }

        public void findseed2(uint seedmin, uint seedmax)
        {
            uint[] Pool = new uint[poolsize];
            int frame;
            Max = (int)((seedmax - seedmin) >> 16) + 1;
            ushort updatepoint = (ushort)seedmax;
            for (uint i = seedmin; i <= seedmax; i++)
            {
                frame = FindFrame2(i, Pool);
                if (frame != 0)
                    lock (_locker)
                    {
                        parseseed2(i, frame);
                    }
                if ((ushort)i == updatepoint)
                {
                    Cnt++;
                    UpdateProgress(null);
                    if (i == 0xFFFFFFFF) // (0xFFFFFFFF)++ = 0
                        break;
                }
            }
        }
    }
}
