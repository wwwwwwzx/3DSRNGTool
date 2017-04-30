namespace pkm3dsRNG
{
    public class ResultW7 : Result7, Core.WildResult
    {
        public byte Slot { get; set; }
        public bool IsSpecial { get; set; } //UB or QR
        public byte Item { get; set; }
        public string ItemStr { get; set; }
    }
}
