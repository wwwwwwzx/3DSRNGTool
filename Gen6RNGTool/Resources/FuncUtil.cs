namespace Gen6RNGTool
{
    public class FuncUtil
    {
        // Translate genderratio in personal table to RNGSetting format
        public static byte getGenderRatio(int genderratio)
        {
            switch (genderratio)
            {
                // random
                case 127: return 126;
                case 031: return 030;
                case 063: return 063;
                case 191: return 189;
                // fixed
                case 0: return 1;
                case 254: return 2;
                default: return 0;
            }
        }

        public static bool IsRandomGender(int genderratio) => 10 < genderratio && genderratio < 200;
    }
}
