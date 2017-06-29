namespace Pk3DSRNGTool
{
    public enum EncounterType
    {
        SingleSlot,
        Horde,
        RockSmash,
        TrashCan,
        PokeRadar,
        FriendSafari,
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
                    new PKMW6 { Species = 000, Conceptual = true, Type = EncounterType.Horde, Delay = 352 },
                }
            },
            new PokemonList
            {
                Text = "Rock Smash",
                List = new[]
                {
                    new PKMW6 { Species = 000, Conceptual = true, Type = EncounterType.RockSmash, Delay = 284 },
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
            new PokemonList
            {
                Text = "Poke Radar",
                List = new[]
                {
                   new PKMW6 { Species = 000, Conceptual = true, Type = EncounterType.PokeRadar, Delay = 14 },
                }
            },
            new PokemonList
            {
                Text = "Friend Safari",
                List = new[]
                {
                   new PKMW6 { Species = 000, Conceptual = true, Type = EncounterType.FriendSafari, Delay = 6 },
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
                   new PKMW6 { Species = 000, Conceptual = true, Type = EncounterType.Horde, Delay = 352 },
                }
            },
            new PokemonList
            {
                Text = "Rock Smash",
                List = new[]
                {
                   new PKMW6 { Species = 000, Conceptual = true, Type = EncounterType.RockSmash, Delay = 280 },
                }
            },
        };

        public readonly static PokemonList[] Species_VC =
        {
            new PokemonList
            {
                Text = "None",
                List = new[]
                {
                   new PKMW6 { Species = 000, Conceptual = true },
                }
            },
        };
    }
}
