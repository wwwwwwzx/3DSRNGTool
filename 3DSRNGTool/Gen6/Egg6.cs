using System.Linq;
using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Egg6 : EggRNG
    {
        private static MersenneTwister mt = new MersenneTwister(19650218u);
        public static void ReSeed(uint[] key)
        {
            mt.Reseed(key);
        }
        private static uint getrand => mt.Nextuint();
        private static uint rand(uint n) => (uint)(getrand * (ulong)n >> 32);
        private static void Advance(int n) => RNGPool.Advance(n);

        public override RNGResult Generate()
        {
            EggResult egg = new EggResult();

            // Gender
            if (NidoType)
                egg.Gender = (byte)((getrand >> 31) + 1);
            else
                egg.Gender = (byte)(RandomGender ? (rand(252) >= Gender ? 1 : 2) : Gender);

            // Nature
            egg.Nature = (byte)rand(25);

            // Everstone
            // Chooses which parent if necessary;
            if (Both_Everstone)
                egg.BE_InheritParents = (getrand >> 31) == 0;
            else if (EverStone)
                egg.BE_InheritParents = MaleItem == 1;

            // Ability
            egg.Ability = (byte)getRandomAbility(InheritAbility, rand(20));

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
            }

            // Inherit IV
            int tmp;
            for (int i = Power ? 1 : 0; i < InheritIVs_Cnt; i++)
            {
                do
                {
                    tmp = (int)rand(6);
                    egg.InheritMaleIV[tmp] = egg.InheritMaleIV[tmp] ?? false;
                }
                while (egg.InheritMaleIV.Count(iv => iv != null) <= i);

                egg.InheritMaleIV[tmp] = (getrand & 1) == 0;
            }

            // IVs
            egg.IVs = new int[6];
            for (int j = 0; j < 6; j++)
            {
                egg.IVs[j] = (int)(getrand >> 27);
                if (egg.InheritMaleIV[j] == null) continue;
                egg.IVs[j] = (egg.InheritMaleIV[j] == true) ? MaleIVs[j] : FemaleIVs[j];
            }

            // Encryption Constant
            egg.EC = getrand;

            // PID
            for (int i = PID_Rerollcount; i > 0; i--)
            {
                egg.PID = getrand;
                if (egg.PSV == TSV) { egg.Shiny = true; break; }
            }

            // Other TSVs
            tmp = (int)egg.PSV;
            if (ConsiderOtherTSV && OtherTSVs.Contains(tmp))
                egg.Shiny = true;

            return egg;
        }
    }
}
