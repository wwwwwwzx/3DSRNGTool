namespace PKHeX.Core
{
    public class PersonalInfoSM : PersonalInfoORAS
    {
        public new const int SIZE = 0x54;
        public PersonalInfoSM(byte[] data)
        {
            if (data.Length != SIZE)
                return;
            Data = data;
        }
        public override byte[] Write()
        {
            return Data;
        }
    }
}
