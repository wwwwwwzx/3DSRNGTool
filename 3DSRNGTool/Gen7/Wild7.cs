using System.Linq;
using PKHeX.Core;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Wild7 : WildRNG
    {
        private static ulong getrand => RNGPool.getrand64;
        private static void time_elapse(int n) => RNGPool.time_elapse7(n);
        private static void Advance(int n) => RNGPool.Advance(n);

        public byte SpecialEnctr; // !=0 means there is ub/qr present
        public byte Levelmin, Levelmax;
        public byte SpecialLevel;
        public bool CompoundEye;
        public bool UB;
        public bool Fishing;

        private bool IsSpecial;
        private bool IsMinior => SpecForm[slot] == 774;
        private bool IsUB => UB && IsSpecial;
        private bool IsShinyLocked => IsUB && SpecForm[0] < 800; // Not USUM UB
        private bool NormalSlot => !IsSpecial || Fishing;

        protected override int PIDroll_count => ShinyCharm && !IsShinyLocked ? 3 : 1;

        public override void Delay() => RNGPool.WildDelay7();
        public override RNGResult Generate()
        {
            ResultW7 rt = new ResultW7();
            rt.Level = SpecialLevel;

            if (Fishing)
            {
                IsSpecial = rt.IsSpecial = (byte)(getrand % 100) >= SpecialEnctr;
                time_elapse(12);
                if (IsSpecial) // Predict hooked item
                {
                    int mark = RNGPool.index;
                    time_elapse(34);
                    rt.SpecialVal = (byte)(getrand % 100);
                    RNGPool.Rewind(mark); // Don't need to put modelstatus back
                }
            }
            else if (SpecialEnctr > 0)
                IsSpecial = rt.IsSpecial = (byte)(getrand % 100) < SpecialEnctr;

            if (NormalSlot) // Normal wild
            {
                rt.Synchronize = (int)(getrand % 100) >= 50;
                rt.Slot = StaticMagnet && rt.Synchronize ? getsmslot(getrand) : getslot((int)(getrand % 100));
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

            if (Fishing && rt.IsSpecial)
                rt.Slot = getHookedItemSlot(rt.SpecialVal);

            return rt;
        }

        public override void Markslots()
        {
            IV3 = new bool[SpecForm.Length];
            RandomGender = new bool[SpecForm.Length];
            Gender = new byte[SpecForm.Length];
            var smslot = new int[0].ToList();
            for (int i = 0; i < SpecForm.Length; i++)
            {
                if (SpecForm[i] == 0) continue;
                PersonalInfo info = PersonalTable.USUM.getFormeEntry(SpecForm[i] & 0x7FF, SpecForm[i] >> 11);
                byte genderratio = (byte)info.Gender;
                IV3[i] = info.EggGroups[0] == 0xF && !Pokemon.BabyMons.Contains(SpecForm[i] & 0x7FF);
                Gender[i] = FuncUtil.getGenderRatio(genderratio);
                RandomGender[i] = FuncUtil.IsRandomGender(genderratio);
                if (Static && info.Types.Contains(Pokemon.electric) || Magnet && info.Types.Contains(Pokemon.steel)) // Collect slots
                    smslot.Add(i);
            }
            StaticMagnetSlot = smslot.Select(s => (byte)s).ToArray();
            if (0 == (NStaticMagnetSlot = (ulong)smslot.Count))
                Static = Magnet = false;
            if (UB) IV3[0] = true; // For UB Template
        }

        private byte getsmslot(ulong rand)
        {
            return slot = StaticMagnetSlot[rand % NStaticMagnetSlot];
        }

        private string getitemstr(int rand)
        {
            if (rand < (CompoundEye ? 60 : 50))
                return StringItem.helditemStr[0]; // 50%
            if (rand < (CompoundEye ? 80 : 55))
                return StringItem.helditemStr[1]; // 5%
            return StringItem.helditemStr[3]; // None
        }

        public static byte getDelayType(int category)
        {
            switch (category)
            {
                case 3: return 1;
                default: return 0;
            }
        }

        public static byte getSpecialRate(int category)
        {
            switch (category)
            {
                case 1: return 80;
                case 2: return 50;
                case 3: return 80;
                default: return 0;
            }
        }

        public static byte getHookedItemSlot(byte? rand)
        {
            if (rand == null)
                return 0;
            if (rand < 50)
                return 1;
            if (rand < 60)
                return 2;
            if (rand < 70)
                return 3;
            if (rand < 80)
                return 4;
            if (rand < 90)
                return 5;
            if (rand < 99)
                return 6;
            return 7;
        }
    }

    public struct FishingSetting
    {
        public int basedelay;
        public bool suctioncups;
        public int bitechance;
        public int platdelay;
        public int pkmdelay;
    }
}
