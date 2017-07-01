using System;
using System.Collections.Generic;
using System.Threading;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class TinySeedFinder
    {
        private int Advance;
        public readonly uint[] NatureList = new uint[8];

        #region Threading
        public List<string> seedlist = new List<string>();
        public List<Thread> thrds = new List<Thread>();

        public int Cnt; // Progress
        const int Thread_Number = 8;
        public readonly int Max = 4096 + Thread_Number;

        public event EventHandler Update;
        private void UpdateProgress(EventArgs e)
        {
            lock (_locker)
            {
                Cnt++;
                Update?.Invoke(this, e);
            }
        }

        public event EventHandler NewResult;
        private void UpdateTable(EventArgs e)
        {
            NewResult?.Invoke(this, e);
        }

        private object _locker = new object();

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
            seedlist = new List<string>();
            thrds.Clear();
            Cnt = 0;
        }

        private void parseseed(uint seed)
        {
            var rng = new TinyMT(seed);
            lock (_locker)
            {
                seedlist.Add(rng.CurrentState().ToString());
                UpdateTable(null);
            }
        }
        #endregion

        public void SetFinder(uint[] list, bool HasShinyCharm = false)
        {
            if (list.Length != 8)
                return;
            Advance = HasShinyCharm ? 12 : 10; // Advancement After IVs
            list.CopyTo(NatureList, 0);
        }

        #region Misc Private Function
        private bool Check(uint seed)
        {
            TinyMT tiny = new TinyMT(seed);
            for (int i = 0; i < 7; i++)
            {
                tiny.Next(); // Gender
                if (tiny.Nextuint() % 25 != NatureList[i])
                    return false;
                GenerateRest(tiny);
            }
            tiny.Next();
            return tiny.Nextuint() % 25 == NatureList[7];
        }

        private void GenerateRest(TinyMT tiny)
        {
            // Ability
            tiny.Next();

            // IVs Random Advancement
            // Hard to read but efficient
            uint tmp;
            uint[] InheritIV = new uint[2];
            InheritIV[0] = tiny.Nextuint() % 6;
            tiny.Next();
            do { tmp = tiny.Nextuint() % 6; }
            while (tmp == InheritIV[0]);
            tiny.Next(); InheritIV[1] = tmp;
            do { tmp = tiny.Nextuint() % 6; }
            while (tmp == InheritIV[0] || tmp == InheritIV[1]);

            // Rest
            for (int i = Advance; i > 0; i--) // IVs * 7 + EC + PID * 0/2 + 2
                tiny.Next();
        }


        private void findseed(uint seedmin, uint seedmax)
        {
            for (uint i = seedmin; i <= seedmax; i++)
            {
                if (Check(i))
                    parseseed(i);
                if ((ushort)i == 0xFFFF)
                {
                    UpdateProgress(null);
                    if (i == 0xFFFFFFFF) // (0xFFFFFFFF)++ = 0
                        break;
                }
            }
            UpdateProgress(null);
        }

        private void FindSeed(object param)
        {
            var seedrange = (uint[])param;
            findseed(seedrange[0], seedrange[1]);
        }
        #endregion

        public void Search()
        {
            var threadstart = new ParameterizedThreadStart(FindSeed);
            ulong blocksize = uint.MaxValue / Thread_Number + 1;
            List<object> paramlist = new List<object>();
            ulong i = 0;
            for (; i + blocksize <= uint.MaxValue; i += blocksize)
                paramlist.Add(new uint[] { (uint)i, (uint)(i + blocksize - 1) });
            paramlist.Add(new uint[] { (uint)i, uint.MaxValue });
            for (int j = 0; j < paramlist.Count; j++)
            {
                var t = new Thread(threadstart);
                t.IsBackground = true;
                t.Start(paramlist[j]);
                thrds.Add(t);
            }
        }
    }
}
