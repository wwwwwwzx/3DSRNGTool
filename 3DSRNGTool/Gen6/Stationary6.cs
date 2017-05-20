using System.Linq;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Stationary6 : StationaryRNG
    {
        private static uint getrand => RNGPool.getrand;
        private static uint rand(uint n) => (uint)(getrand * (ulong)n >> 32);
        private static void Advance(int n) => RNGPool.Advance(n);

        public override RNGResult Generate()
        {
            Result6 rt = new Result6();
            rt.Level = Level;

            //Sync
            if (AlwaysSync)
                rt.Synchronize = true;
            else
                Advance(60); // Synchro where are you...

            //Encryption Constant
            rt.EC = getrand;

            //PID
            for (int i = PIDroll_count; i > 0; i--)
            {
                rt.PID = getrand;
                if (rt.PSV == TSV) { rt.Shiny = true; break; }
            }
            if (IsShinyLocked && rt.Shiny)
            {
                rt.PID ^= 0x10000000;
                rt.Shiny = false;
            }

            //IV
            rt.IVs = (int[])IVs?.Clone() ?? new[] { -1, -1, -1, -1, -1, -1 };
            for (int i = PerfectIVCount; i > 0;)
            {
                uint tmp = rand(6);
                if (rt.IVs[tmp] < 0)
                {
                    i--; rt.IVs[tmp] = 31;
                }
            }
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand >> 27);

            //Ability
            rt.Ability = (byte)(Ability == 0 ? (getrand >> 31) + 1 : Ability);

            //Nature
            rt.Nature = (byte)(rt.Synchronize && Synchro_Stat < 25 ? Synchro_Stat : rand(25));

            //Gender
            rt.Gender = (byte)(RandomGender ? (rand(252) >= Gender ? 1 : 2) : Gender);

            //For Pokemon Link
            rt.FrameUsed = (byte)(RNGPool.index - 1);

            return rt;
        }
    }
}
