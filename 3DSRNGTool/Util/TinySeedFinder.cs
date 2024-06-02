using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class TinySeedFinder
    {
        private CancellationTokenSource cts;

        private int Advance;
        public readonly uint[] NatureList = new uint[8];

        #region Threading
        public List<string> seedlist = new();

        public int Cnt; // Progress
        private static int Thread_Number => Environment.ProcessorCount;
        public readonly int Max = 0x10000 + Thread_Number;

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

        private readonly object _locker = new();

        public void Abort()
        {
            cts.Cancel();
            cts = new();
        }

        public void Clear()
        {
            seedlist.Clear();
            seedlist = new List<string>();
            cts.Cancel();
            cts = new();
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

        private void FindSeed(uint seedmin, uint seedmax, CancellationToken token)
        {
            for (uint i = seedmin; i <= seedmax; i++)
            {
                if (Check(i))
                    parseseed(i);
                if ((ushort)i != 0xFFFF)
                    continue;
                UpdateProgress(null);
                if (i == 0xFFFFFFFF || token.IsCancellationRequested) // (0xFFFFFFFF)++ = 0
                    break;
            }
            UpdateProgress(null);
        }

        #endregion

        public void Search()
        {
            ulong blocksize = (uint.MaxValue / ((ulong)Environment.ProcessorCount)) + 1;

            var token = cts.Token;
            Parallel.For(0, Thread_Number, new ParallelOptions { CancellationToken = token }, (index) =>
            {
                if (token.IsCancellationRequested)
                    return; // Don't throw.

                ulong start = (ulong)index * blocksize;
                ulong end = (index == Thread_Number - 1) ? uint.MaxValue : start + blocksize - 1;
                FindSeed((uint)start, (uint)end, token);
            });
        }
    }
}
