using System.Linq;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    class Stationary6 : StationaryRNG
    {
        private static uint getrand => RNGPool.getrand;
        private static uint rand(uint n) => (uint)(getrand * (ulong)n >> 32);
        private static void Advance(int n) => RNGPool.Advance(n);

        public override int PerfectIVCount => IV3 ? 3 : 0;
        public override int PIDroll_count => ShinyCharm && !IsShinyLocked ? 3 : 1;

        public override RNGResult Generate()
        {
            Result6 rt = new Result6();
            rt.Level = Level;
            
            Advance(16);

            //Sync
            if (AlwaysSync)
                rt.Synchronize = true;
            else
                rt.Synchronize = rand(100) >= 50;
            
            Advance(624);

            if (!AlwaysSync)
                Advance(60);

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
                rt.IVs[rand(6)] = 31;
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand >> 27);

            //Ability
            rt.Ability = (byte)((getrand >> 31) + 1);

            //Nature
            rt.Nature = (byte)(rt.Synchronize ? Synchro_Stat : rand(25));

            //Gender
            rt.Gender = (byte)(RandomGender ? (rand(252) >= Gender ? 1 : 2) : Gender);

            return rt;
        }
    }
}
