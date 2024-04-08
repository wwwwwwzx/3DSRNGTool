namespace Pk3DSRNGTool
{
    public enum EncounterType
    {
        Horde,
        RockSmash,
        PokeRadar,
        FriendSafari,
        CaveShadow,
        Trap,
        Fishing,
        Normal,
        DexNav,
    }

    public class PKMW6 : Pokemon
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen6;
        public EncounterType Type { get; private set; }

        public readonly static PokemonList[] Species_XY =
        {
            new PokemonList
            {
                Text = "Normal Wild",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.Normal, Delay = 6 },
                }
            },
            new PokemonList
            {
                Text = "Horde",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.Horde, Delay = 174 },
                }
            },
            new PokemonList
            {
                Text = "Rock Smash",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.RockSmash, Delay = 280 },
                }
            },
            new PokemonList
            {
                Text = "Fishing",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Species = 129, Type = EncounterType.Fishing, Delay = 14 }, // OldRod
                    new PKMW6 { Conceptual = true, Species = 349, Type = EncounterType.Fishing, Delay = 14 }, // GoodRod
                    new PKMW6 { Conceptual = true, Species = 130, Type = EncounterType.Fishing, Delay = 14 }, // SuperRod
                }
            },
            new PokemonList
            {
                Text = "Poke Radar",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.PokeRadar, Delay = 14 },
                }
            },
            new PokemonList
            {
                Text = "Friend Safari",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.FriendSafari, Delay = 6 },
                }
            },
            new PokemonList
            {
                Text = "Cave Shadows",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.CaveShadow, Delay = 78, },
                }
            },
            new PokemonList
            {
                Text = "Trap",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.Trap, Delay = 32, },
                }
            }
        };

        public readonly static PokemonList[] Species_ORAS =
        {
            new PokemonList
            {
                Text = "Normal Wild",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.Normal, Delay = 6 },
                }
            },
            new PokemonList
            {
                Text = "Horde",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.Horde, Delay = 174 },
                }
            },
            new PokemonList
            {
                Text = "Rock Smash",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.RockSmash, Delay = 280 },
                }
            },
            new PokemonList
            {
                Text = "Fishing",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Species = 129, Type = EncounterType.Fishing, Delay = 14 }, // OldRod
                    new PKMW6 { Conceptual = true, Species = 349, Type = EncounterType.Fishing, Delay = 14 }, // GoodRod
                    new PKMW6 { Conceptual = true, Species = 130, Type = EncounterType.Fishing, Delay = 14 }, // SuperRod
                }
            },
            new PokemonList
            {
                Text = "DexNav",
                List = new[]
                {
                    new PKMW6 { Conceptual = true, Type = EncounterType.DexNav, Delay = 14 },
                }
            },

        };
    }
}
