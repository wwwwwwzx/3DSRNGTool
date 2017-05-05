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

        public byte[] SlotLevel;
        public bool CompoundEye;

        public override RNGResult Generate()
        {
            ResultW6 rt = new ResultW6();

            rt.Synchronize = rand(100) >= 50;
            rt.Slot = getslot((int)rand(100)); //to-do
            rt.Level = SlotLevel[rt.Slot];
            Advance(1);

            rt.Synchronize &= Synchro_Stat < 25;

            Advance(60);

            //Encryption Constant
            rt.EC = getrand;

            //PID
            for (int i = 0; i < PIDroll_count; i++)
            {
                rt.PID = getrand;
                if (rt.PSV == TSV)
                    break;
            }
            rt.Shiny = rt.PSV == TSV;

            //IV
            rt.IVs = new int[6];
            while (rt.IVs.Count(iv => iv == 31) < PerfectIVCount)
                rt.IVs[(int)(getrand % 6)] = 31;
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] == 0)
                    rt.IVs[i] = (int)(getrand >> 27);

            //Ability
            rt.Ability = (byte)((getrand >> 31) + 1);

            //Nature
            rt.Nature = (byte)(rt.Synchronize ? Synchro_Stat : rand(25));

            //Gender
            rt.Gender = (byte)(RandomGender[slot] ? (rand(252) >= Gender[slot] ? 1 : 2) : Gender[slot]);

            //Item
            rt.Item = (byte)rand(100);
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
                PersonalInfo info = PersonalTable.ORAS.getFormeEntry(SpecForm[i] & 0x7FF, SpecForm[i] >> 11);
                byte genderratio = (byte)info.Gender;
                IV3[i] = info.EggGroups[0] == 0xF;
                Gender[i] = FuncUtil.getGenderRatio(genderratio);
                RandomGender[i] = FuncUtil.IsRandomGender(genderratio);
            }
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
