namespace Pk3DSRNGTool
{
    public enum GameVersion
    {
        // Not actually stored values, but assigned as properties.
        Any = -1,

        // Version IDs, also stored in PKM structure
        /*Gen6*/
        X = 24, Y = 25, AS = 26, OR = 27,
        /*Gen7*/
        SN = 30, MN = 31, US = 32, UM = 33,

        // Game Groupings (SaveFile type)
        XY = 106,
        ORAS = 108,
        SM = 109,
        USUM = 110,

        Gen6,
        Gen7,
    }

    public static class Extension
    {
        public static bool Contains(this GameVersion g1, GameVersion g2)
        {
            if (g1 == g2 || g1 == GameVersion.Any)
                return true;

            switch (g1)
            {
                case GameVersion.XY: return g2 == GameVersion.X || g2 == GameVersion.Y;
                case GameVersion.ORAS: return g2 == GameVersion.OR || g2 == GameVersion.AS;
                case GameVersion.Gen6:
                    return GameVersion.XY.Contains(g2) || GameVersion.ORAS.Contains(g2);

                case GameVersion.SM: return g2 == GameVersion.SN || g2 == GameVersion.MN;
                case GameVersion.USUM: return g2 == GameVersion.US || g2 == GameVersion.UM;
                case GameVersion.Gen7:
                    return GameVersion.SM.Contains(g2) || GameVersion.USUM.Contains(g2);

                default: return false;
            }
        }
    }
}
