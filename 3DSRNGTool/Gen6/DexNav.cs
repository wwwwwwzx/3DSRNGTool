using System;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class DexNav
    {
        // Result
        public bool Success;
        public int X, Y; // Shaking location. Direction: X → and Y ↓
        public byte AdditionalDelay;
        public int Slot;
        public int Slottype; // 0 Grass; 1 Tall Grass; 2 Surf; 3 DexNav
        public bool Boost;
        public byte Lead;
        public bool Sync => Lead < 50;
        public int LevelBoost;
        public byte FluteBoost;
        public bool HA;
        public byte Potential;
        public bool EggMove;
        public byte HeldItem;
        public bool ForcedShiny;

        // RNG
        private static TinyMT rng;
        private static int Rand(ulong n) => (int)((rng.Nextuint() * n) >> 32);
        public DexNav(uint[] src)
        {
            rng = new TinyMT(src);

            if (ActiveSearch || Trigger())                        // Active Search or triggered by every 20 steps
                for (; AdditionalDelay < 8; AdditionalDelay += 2) // Do 4 times check, adds 2 delay if fail once.
                    for (int i = 0; i < 5; i++)                   // check at most 5 patches per visual
                        if (FindPatch())
                        {
                            Generate();
                            PostCheck();
                            if (Success)
                                return;
                            break;
                        }
        }

        public bool Trigger()
        {
            // Normal step trigger
            rng.Next();     // sync
            rng.Next();     // Encounter Rate
            // DexNav trigger
            return Rand(100) < 50;
        }

        public bool FindPatch()
        {
            switch (Rand(4))
            {
                case 0: // Up
                    X = -9 + Rand(18); Y = -9 + Rand(3); break;
                case 1: // Left
                    X = -9 + Rand(3); Y = -7 + Rand(14); break;
                case 2: // Right
                    X = 7 + Rand(3); Y = -7 + Rand(14); break;
                case 3: // Down
                    X = -9 + Rand(18); Y = 7 + Rand(3); break;
            }
            return true;  // To-do
        }

        public void Generate()
        {
            // Slot type
            Slottype = Rand(100) < 30 && HasDexNav ? 3 : EncounterType; // sub_770A4D

            // Boost
            Boost = ChainLength > 0 && (ChainLength + 1) % 5 == 0 || Rand(100) < 4;  // sub_40295C

            // Sync
            Lead = (byte)Rand(100);

            // Slot
            if (!ActiveSearch)
                for (Slot = SlotNum[Slottype] - 1; Slot >= 0; Slot--) // sub_7705F4
                    if (Rand(100) < 30)
                        break;
            if (Slot < 0) Slot = 0;

            // Something
            rng.Next();

            // sub_7D8728 : the Core part
            byte Grade = GetGrade;

            // Level
            LevelBoost = ChainLength / 5 + (Boost ? 10 : 0);
            FluteBoost = Core.WildRNG.getFluteBoost((ulong)Rand(100));

            // Hidden Ability
            HA = Rand(100) < HARate[Grade];

            // IVs
            int Index;
            for (Index = 2; Index >= 0; Index--)
                if (Rand(100) < IVRate[3 * Grade + Index])
                    break;
            Index += Boost ? 2 : 1;
            Potential = (byte)Math.Min(3, Index);

            // Egg Move
            EggMove = Rand(100) < EggMoveRate[Grade] || Boost;

            // Held Item
            int tmp = Rand(100);
            for (Index = 0; Index < 2; Index++)
            {
                tmp -= HeldItemRate[Grade * 2 + Index];
                if (CompoundEyes)
                    tmp -= 5;
                if (tmp < 0)
                    break;
            }
            if (Index >= 2)
                Index = 3;
            HeldItem = (byte)Index;

            // Shiny Checks
            int CheckCount = ShinyCharm ? 3 : 1;
            if (Boost)
                CheckCount += 4;
            if (ChainLength == 49)
                CheckCount += 5;
            else if (ChainLength == 99)
                CheckCount += 10;

            int TargetValue = 0;
            if (SearchLevel > 200)
                TargetValue = SearchLevel + 600;
            else if (SearchLevel > 100)
                TargetValue = 2 * SearchLevel + 400;
            else
                TargetValue = 6 * SearchLevel;

            for (int i = 0; i < CheckCount; i++)
                if (Rand(10000) < TargetValue * 0.01)
                    ForcedShiny = true;
        }

        private void PostCheck()
        {
            for (int i = 0; i < 5; i++)
            {
                rng.Next(); // 78B520
                rng.Next(); // 78B598
                Success = true; // To-do
                if (Success)
                    return;
            }
        }

        // Global variables
        public static bool ActiveSearch;
        public static byte EncounterType; // 0 Grass; 1 Tall Grass; 2 Surf
        public static bool HasDexNav; // DexNav mons matches encounter type
        public static int SearchLevel;
        public static int ChainLength;
        public static bool ShinyCharm;
        public static bool CompoundEyes;

        public static byte GetGrade
        {
            get
            {
                for (byte g = 0; g < 5; g++)
                    if (SearchLevel < GradeRange[g])
                        return g;
                return 5;
            }
        }

        public byte GradeRange = { 5, 10, 25, 50, 100 };
        public static sbyte[] SlotNum = { 12, 12, 5, 3 }; // Grass / Tall Grass / Surf / DexNav
        public static byte[] HARate = { 0, 0, 5, 15, 20, 25 }; // dword_7E6860[6]
        public static byte[] IVRate = // dword_7E6890[18]
        {
            0,0,0,
            10,0,0,
            15,10,0,
            20,15,5,
            15,20,5,
            10,25,10,
        };
        public static byte[] EggMoveRate = { 20, 50, 55, 60, 65, 80 }; // dword_7E6878[6]
        public static byte[] HeldItemRate = // byte_7E68D8[12]
        {
            40,10,
            40,10,
            45,15,
            50,20,
            50,20,
            50,30,
        };
    }
}
