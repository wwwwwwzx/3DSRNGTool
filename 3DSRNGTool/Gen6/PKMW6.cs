namespace Pk3DSRNGTool
{
    public class PKMW6 : Pokemon
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen6;
        public override short Delay { get; protected set; } // to-do

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
                Text = "Normal Wild",
                List = new[]
                {
                   new PKMW6 { Species = 000, Level = 00, Conceptual = true },
                }
            },
        };
    }
}
