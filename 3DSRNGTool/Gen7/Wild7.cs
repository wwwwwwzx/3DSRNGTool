using System.Linq;
using PKHeX.Core;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Wild7 : WildRNG
    {
        private static ulong getrand => RNGPool.getrand64;
        private static void time_elapse(int n) => RNGPool.time_elapse(n);
        private static void Advance(int n) => RNGPool.Advance(n);

        public byte SpecialEnctr; // !=0 means there is ub/qr present
        public byte Levelmin, Levelmax;
        public byte SpecialLevel;
        public bool CompoundEye;
        public bool UB;

        private bool IsSpecial;
        private bool IsMinior => SpecForm[slot] == 774;
        private bool IsUB => UB && IsSpecial;
        private bool IsShinyLocked => IsUB;
        private bool NormalSlot => !IsSpecial;

        protected override int PIDroll_count => ShinyCharm && !IsShinyLocked ? 3 : 1;

        public override RNGResult Generate()
        {
            ResultW7 rt = new ResultW7();
            rt.Level = SpecialLevel;

            if (SpecialEnctr > 0)
                IsSpecial = rt.IsSpecial = (byte)(getrand % 100) < SpecialEnctr;

            if (NormalSlot) // Normal wild
            {
                rt.Synchronize = (int)(getrand % 100) >= 50;
                rt.Slot = getslot((int)(getrand % 100));
                rt.Level = (byte)(getrand % (ulong)(Levelmax - Levelmin + 1) + Levelmin);
                Advance(1);
                if (IsMinior) Advance(1);
            }
            else // UB or QR
            {
                slot = 0;
                time_elapse(7);
                rt.Synchronize = (int)(getrand % 100) >= 50;
                time_elapse(3);
            }

            Advance(60);

            //Encryption Constant
            rt.EC = (uint)(getrand & 0xFFFFFFFF);

            //PID
            for (int i = PIDroll_count; i > 0; i--)
            {
                rt.PID = (uint)(getrand & 0xFFFFFFFF);
                if (rt.PSV == TSV) { rt.Shiny = true; break; }
            }
            if (IsShinyLocked && rt.Shiny)
            {
                rt.PID ^= 0x10000000;
                rt.Shiny = false;
            }

            //IV
            rt.IVs = new int[6];
            for (int i = PerfectIVCount; i > 0;)
            {
                int tmp = (int)(getrand % 6);
                if (rt.IVs[tmp] == 0)
                {
                    i--; rt.IVs[tmp] = 31;
                }
            }
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] == 0)
                    rt.IVs[i] = (int)(getrand & 0x1F);

            //Ability
            rt.Ability = (byte)(IsUB ? 1 : (getrand & 1) + 1);

            //Nature
            rt.Nature = (byte)(rt.Synchronize && Synchro_Stat < 25 ? Synchro_Stat : getrand % 25);

            //Gender
            rt.Gender = (byte)(RandomGender[slot] ? ((int)(getrand % 252) >= Gender[slot] ? 1 : 2) : Gender[slot]);

            //Item
            rt.Item = (byte)(NormalSlot ? getrand % 100 : 100);
            rt.ItemStr = getitemstr(rt.Item);

            return rt;
        }

        public override void Markslots()
        {
            IV3 = new bool[SpecForm.Length];
            RandomGender = new bool[SpecForm.Length];
            Gender = new byte[SpecForm.Length];
            for (int i = 0; i < SpecForm.Length; i++)
            {
                if (SpecForm[i] == 0) continue;
                PersonalInfo info = PersonalTable.SM.getFormeEntry(SpecForm[i] & 0x7FF, SpecForm[i] >> 11);
                byte genderratio = (byte)info.Gender;
                IV3[i] = info.EggGroups[0] == 0xF;
                Gender[i] = FuncUtil.getGenderRatio(genderratio);
                RandomGender[i] = FuncUtil.IsRandomGender(genderratio);
            }
            if (UB) IV3[0] = true; // For UB Template
        }

        private string getitemstr(int rand)
        {
            if (rand < (CompoundEye ? 60 : 50))
                return "50%";
            if (rand < (CompoundEye ? 80 : 55))
                return "5%";
            return "-";
        }
    }
}
