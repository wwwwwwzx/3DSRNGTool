using System.Linq;
using pkm3dsRNG.Core;

namespace pkm3dsRNG
{
    class Egg7 : EggRNG
    {
        private static uint getrand => RNGPool.getrand;
        private static void Advance(int n) => RNGPool.Advance(n);

        public bool Homogeneous;

        public override void MarkItem()
        {
            EverStone = MaleItem == 1 || FemaleItem == 1;
            Both_Everstone = MaleItem == 1 && FemaleItem == 1;
            DestinyKnot = MaleItem == 2 || FemaleItem == 2;
            Power = MaleItem > 2 || FemaleItem > 2;
            Both_Power = MaleItem > 2 && FemaleItem > 2;
            M_Power = (byte)(MaleItem - 3);
            F_Power = (byte)(FemaleItem - 3);

            PID_Rerollcount = 0;
            if (ShinyCharm)
                PID_Rerollcount += 2;
            if (MMethod)
                PID_Rerollcount += 6;

            InheritIVs_Cnt = (byte)(DestinyKnot ? 5 : 3);
        }

        public override RNGResult Generate()
        {
            EggResult egg = new EggResult();

            // Gender
            egg.Gender = (byte)(RandomGender ? ((int)(getrand % 252) >= Gender ? 1 : 2) : Gender);

            // Nature
            egg.Nature = (byte)(getrand % 25);

            // Both_Everstone
            // Chooses which parent if necessary;
            if (Both_Everstone)
                egg.BE_InheritParents = (getrand & 1) == 0;
            else if (EverStone)
                egg.BE_InheritParents = MaleItem == 1;

            // Ability
            egg.Ability = (byte)getRandomAbility(InheritAbilty, getrand % 100);

            // PowerItem
            // Chooses which parent if necessary
            if (Both_Power)
            {
                if ((getrand & 1) == 0)
                    egg.InheritMaleIV[M_Power] = true;
                else
                    egg.InheritMaleIV[F_Power] = false;
            }
            else if (Power)
            {
                if (MaleItem > 2)
                    egg.InheritMaleIV[M_Power] = true;
                else
                    egg.InheritMaleIV[F_Power] = false;
            };

            // IVs
            int tmp;
            for (int i = Both_Power ? 1 : 0; i < InheritIVs_Cnt; i++)
            {
                do
                {
                    tmp = (byte)(getrand % 6);
                    egg.InheritMaleIV[tmp] = false;
                }
                while (egg.InheritMaleIV.Count(iv => iv != null) <= i);

                egg.InheritMaleIV[tmp] = (getrand & 1) == 0;
            }

            // IVs
            egg.IVs = new int[] { -1, -1, -1, -1, -1, -1 };
            for (int j = 0; j < 6; j++)
                egg.IVs[j] = (int)(getrand & 0x1F);
            for (int j = 0; j < 6; j++)
            {
                if (egg.InheritMaleIV[j] == null) continue;
                egg.IVs[j] = (egg.InheritMaleIV[j] ?? false) ? MaleIVs[j] : FemaleIVs[j];
            }

            // Encryption Constant
            egg.EC = getrand;

            // PID
            for (int i = PID_Rerollcount; i > 0; i--)
            {
                egg.PID = getrand;
                if (egg.PSV == TSV)
                {
                    egg.Shiny = true;
                    break;
                }
            }

            // Ball Inheritance
            if (Homogeneous)
                egg.Ball = (byte)(getrand % 100 >= 50 ? 1 : 2);

            Advance(2);

            return egg;
        }

        private static int getRandomAbility(int ability, uint value)
        {
            switch (ability)
            {
                case 0:
                    return value < 80 ? 1 : 2;
                case 1:
                    return value < 20 ? 1 : 2;
                case 2:
                    if (value < 20) return 1;
                    if (value < 40) return 2;
                    return 3;
            }
            return 0;
        }
    }
}
