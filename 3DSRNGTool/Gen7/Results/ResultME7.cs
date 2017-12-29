using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class ResultME7 : Result7
    {
        public static EggResult Egg;
        
        public override byte Ability => Egg.Ability;
        public override byte Nature => Egg.Nature;
        public override byte Gender => Egg.Gender;

        public byte Ball => Egg.Ball;
        public bool?[] InheritMaleIV => Egg.InheritMaleIV;
        public ResultME7()
        {
            EC = Egg.EC;
            IVs = (int[])Egg.IVs.Clone();
        }
    }
}
