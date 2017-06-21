using PKHeX.Core;
using Pk3DSRNGTool.Core;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class Wild6 : WildRNG
    {
        private static uint getrand => RNGPool.getrand;
        private static uint rand(uint n) => (uint)(getrand * (ulong)n >> 32);
        private static void Advance(int n) => RNGPool.Advance(n);

        private static TinyMT tiny;
        private static uint getTinyRand => tiny.Nextuint();
        private static byte TinyRand(int n) => (byte)(getTinyRand * (ulong)n >> 32);

        private byte getSlot
        {
            get
            {
                switch (Wildtype)
                {
                    case EncounterType.FriendSafari:
                        return slot = (byte)(TinyRand(3) + 1); // Default unlock all
                    case EncounterType.SingleSlot:
                        return 1;
                    case EncounterType.PokeRadar:
                        return IsShinyLocked ? (byte)1 : getslot(TinyRand(100));
                    default: return getslot(TinyRand(100));
                }
            }
        }
        private bool getSync => getTinyRand < 0x80000000;
        private byte getAbility => 0; // Todo

        public EncounterType Wildtype;
        public bool HA;
        public bool IsShinyLocked;
        public int _PIDroll_count;
        protected override int PIDroll_count => _PIDroll_count;
        public int _ivcnt = -1;
        protected override int PerfectIVCount => System.Math.Max(_ivcnt, IV3[slot] ? 3 : 0);
        public int BlankGenderRatio;

        public byte[] SlotLevel;
        public bool CompoundEye;

        public override RNGResult Generate()
        {
            var rt = new ResultW6();
            if (null != (tiny = RNGPool.tiny?.getTiny))
            {
                rt.Synchronize = getSync;
                rt.Slot = getSlot;
            }
            else
                slot = rt.Slot = 1;
            Advance(60);
            Generate_Once(rt);
            rt.ItemStr = "-";
            return rt;
        }

        public ResultW6[] Generate_Horde()
        {
            bool Sync = getSync;
            var results = new ResultW6[5];
            Advance(60);
            for (int i = 0; i < 5; i++)
            {
                var rt = new ResultW6();
                rt.Synchronize = Sync;
                slot = rt.Slot = (byte)(i + 1);
                rt.Ability = getAbility;
                Generate_Once(rt);
                results[i] = rt;
            }
            return results;
        }

        private void Generate_Once(ResultW6 rt)
        {
            //Level
            rt.Level = SlotLevel[slot];

            //Encryption Constant
            rt.EC = getrand;

            //PID
            for (int i = PIDroll_count; i > 0; i--)
            {
                rt.PID = getrand;
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
                uint tmp = rand(6);
                if (rt.IVs[tmp] == 0)
                {
                    i--; rt.IVs[tmp] = 31;
                }
            }
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] == 0)
                    rt.IVs[i] = (int)(getrand >> 27);

            //Ability
            rt.Ability = (byte)(rt.Ability < 3 ? (HA ? rand(3) : (getrand >> 31)) + 1 : 3);

            //Nature
            rt.Nature = (byte)(rt.Synchronize & Synchro_Stat < 25 ? Synchro_Stat : rand(25));

            //Gender
            rt.Gender = (byte)(RandomGender[slot] ? (rand(252) >= Gender[slot] ? 1 : 2) : Gender[slot]);
        }

        public override void Markslots()
        {
            IV3 = new bool[SpecForm.Length];
            RandomGender = new bool[SpecForm.Length];
            Gender = new byte[SpecForm.Length];
            for (int i = 0; i < SpecForm.Length; i++)
            {
                if (SpecForm[i] == 0)
                {
                    if (i == 0)
                        continue;
                    Gender[i] = FuncUtil.getGenderRatio(BlankGenderRatio);
                    RandomGender[i] = FuncUtil.IsRandomGender(BlankGenderRatio);
                    continue;
                }
                PersonalInfo info = PersonalTable.ORAS.getFormeEntry(SpecForm[i] & 0x7FF, SpecForm[i] >> 11);
                byte genderratio = (byte)info.Gender;
                IV3[i] = info.EggGroups[0] == 0xF;
                Gender[i] = FuncUtil.getGenderRatio(genderratio);
                RandomGender[i] = FuncUtil.IsRandomGender(genderratio);
            }
            _PIDroll_count += ShinyCharm && !IsShinyLocked ? 3 : 1;
        }

        private string getitemstr(int rand) // to-do
        {
            if (rand < (CompoundEye ? 60 : 50))
                return "50%";
            if (rand < (CompoundEye ? 80 : 55))
                return "5%";
            return "-";
        }
    }
}
