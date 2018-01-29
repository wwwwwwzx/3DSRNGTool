using System;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public static class DexNav
    {
        public static DexNavResult Generate(TinyMT rng)
        {
            var rt = new DexNavResult();

            // Patch?
            for (int i = 0; i < 6; i++)
                rng.Next();

            // Something
            rng.Next();

            // Boost
            bool Boost = ChainLength > 0 && (ChainLength + 1) % 5 == 0 || (rng.Nextuint() * 100ul) >> 32 < 4;  // sub_40295C
            byte Grade = GetGrade;

            // Sync
            rt.Lead = (byte)((rng.Nextuint() * 100ul) >> 32);

            // Something
            rng.Next();

            // Level
            rt.LevelBoost = ChainLength / 5 + (Boost ? 10 : 0);
            rt.FluteBoost = Wild6.getFluteBoost((rng.Nextuint() * 100ul) >> 32);

            // Hidden Ability
            rt.HA = ((rng.Nextuint() * 100ul) >> 32) < HARate[Grade];

            // IVs
            int Index;
            for (Index = 2; Index >= 0; Index--)
                if (((rng.Nextuint() * 100ul) >> 32) < IVRate[3 * Grade + Index])
                    break;
            Index += Boost ? 2 : 1;
            rt.Potential = (byte)Math.Min(3, Index);

            // Egg Move
            rt.EggMove = ((rng.Nextuint() * 100ul) >> 32) < EggMoveRate[Grade] || Boost;

            // Held Item
            int tmp = (int)((rng.Nextuint() * 100ul) >> 32);
            for (Index = 0; Index < 2; Index++)
            {
                tmp -= HeldItemRate[Grade * 2 + Index];
                if (CompoundEyes)
                    tmp -= 5;
                if (tmp < 0)
                    break;
            }
            rt.HeldItem = (byte)Index;

            // Shiny Checks
            int CheckCount = ShinyCharm ? 3 : 1;
            if (Boost)
                CheckCount += 4;
            if (ChainLength == 50)
                CheckCount += 5;
            else if (ChainLength == 100)
                CheckCount += 10;

            int TargetValue = 0;
            if (SearchLevel > 200)
                TargetValue = SearchLevel + 600;
            else if (SearchLevel > 100)
                TargetValue = 2 * SearchLevel + 400;
            else
                TargetValue = 6 * SearchLevel;

            for (int i = 0; i < CheckCount; i++)
                if (((rng.Nextuint() * 10000ul) >> 32) < TargetValue * 0.01)
                    rt.ForcedShiny = true;

            return rt;
        }

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
