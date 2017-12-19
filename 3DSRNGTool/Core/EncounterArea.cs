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
                string tmp = _mark ?? (idx > 0 ? idx.ToString() : string.Empty);
                return string.IsNullOrEmpty(tmp) ? string.Empty : $" ({tmp})";
            }
            set { _mark = value; }
        }

        public virtual bool VersionDifference { get; }
        public virtual bool DayNightDifference { get; }

        public abstract int[] Species { get; set; }
        public abstract int[] getSpecies(int ver, bool IsNight);
    }
}
