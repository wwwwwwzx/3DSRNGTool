namespace Pk3DSRNGTool.Core
{
    public abstract class EncounterArea
    {
        public short Location;
        public byte idx;
        public virtual int Locationidx => Location + (idx << 8);

        private string _mark;
        public string mark
        {
            get
            {
                string tmp = _mark ?? (idx > 0 ? idx.ToString() : "");
                return tmp == "" ? "" : $" ({tmp})";
            }
            set { _mark = value; }
        }

        public virtual bool VersionDifference { get; }
        public virtual bool DayNightDifference => false;

        public abstract int[] Species { get; set; }
        public int[] getSpecies(int ver, bool IsNight)
        {
            switch (ver)
            {
                case 0:
                case 1:
                    return null; //Not impled
                case 2:
                case 3:
                    return (this as EncounterArea_ORAS).getSpecies(ver == 3, IsNight);
                case 4:
                case 5:
                    return (this as EncounterArea7).getSpecies(ver == 5, IsNight);
                default:
                    return null;
            }
        }
    }
}
