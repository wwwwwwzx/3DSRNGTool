namespace Pk3DSRNGTool
{
    public enum EncounterType
    {
        SingleSlot,
        Horde,
        RockSmash,
        TrashCan,
    }

    public class PKMW6 : Pokemon
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen6;
        public EncounterType Type { get; private set; } = EncounterType.SingleSlot;

        public readonly static PokemonList[] Species_XY =
        {
            new PokemonList
            {
                Text = "Horde",
                List = new[]
                {
                   new PKMW6 { Species = 041, Level = 14, Delay = 352, Type = EncounterType.Horde,},
                }
            },
            new PokemonList
            {
                Text = "Rock Smash",
                List = new[]
                {
                    new PKMW6 { Species = 557, Level = 20, Delay = 284, }, // Dwebble
                    new PKMW6 { Species = 075, Level = 20, Delay = 284, }, // Graveler
                    new PKMW6 { Species = 095, Level = 20, Delay = 284, }, // Onix
                    new PKMW6 { Species = 688, Level = 20, Delay = 284, }, // Binacle
                    new PKMW6 { Species = 213, Level = 20, Delay = 284, }, // Shuckle
                    new PKMW6 { Species = 218, Level = 20, Delay = 284, }, // Slugma
                }
            },
            new PokemonList
            {
                Text = "Trash Can",
                List = new[]
                {
                    new PKMW6 { Species = 568, Level = 35, Delay = 18 }, // Trubbish
                    new PKMW6 { Species = 569, Level = 35, Delay = 18 }, // Garbodor
                    new PKMW6 { Species = 354, Level = 35, Delay = 18 }, // Banette
                    new PKMW6 { Species = 479, Level = 38, Delay = 18 }, // Rotom
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
                   new PKMW6 { Species = 043, Level = 12, Delay = 352, Type = EncounterType.Horde,},
                }
            },
            new PokemonList
            {
                Text = "Rock Smash",
                List = new[]
                {
                    new PKMW6 { Species = 074, Level = 20, Delay = 280, }, // Geodude
                    new PKMW6 { Species = 075, Level = 20, Delay = 280, }, // Graveler
                    new PKMW6 { Species = 299, Level = 20, Delay = 280, }, // Nosepass
                    new PKMW6 { Species = 688, Level = 20, Delay = 280, }, // Binacle
                    new PKMW6 { Species = 525, Level = 20, Delay = 280, }, // Boldore
                    new PKMW6 { Species = 558, Level = 20, Delay = 280, }, // Crustle
                }
            },
        };
    }
}
