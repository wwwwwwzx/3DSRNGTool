namespace Pk3DSRNGTool.Core
{
    public abstract class WildRNG : IGenerator
    {
        public int TSV;
        public byte TRV;
        public bool ShinyCharm;
        public byte Synchro_Stat;
        public bool Static;
        public bool Magnet;
        public bool StaticMagnet => Magnet || Static;
        public byte[] StaticMagnetSlot;
        public ulong NStaticMagnetSlot;
        public byte CuteCharmGender;
        public byte ModifiedLevel;

        protected abstract void CheckLeadAbility(ulong rand100);
        protected bool SynchroPass;
        protected bool CuteCharmPass;
        protected bool StaticMagnetPass;
        protected bool LevelModifierPass;

        public sbyte Flute;         // +1/-1/0
        public byte FluteBoost;

        public byte[] SlotSplitter;
        public int[] SpecForm;

        // Store personal info in memory
        protected byte[] Gender;
        protected bool[] RandomGender;
        protected bool[] IV3;
        protected byte slot;

        protected virtual int PerfectIVCount => IV3[slot] ? 3 : 0;
        protected virtual int PIDroll_count { get; }

        public virtual void Delay() { }
        public abstract RNGResult Generate();
        public abstract void Markslots();

        protected byte getslot(int rand)
        {
            for (byte i = 1; i < SlotSplitter.Length; i++)
            {
                rand -= SlotSplitter[i - 1];
                if (rand < 0)
                    return slot = i;
            }
            return slot = (byte)SlotSplitter.Length;
        }

        public static byte getSlot(int rand, byte SlotType)
        {
            var SlotSplitter = SlotDistribution[SlotType];
            for (byte i = 1; i < SlotSplitter.Length; i++)
            {
                rand -= SlotSplitter[i - 1];
                if (rand < 0)
                    return i;
            }
            return (byte)SlotSplitter.Length;
        }

        public readonly static byte[][] SlotDistribution = new byte[][]
        {
            new byte[] { 20,20,10,10,10,10,10,5,4,1 }, //SuMo Normal
            new byte[] { 10,10,20,20,10,10,10,5,4,1 }, //SuMo Poni Plains
            new byte[] { 10,10,10,10,10,10,10,10,10,5,4,1 }, // Gen6
            new byte[] { 60,35,5 }, // Horde / Fishing
            new byte[] { 50,30,15,4,1 }, // Rock Smash

            // Fishing USUM
            new byte[] { 90,10 }, // 5              - Seaward Cave, Paniola Town
            new byte[] { 40,60 },
            new byte[] { 35,35,05,25, }, // 7       - Kala'e Bay
            new byte[] { 25,25,35,15, },
            new byte[] { 25,25,25,05,05,15, }, // 9 - Melemele Sea (Hau’oli City Beachfront)
            new byte[] { 15,15,15,35,05,15, },
            new byte[] { 44,30,01,25, }, // 11      - Brooklet Hill
            new byte[] { 40,25,10,25, },
            new byte[] { 55,40,05 }, // 13          - Brooklet Hill (Totem), Seafolk Village, Akala Outskirts, Routes 13, 14
            new byte[] { 40,25,35, },
            new byte[] { 50,30,05,15 }, // 15       - Route 8
            new byte[] { 40,20,35,05 },
            new byte[] { 20,15,50,15 }, // 17       - Route 9
            new byte[] { 10,05,80,05 },
            new byte[] { 50,40,05,05 }, // 19       - Route 15
            new byte[] { 20,10,35,35 },
            new byte[] { 45,25,05,25 }, // 21       - Vast Poni Canyon USUM
            new byte[] { 25,20,35,20 },
            new byte[] { 59,40,01 }, // 23          - Poni Meadow SMUSUM, Poni Gauntlet SMUSUM, Vast Poni Canyon SM
            new byte[] { 50,40,10 },

            // Fishing SM
            new byte[] { 99,01, }, // 25            - Seaward Cave, Paniola Town
            new byte[] { 50,50, },
            new byte[] { 79,20,01, }, // 27         - Kala'e Bay, Brooklet Hill (Totem), Secluded Shore, Routes 13, 14, 15
            new byte[] { 50,30,20, },
            new byte[] { 78,20,01,01, }, // 29      - Melemele Sea (Hau’oli City Beachfront)
            new byte[] { 20,20,40,20, },
            new byte[] { 70,29,01, }, // 31         - Brooklet Hill
            new byte[] { 50,45,05, },
            new byte[] { 79,20,01, }, // 33         - Routes 7, 8, Akala Outskirts
            new byte[] { 60,20,20, },
            new byte[] { 15,10,70,05 }, // 35       - Route 9
            new byte[] { 15,10,70,05 },
            new byte[] { 79,20,01, }, // 37         - Seafolk Village, Poni Wilds, Poni Breaker Coast
            new byte[] { 50,40,10, },

            // SOS
            new byte[] { 1,1,1,10,10,10,67, }, //39

            // Others
            new byte[] { 70,30, }, // 40
            new byte[] { 80,20, }, // 41
            new byte[] { 100, }, // 42
            new byte[] { 50,15,30,5, }, // 43
            new byte[] { 70,20,10, }, // 44
            new byte[] { 70,10,20 }, // 45

            // Missing Fishing
            new byte[] { 40,30,25,05, }, // 46      - Malie Garden USUM
            new byte[] { 30,20,15,35, },
            new byte[] { 60,40 }, // 48             - Malie Garden SM
            new byte[] { 50,50 },
            new byte[] { 55,40,05 }, // 50          - Route 7 USUM
            new byte[] { 45,20,35 },
            new byte[] { 49,40,10,01 }, // 52       - Poni Breaker Coast USUM
            new byte[] { 40,30,20,10 },

            // FS XY 1.5 sub_74BED4
            new byte[] { 50,50 }, // 54
            new byte[] { 34,33,33 },
        };

        public static byte getFluteBoost(ulong Rand100)
        {
            if (Rand100 < 40)
                return 1;
            if (Rand100 < 70)
                return 2;
            if (Rand100 < 90)
                return 3;
            return 4;
        }
        public void ModifyLevel(RNGResult rt, int levelboost = 0)
        {
            if (LevelModifierPass)
                rt.Level = ModifiedLevel;
            levelboost += Flute * FluteBoost;
            if (levelboost == 0)
                return;
            var level = rt.Level + levelboost;
            if (level > 100)
                level = 100;
            else if (level < 1)
                level = 1;
            rt.Level = (byte)level;
        }
    }
}
