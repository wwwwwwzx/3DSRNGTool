using System.Linq;
using PKHeX.Core;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Wild6 : WildRNG
    {
        private static uint getrand => RNGPool.getrand;
        private static uint rand(uint n) => (uint)(getrand * (ulong)n >> 32);
        private static void Advance(int n) => RNGPool.Advance(n);

        private static uint getTinyRand => RNGPool.tinystatus.Nextuint();
        private static byte TinyRand(int n) => RNGPool.tinystatus.Rand(n);
        private static void tiny_Advance(int n)
        {
            for (int i = n; i > 0; i--)
                RNGPool.AdvanceTiny();
        }

        public EncounterType Wildtype;
        public bool HA;
        public bool IsShinyLocked;
        public int _PIDroll_count;
        private bool IsUnown => SpecForm[slot] == 201;
        protected override int PIDroll_count => _PIDroll_count;
        public int _ivcnt = -1;
        protected override int PerfectIVCount => System.Math.Max(_ivcnt, IV3[slot] ? 3 : 0);
        public int BlankGenderRatio;

        public byte[] SlotLevel;
        public bool CompoundEye;    // For held item
        public byte PartyPKM;       // For fishing
        public byte EncounterRate;

        public bool IsORAS;

        // ORAS v1.4 sub_78D900
        protected override void CheckLeadAbility(ulong rand100)
        {
            SynchroPass = rand100 < 50;
            CuteCharmPass = CuteCharmGender > 0 && rand100 < 67;
            StaticMagnetPass = StaticMagnet && rand100 < 50;
            LevelModifierPass = ModifiedLevel != 0 && rand100 < 50;
        }

        private byte getslot6() => slot = StaticMagnetPass ? StaticMagnetSlot[TinyRand((int)NStaticMagnetSlot)] : getslot(TinyRand(100));

        private void Prepare(ResultW6 rt)
        {
            if (RNGPool.tinystatus == null)
            {
                rt.Synchronize = RNGPool.TinySynced;
                return;
            }
            // Delay
            switch (Wildtype)
            {
                case EncounterType.RockSmash:
                    RNGPool.time_elapse6(16);
                    tiny_Advance(3);
                    RNGPool.time_elapse6(RNGPool.DelayTime - 228);
                    tiny_Advance(1);
                    RNGPool.time_elapse6(212);
                    RNGResult.IsPokemon = TinyRand(3) == 0; // 0 for Pokemon, 1 for item, 2 for nothing
                    break;
                case EncounterType.CaveShadow:
                    RNGPool.time_elapse6(32);
                    tiny_Advance(1);
                    RNGPool.time_elapse6(46);
                    break;
                case EncounterType.OldRod:
                case EncounterType.GoodRod:
                case EncounterType.SuperRod:
                    RNGPool.time_elapse6(RNGPool.DelayTime);
                    tiny_Advance(3 * PartyPKM);
                    RNGPool.time_elapse6(132);
                    Advance(132);
                    var fishingdelay = TinyRand(7) * 30 + 60;
                    RNGPool.time_elapse6(fishingdelay);
                    Advance(fishingdelay);
                    break;
                default:
                    RNGPool.time_elapse6(RNGPool.DelayTime);
                    break;
            }

            CheckLeadAbility(TinyRand(100));
            rt.Synchronize = SynchroPass;

            // Encounter Slot and Others
            switch (Wildtype)
            {
                case EncounterType.PokeRadar when IsShinyLocked: // Not first encounter, skip slot check
                    break;
                case EncounterType.Normal:
                case EncounterType.OldRod:
                case EncounterType.GoodRod:
                case EncounterType.SuperRod:
                case EncounterType.FriendSafari:  // 13%
                    RNGResult.IsPokemon = TinyRand(100) < EncounterRate;
                    goto default;
                default:
                    rt.Slot = getslot6();
                    break;
            }

            // Flute
            if (IsORAS)
                FluteBoost = getFluteBoost(TinyRand(100));

            // Something
            tiny_Advance(1);

            // Item generated after pkm
            rt.Item = TinyRand(100);
            rt.ItemStr = StringItem.helditemStr[getItem(rt.Item, CompoundEye)];
        }

        public override RNGResult Generate()
        {
            var rt = new ResultW6();
            Prepare(rt);
            Advance(60);
            Generate_Once(rt);
            return rt;
        }

        public ResultW6[] Generate_Horde(Horde Hrt = null)
        {
            var results = new ResultW6[5];
            for (int i = 0; i < 5; i++)
                results[i] = new ResultW6();

            // Use results from tiny
            if (Hrt != null)
            {
                CheckLeadAbility(Hrt.Lead);
                for (int i = 0; i < 5; i++)
                {
                    results[i].Synchronize = SynchroPass;
                    results[i].Item = Hrt.HeldItems[i];
                    results[i].ItemStr = StringItem.helditemStr[getItem(Hrt.HeldItems[i], CompoundEye)];
                }
                if (Hrt.HA != 0)
                    results[Hrt.HA - 1].Ability = 3;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                    results[i].Synchronize = RNGPool.TinySynced;
            }

            // Something
            Advance(60);
            for (int i = 0; i < 5; i++)
            {
                slot = results[i].Slot = (byte)(i + 1);
                FluteBoost = Hrt?.FluteBoosts[i] ?? 0;
                Generate_Once(results[i]);
            }
            return results;
        }

        private void Generate_Once(ResultW6 rt)
        {
            //Species
            rt.Species = (short)(SpecForm[slot] & 0x7FF);

            //Level
            rt.Level = SlotLevel[slot];
            ModifyLevel(rt);

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

            //Form
            if (IsUnown) rt.Forme = (byte)rand(28);

            //Gender
            rt.Gender = (byte)(RandomGender[slot] ? CuteCharmPass ? CuteCharmGender : (rand(252) >= Gender[slot] ? 1 : 2) : Gender[slot]);
        }

        public override void Markslots()
        {
            IV3 = new bool[SpecForm.Length];
            RandomGender = new bool[SpecForm.Length];
            Gender = new byte[SpecForm.Length];
            var smslot = new int[0].ToList();
            if (SpecForm.Distinct().Count(t => t != 0) == 1)
                SpecForm[0] = SpecForm[1];
            for (int i = 0; i < SpecForm.Length; i++)
            {
                if (SpecForm[i] == 0)
                {
                    Gender[i] = FuncUtil.getGenderRatio(BlankGenderRatio);
                    RandomGender[i] = FuncUtil.IsRandomGender(BlankGenderRatio);
                    continue;
                }
                PersonalInfo info = PersonalTable.ORAS.getFormeEntry(SpecForm[i] & 0x7FF, SpecForm[i] >> 11);
                byte genderratio = (byte)info.Gender;
                IV3[i] = info.EggGroups[0] == 0xF && !(Pokemon.BabyMons.Contains(SpecForm[i] & 0x7FF) && IsORAS);
                Gender[i] = FuncUtil.getGenderRatio(genderratio);
                RandomGender[i] = FuncUtil.IsRandomGender(genderratio);
                if (Static && info.Types.Contains(Pokemon.electric) || Magnet && info.Types.Contains(Pokemon.steel)) // Collect slots
                    smslot.Add(i);
            }
            StaticMagnetSlot = smslot.Select(s => (byte)s).ToArray();
            if (0 == (NStaticMagnetSlot = (ulong)smslot.Count))
                Static = Magnet = false;
            if (ModifiedLevel != 0)
                ModifiedLevel = SlotLevel.Skip(1).Max();
            _PIDroll_count += ShinyCharm && !IsShinyLocked ? 3 : 1;
        }

        public static byte getItem(int rand, bool compoundeye = false)
        {
            if (rand < (compoundeye ? 60 : 50))
                return 0; // 50%
            if (rand < (compoundeye ? 80 : 55))
                return 1; // 5%
            if (rand < (compoundeye ? 85 : 56))
                return 2; // 1%
            return 3; // None
        }
    }
}
