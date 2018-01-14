namespace PKHeX.Core
{
    public class PersonalInfoUSUM : PersonalInfoORAS
    {
        public new const int SIZE = 0x54;
        public PersonalInfoUSUM(byte[] data)
        {
            if (data.Length != SIZE)
                return;
            Data = data;
        }
        public byte CallRate => EscapeRate;
    }
}
