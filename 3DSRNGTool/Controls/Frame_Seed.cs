namespace Pk3DSRNGTool
{
    public class Frame_Seed
    {
        public uint Seed { get; set; }
        public byte nature1, nature2;
        public byte gender;
        public int Frame1 { get; set; }
        public int Frame2 { get; set; }
        public string Nature1 => StringItem.naturestr[nature1];
        public string Nature2 => StringItem.naturestr[nature2];
        public string Gender => gender.ToString();
    }
}
