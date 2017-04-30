using pkm3dsRNG.Core;

namespace pkm3dsRNG
{
    public class MainRNGEgg : Result7
    {
        public byte Ball;
        public bool?[] InheritMaleIV;
        public MainRNGEgg(EggResult egg)
        {
            EC = egg.EC;
            IVs = (int[])egg.IVs.Clone();
            Ability = egg.Ability;
            Nature = egg.Nature;
            Gender = egg.Gender;
            Ball = egg.Ball;
            InheritMaleIV = (bool?[])egg.InheritMaleIV.Clone();
        }
    }
}
