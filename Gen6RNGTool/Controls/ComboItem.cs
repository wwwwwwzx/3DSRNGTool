namespace SMEncounterRNGTool.Controls
{
    class ComboItem
    {
        public ComboItem(string str , int v)
        {
            Text = str;
            Value = v;
        }
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString() => Text;
    }
}
