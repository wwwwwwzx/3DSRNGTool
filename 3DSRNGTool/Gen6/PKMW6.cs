namespace Pk3DSRNGTool
{
    public class PKMW6 : Pokemon
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen6;
        public bool Horde { get; private set; }

        public readonly static PokemonList[] Species_XY =
        {
            new PokemonList
            {
                Text = "Normal Wild",
                List = new[]
                {
                   new PKMW6 { Species = 000, Level = 00, Conceptual = true },
                }
            },
        };

        public readonly static PokemonList[] Species_ORAS =
        {
            new PokemonList
            {
                Text = "Horde",
                List = new[]
                {
                   new PKMW6 { Species = 043, Level = 12, Horde = true, Delay = 352, },
                }
            },
        };
    }
}
