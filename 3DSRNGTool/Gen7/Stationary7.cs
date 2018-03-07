using System.Linq;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Stationary7 : StationaryRNG
    {
        private static ulong getrand => RNGPool.getrand64;
        private static void time_elapse(int n) => RNGPool.time_elapse7(n);
        private static void Advance(int n) => RNGPool.Advance(n);
        
        private bool IsPelago;
        public byte PelagoShift;
        public bool Trade;
        private bool PostNatureLock;
        public bool? AssumeSynced { get; set; }

        private bool blink_process()
        {
            if (AssumeSynced != null)
                return (bool)AssumeSynced;
            bool sync = getrand % 100 >= 50;
            time_elapse(3);
            return sync || PostNatureLock;
        }

        public override void Delay() => RNGPool.StationaryDelay7();
        public override RNGResult Generate()
        {
            Result7 rt = new Result7();
            rt.Level = Level;

            if (Trade)
                return GenerateTrade(rt);

            //Synchronize
            if (AlwaysSync)
                rt.Synchronize = true;
            else
            {
                rt.Synchronize = blink_process();
                Advance(60);
            }

            //Encryption Constant
            if (IsPelago)
            {
                Advance(60 + PelagoShift);
                rt.EC = (uint)getrand;
                Advance(1); // Random TID
            }
            else
                rt.EC = (uint)getrand;


            //PID
            for (int i = PIDroll_count; i > 0; i--)
            {
                rt.PID = (uint)getrand;
                if (rt.PSV == TSV)
                {
                    if (IsShinyLocked)
                        rt.PID ^= 0x10000000;
                    else
                        rt.Shiny = true;
                    break;
                }
                else if (IsForcedShiny)
                {
                    rt.Shiny = true;
                    rt.PID = (uint)((((TSV << 4) ^ (rt.PID & 0xFFFF)) << 16) + (rt.PID & 0xFFFF)); // Not accurate
                }
            }

            //IV
            rt.IVs = (int[])IVs.Clone();
            for (int i = PerfectIVCount; i > 0;)
            {
                int tmp = (int)(getrand % 6);
                if (rt.IVs[tmp] < 0)
                {
                    i--; rt.IVs[tmp] = 31;
                }
            }
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand & 0x1F);

            //Ability
            rt.Ability = Ability > 0 ? Ability : (byte)((getrand & 1) + 1);

            //Nature
            rt.Nature = rt.Synchronize && Synchro_Stat < 25 ? Synchro_Stat : (byte)(getrand % 25);

            //Gender
            rt.Gender = RandomGender ? (byte)(getrand % 252 >= Gender ? 1 : 2) : Gender;

            return rt;
        }

        private Result7 GenerateTrade(Result7 rt)
        {
            rt.IVs = (int[])IVs.Clone();
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand & 0x1F);

            // All fixed for now
            rt.Ability = Ability;
            rt.Nature = Synchro_Stat;
            rt.Gender = Gender;

            rt.EC = (uint)getrand;
            rt.PID = (uint)getrand;
            if (rt.PSV == TSV)
                rt.PID ^= 0x10000000;

            return rt;
        }


        public override void UseTemplate(Pokemon PM)
        {
            base.UseTemplate(PM);
            var pm7 = PM as PKM7;
            if (pm7.Species == 132 && pm7.Nature < 25) // Ditto five
            {
                PostNatureLock = true;
                AlwaysSync = false;
                PIDroll_count = ShinyCharm ? 3 : 1;
            }
            Ability = Ability == 0 && !AlwaysSync ? (byte)1 : Ability;
            if (pm7.Ability == 0xFF) // Outlier
                Ability = 0;
            if (pm7.IsPelago)
                IsPelago = true;
            if (pm7.OTTSV != null)
            {
                TSV = (int)pm7.OTTSV;
                Trade = !pm7.Gift;
            }
            if (pm7.iv3)
                PerfectIVCount = 3;
            RNGPool.DelayType = pm7.DelayType;
        }
    }

    public class MainEggRNG : StationaryRNG
    {
        private static uint getpid => (uint)RNGPool.getrand64;

        public bool ConsiderOtherTSV;
        public int[] OtherTSVs;
        public override void Delay() => RNGPool.NormalDelay7();
        public override RNGResult Generate()
        {
            var rt = new ResultME7();
            rt.PID = getpid;
            var tmp = rt.PSV;
            rt.Shiny = tmp == TSV || ConsiderOtherTSV && OtherTSVs.Contains((int)tmp);
            return rt;
        }
    }
}
