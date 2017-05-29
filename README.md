# 3DS RNG Tool

RNG Tool for Pokemon main series game on 3DS platform. Some parts should work with PokeClacNTR using CFW-NTR.

This tool is a complete rewrite based off my SMEncounterRNGTool with largely improved performance and the following features:
- Gen6 RNG, including stationary Pokemon, Mystery Gift Pokemon, Eggs and ID.
- Gen7 stationary, Mystery Gift and wild Pokemon RNG from my SMEncounterRNGTool.
- Gen7 egg RNG and ID RNG based on Quandra's [PokemonSunMoonRNGTool](https://github.com/Quandra/PokemonSunMoonRNGTool) 
- Nidoran line/Volbeat/Illumise gender prediction and shortest accept/reject path solution for Gen7 Egg RNG.

## User Guide and Useful References

- [Final Screen](#final-screen) you should wait at and make the final key pressing.
- [Gen VI Events Thread](https://projectpokemon.org/forums/forums/topic/39398-gen-vi-event-contribution-thread-2017/)
- [Gen VII Events Thread](https://projectpokemon.org/forums/forums/topic/39400-gen-vii-events-contribution-thread/)

## Credit

- Zaksabeast, Zap715, Real96, Admiral Fish and ShinySylveon for great teamworks on gen6 development
  Zaksabeast and Admiral Fish for building up the plugin.  
  Real96 for testing and lots of good advice.  
  Zap715 for figuring out tons of infomation from the assembly.  
  ShinySylveon for contribution to Gen6 Egg RNG.
  
- Kaphotics for PkHeX and Pk3DS. I borrowed some code from the PKHeX Core Library and extract useful info from the ROM.
- 44670 for NTRClient.

## Final Screen

Usually it's the last screen before the battle starts, or the special dialogue box.

#### Generation 6

- Pokemon Link: Would you like to retrieve data using Pokemon Link? Yes/No
- Fossils: "This is xxx! Please take good care of it."
- Kalos/Hoenn Starters: Choose this Pokemon? Yes/No
- Rock Smash: Would you like to use Rock Smash? Yes/No
- **Eggs** from Day Care: 
Accepting: "You do want it. don't you? / You'll be wanting it won't you?"  
Rejecting: "Well then, I'll hang on to it. Thank you! / Well then, I'll hang on to it. Thank you!”
- **ID** RNG: xxx... Tres bien! What a fantastic name! / So you're xxx? Yes/No

##### XY
- Mewtwo: Mew!
- Xerneas, Yveltal:
- Zygarde: Zzzz-dddd-aaaaaa!
- Kanto Legendary Birds: No dialogue.\* Press arrow key or use circle pad to run to it.\*\*
- Mystery Gift: xxx received xxx!
- Pidgey: No dialogue.\* Wait at the first line of the grass. The encounter will happen at the 2nd row of grass. Press arrow key or use circle pad to run to it.\*\*
- Kanto Starters: You picked xxx. then! I see. That's simply wonderful!
- Snorlax: Snorlax opened its eyes wide!
- Lucario: Lucario is staring intently at xxx. Will you take Lucario with you? Yes/No
- Lapras: Would you mind taking Lapras with you on your journey? Sure!/I coundn't
- Berry Tree: A Pokemon appeared!
- Shaking Trash Can: No dialogue.\*

##### Omega Ruby and Alpha Sapphire
- Portal / Hoopa Ring:  Would you like to put your hand deep in the hole? / Would you like to examine it? Yes/No
- Soaring Legends: Despite that, do you want to fly into the clouds? / Do you want to fly into the gap? Yes/No
- Storyline Latios/Latias: xxx joined your team!
- Eon Ticket Latios/Latias: Hyahhn!
- Primal Kyogre/Groudon: No dialogue.\*  (Do NOT open the wild view during the delay. The delay varies from console and save. and it should be an odd number)
- Rayquaza: Kiiiryarrrarrrarrrraaaashiiiii!!! (Tip: Wait until it finishes its movement)
- Deoxys: The stone tablet before you--!!!
- Regirock, Regice and Registeel: No dialogue.\*
- Regigigas: Zut zutt!
- Starters(Gen 2/4/5): "Yes, that one from the xxx region."
- Wrumple: No dialogue.\* Wait after the second step in grass. The encounter will happen at the 3rd steps in grass. Press arrow key or use circle pad to run to it.\*\*
- Cosplay Pikachu: "You'll really, really, really stand out if you two go on stage with matching costumes!"
- Castform/Sharpedo/Carmerupt/Gift eggs(Wynaut/Togepi): xxx recieved xxx.
- Beldum: xxx obtained a Beldum
- Spiritomb: Shahhh!
- Kecleon: The startled Pokemon attacked!
- Voltorb, Electrode: No dialogue.\*

Tip: 
 \* for consistent delay, use D-pad to move along grid  
 \*\*Hold circle pad in one direction and unpause.

#### Generation 7

##### Sun and Moon
- Tapus: Tapu ko-ko-ko-kooo!!! / Ta-pu-leeeh! / Ta-pu-loooo! / Ta-pu-fiiieee!
- Solgaleo/Lunala: No dialogue. (Tip: NPC number can be 2 or 6, depends on save)
- Zygarde: Zygarde has gone into a Poke Ball!
- UBs, Island Scan & wild Pokemon: Press A and enter the bag from X menu.
- Type:Null/Cosmog/Porygon/Aerodactyl/Magearna/Fossils/Gift Eevee egg and Mystery Gift: You received xxx!
- Crabrawler: There was a Pokemon feeding on the Berries and it leaped out at you!
- Pikipek: No dialogue. Before the fourth step in grass.
- Exeggutor: "Ahhh! What is that, xxx?!"
- Main RNG egg: "But you want the Egg your Pokemon was holding. right?"
- Starters: "Having accepted on another, you'll surely be friends for life".
