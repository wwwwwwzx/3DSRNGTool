using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class ResultW6 : Result6, WildResult
    {
        public byte Slot { get; set; }
        public bool IsSpecial { get; set; }
        public byte Item { get; set; }
        public string ItemStr { get; set; }
        public bool IsPokemon;
    }
}
