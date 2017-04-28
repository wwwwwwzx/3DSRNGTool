using System.Linq;
using pkm3dsRNG.Core;

namespace pkm3dsRNG
{
    class Stationary6 : StationaryRNG
    {
        private static uint getrand => RNGPool.getrand;

        public override int PerfectIVCount => IV3 ? 3 : 0;
        public override int PIDroll_count => ShinyCharm && !IsShinyLocked ? 3 : 1;

        public override RNGResult Generate()
        {
            Result6 rt = new Result6();
            rt.Level = Level;

            //Sync
            if (AlwaysSync)
                rt.Synchronize = true;
            else
                rt.Synchronize = (int)(getrand % 100) >= 50;

            rt.Synchronize &= Synchro_Stat < 25;

            //Encryption Constant
            rt.EC = getrand;

            //PID
            for (int i = 0; i < PIDroll_count; i++)
            {
                rt.PID = getrand;
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

            //Nature
            rt.Nature = (byte)(rt.Synchronize ? Synchro_Stat : getrand % 25);

            //Gender
            rt.Gender = (byte)(RandomGender ? ((int)(getrand % 252) >= Gender ? 1 : 2) : Gender);

            return rt;
        }
    }
}
