using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class ResultW7 : Result7, WildResult
    {
        public byte Slot { get; set; }
        public byte? SpecialVal;
        public bool IsSpecial { get; set; } //UB or QR
        public byte Item { get; set; }
        public string ItemStr { get; set; }
    }
}
