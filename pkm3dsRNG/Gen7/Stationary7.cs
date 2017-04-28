using System.Linq;
using pkm3dsRNG.Core;

namespace pkm3dsRNG
{
    class Stationary7 : StationaryRNG
    {
        private static ulong getrand => RNGPool.getrand64;
        private static void time_elapse(int n) => RNGPool.time_elapse(n);

        public override int PerfectIVCount => IV3 ? 3 : 0;
        public override int PIDroll_count => ShinyCharm && !IsShinyLocked && !AlwaysSync ? 3 : 1;

        private bool blink_process()
        {
            bool sync = (int)(getrand % 100) >= 50;
            time_elapse(3);
            return sync;
        }

        public override RNGResult Generate()
        {
            Result7 rt = new Result7();
            rt.Level = Level;

            //Synchronize
            rt.Synchronize = AlwaysSync || blink_process();

            rt.Synchronize &= Synchro_Stat < 25;

            if (!AlwaysSync)
                RNGPool.Advance(60);

            //Encryption Constant
            rt.EC = (uint)(getrand & 0xFFFFFFFF);

            //PID
            for (int i = 0; i < PIDroll_count; i++)
            {
                rt.PID = (uint)(getrand & 0xFFFFFFFF);
                if (rt.PSV == TSV)
                    break;
            }
            if (IsShinyLocked && rt.PSV == TSV)
                rt.PID ^= 0x10000000;
            rt.Shiny = rt.PSV == TSV;

            //IV
            rt.IVs = (int[])IVs?.Clone() ?? new[] { -1, -1, -1, -1, -1, -1 };
            while (rt.IVs.Count(iv => iv == 31) < PerfectIVCount)
                rt.IVs[(int)(getrand % 6)] = 31;
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand & 0x1F);

            //Ability
            rt.Ability = (byte)(AlwaysSync ? (getrand & 1) + 1 : 1);

            //Nature
            rt.Nature = (byte)(rt.Synchronize ? Synchro_Stat : getrand % 25);

            //Gender
            rt.Gender = (byte)(RandomGender ? ((int)(getrand % 252) >= Gender ? 1 : 2) : Gender);

            return rt;
        }
    }
}
