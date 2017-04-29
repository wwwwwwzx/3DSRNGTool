using System.Linq;
using PKHeX.Core;
using pkm3dsRNG.Core;

namespace pkm3dsRNG
{
    public class Wild7 : WildRNG
    {
        private static ulong getrand => RNGPool.getrand64;
        private static void time_elapse(int n) => RNGPool.time_elapse(n);
        private static void Advance(int n) => RNGPool.Advance(n);

        public byte SpecialEnctr; // !=0 means there is ub/qr present
        public byte Levelmin, Levelmax;
        // public bool CompoundEye;
        public bool UB;

        private bool IsSpecial;
        private bool IsMinior => SpecForm[slot] == 774;
        private bool IsUB => UB && IsSpecial;
        private bool IsShinyLocked => IsUB;
        private bool NormalSlot => !IsSpecial;

        public override int PerfectIVCount => IV3[slot] ? 3 : 1;
        public override int PIDroll_count => ShinyCharm && !IsShinyLocked ? 3 : 1;

        public override RNGResult Generate()
        {
            ResultW7 rt = new ResultW7();

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
            rt.IVs = new[] { -1, -1, -1, -1, -1, -1 };
            while (rt.IVs.Count(iv => iv == 31) < PerfectIVCount)
                rt.IVs[(int)(getrand % 6)] = 31;
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand & 0x1F);

            //Ability
            rt.Ability = (byte)((getrand & 1) + 1);

            //Nature
            rt.Nature = (byte)(rt.Synchronize ? Synchro_Stat : getrand % 25);

            //Gender
            rt.Gender = (byte)(RandomGender[slot] ? ((int)(getrand % 252) >= Gender[slot] ? 1 : 2) : Gender[slot]);

            //Item
            rt.Item = (byte)(NormalSlot ? getrand % 100 : 100);

            return rt;
        }

        public void markslots(int special = 0)
        {
            SpecForm[0] = special;
            RandomGender = new bool[SpecForm.Length];
            Gender = new byte[SpecForm.Length];
            for (int i = 0; i < SpecForm.Length; i++)
            {
                PersonalInfo info = PersonalTable.SM.getFormeEntry(SpecForm[i] & 0x7FF, SpecForm[i] >> 11);
                byte genderratio = (byte)info.Gender;
                IV3[i] = info.EggGroups[0] == 0xF;
                Gender[i] = FuncUtil.getGenderRatio(genderratio);
                RandomGender[i] = FuncUtil.IsRandomGender(genderratio);
            }
        }
    }
}
