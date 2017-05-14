using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class MainRNGEgg : Result7
    {
        private EggResult Egg;
        
        public override byte Ability => Egg.Ability;
        public override byte Nature => Egg.Nature;
        public override byte Gender => Egg.Gender;

        public byte Ball => Egg.Ball;
        public bool?[] InheritMaleIV => Egg.InheritMaleIV;
        public MainRNGEgg(EggResult egg)
        {
            Egg = egg;
            EC = egg.EC;
            IVs = (int[])egg.IVs.Clone();
        }
    }
}
