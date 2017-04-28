namespace pkm3dsRNG
{
    public class FuncUtil
    {
        // Translate genderratio in personal table to RNGSetting format
        public static byte getGenderRatio(int genderratio)
        {
            switch (genderratio)
            {
                // random
                case 0x7F: return 126;
                case 0x1F: return 030;
                case 0x3F: return 063;
                case 0xBF: return 189;
                // fixed
                case 0x00: return 1;
                case 0xFE: return 2;
                default: return 0; //0xFF
            }
        }

        public static bool IsRandomGender(int genderratio) => 0x0F < genderratio && genderratio < 0xEF;
    }
}
