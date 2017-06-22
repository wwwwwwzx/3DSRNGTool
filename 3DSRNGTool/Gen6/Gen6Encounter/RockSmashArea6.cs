using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class RockSmashArea6 : EncounterArea
    {
        public override int Locationidx => Location + (idx << 9);
        public override int[] Species { get; set; } = new int[5];
        public byte[] Level = new byte[5];

    }
}
