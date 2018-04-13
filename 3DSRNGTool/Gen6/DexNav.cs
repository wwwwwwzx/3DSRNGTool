using System;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class DexNav
    {
        // Result
        public bool Triggered => FluteBoost > 0;
        public byte AdditionalDelay;
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
            
            if (!Trigger())
                return;

            // Do 4 times check, adds 2 delay if fail once.
            for (; AdditionalDelay < 8; AdditionalDelay += 2)
                for (int i = 0; i < 5; i++)
                    if (FindPatch())
                        goto Found;

            return;

            Found: Generate();
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
            for (int i = 0; i < 3; i++) // 0x76E8C4 0x76E8E0 0x76E8EC
                rng.Next();
            return true;  // To-do
        }

        public DexNav Generate()
        {
            // Something
            rng.Next();

            // Boost
            bool Boost = ChainLength > 0 && (ChainLength + 1) % 5 == 0 || Rand(100) < 4;  // sub_40295C
            byte Grade = GetGrade;

            // Sync
            Lead = (byte)Rand(100);

            // Something
            for (int i = 0; i < 12; i++)
                if (Rand(100) < 30)
                    break;
            rng.Next();

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

        // Global variables
        public static int SearchLevel;
        public static int ChainLength;
        public static bool ShinyCharm;
        public static bool CompoundEyes;

        public static byte GetGrade
        {
            get
            {
                if (SearchLevel < 5)
                    return 0;
                if (SearchLevel < 10)
                    return 1;
                if (SearchLevel < 25)
                    return 2;
                if (SearchLevel < 50)
                    return 3;
                if (SearchLevel < 100)
                    return 4;
                return 5;
            }
        }

        public static byte[] HARate = { 0, 0, 5, 15, 20, 25 };
        public static byte[] IVRate =
        {
            0,0,0,
            10,0,0,
            20,15,5,
            15,20,5,
            10,25,10,
        };
        public static byte[] EggMoveRate = { 20, 50, 55, 60, 65, 80 };
        public static byte[] HeldItemRate =
        {
            40,10,
            40,10,
            45,15,
            50,20,
            50,20,
            50,20,
        };
    }
}
