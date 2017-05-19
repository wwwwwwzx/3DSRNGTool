namespace Pk3DSRNGTool.Core
{
    public class EggResult : RNGResult
    {
        public int FramesUsed;
        public uint RandNum;
        public ulong? EggSeed;
        public string Status;
        public bool?[] InheritMaleIV = new bool?[6]; //null random; T male; F female
        public bool? BE_InheritParents; //Both Everstone
        public byte Ball;
    }
}