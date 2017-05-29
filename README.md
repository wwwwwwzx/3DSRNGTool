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
  Zaksabeast and Admiral Fish for building up the plugin 
  Real96 for testing and lots of good advice 
  Zap715 for figuring out tons of infomation from the assembly 
  ShinySylveon for contribution to Gen6 Egg RNG
  
- Kaphotics for PkHeX and Pk3DS. I borrowed some code from the PKHeX Core Library and extract useful info from the ROM.
- 44670 for NTRClient.

## Final Screen

Usually it's the last screen before the battle starts, or the special dialogue box.

#### Generation 6

- Pokemon Link: _Would you like to retrieve data using Pokemon Link? Yes/No_
- Fossils: _This is xxx! Please take good care of it._
- Kalos/Hoenn Starters: _Choose this Pokemon? Yes/No_
- Rock Smash: _Would you like to use Rock Smash? Yes/No_
- **Mystery Gift**: _xxx received xxx!_
- **Eggs** from Day Care: 
Accepting: _You do want it. don't you? / You'll be wanting it won't you?_  
Rejecting: _Well then, I'll hang on to it. Thank you! / Well then, I'll hang on to it. Thank you!_
- **ID** : _xxx... Tres bien! What a fantastic name! / So you're xxx? Yes/No_

##### XY
- Mewtwo: _Mew!_
- Xerneas, Yveltal: _Xshaa!/Ygaaa!_
- Zygarde: _Zzzz-dddd-aaaaaa!_
- Kanto Legendary Birds: No dialogue.\* Press arrow key or use circle pad to run to it.\*\*
- Pidgey: No dialogue.\* Wait at the first line of the grass. The encounter will happen at the 2nd row of grass. Press arrow key or use circle pad to run to it.\*\*
- Kanto Starters: _You picked xxx. then! I see. That's simply wonderful!_
- Snorlax: _Snorlax opened its eyes wide!_
- Lucario: _Lucario is staring intently at xxx. Will you take Lucario with you? Yes/No_
- Lapras: _Would you mind taking Lapras with you on your journey? Sure!/I coundn't_
- Berry Tree: _A Pokemon appeared!_
- Shaking Trash Can: No dialogue.\*

##### Omega Ruby and Alpha Sapphire
- Portal / Hoopa Ring: _Would you like to put your hand deep in the hole? / Would you like to examine it? Yes/No_
- Soaring Legends: _Despite that, do you want to fly into the clouds? / Do you want to fly into the gap? Yes/No_
- Storyline Latios/Latias: _xxx joined your team!_
- Eon Ticket Latios/Latias: _Hyahhn!_
- Primal Kyogre/Groudon: No dialogue.\*  (Do NOT open the wild view during the delay. The delay varies from console and save. and it should be an odd number)
- Rayquaza: _Kiiiryarrrarrrarrrraaaashiiiii!!!_ (Tip: Wait until it finishes its movement)
- Deoxys: _The stone tablet before you--!!!_
- Regirock, Regice and Registeel: No dialogue.\*
- Regigigas: _Zut zutt!_
- Starters(Gen 2/4/5): _Yes, that one from the xxx region._
- Wrumple: No dialogue.\* Wait after the second step in grass. The encounter will happen at the 3rd steps in grass. Press arrow key or use circle pad to run to it.\*\*
- Cosplay Pikachu: _You'll really, really, really stand out if you two go on stage with matching costumes!_
- Castform/Sharpedo/Carmerupt/Gift eggs(Wynaut/Togepi): _xxx recieved xxx._
- Beldum: _xxx obtained a Beldum_
- Spiritomb: _Shahhh!_
- Kecleon: _The startled Pokemon attacked!_
- Voltorb, Electrode: No dialogue.\*

##### Tip: 
 \* for consistent delay, use D-pad to move along grid.   
 \*\*For PokeCalcNTR User, hold circle pad in one direction and unpause.

#### Generation 7

##### Sun and Moon
- Tapus: _Tapu ko-ko-ko-kooo!!! / Ta-pu-leeeh! / Ta-pu-loooo! / Ta-pu-fiiieee!_
- Solgaleo/Lunala: No dialogue. (Tip: NPC number can be 2 or 6, depends on save)
- Zygarde: _Zygarde has gone into a Poke Ball!_
- UBs, Island Scan & wild Pokemon: Press A and enter the bag from X menu.
- Type:Null/Cosmog/Porygon/Aerodactyl/Magearna/Fossils/Gift Eevee egg and Mystery Gift: _You received xxx!_
- Crabrawler: _There was a Pokemon feeding on the Berries and it leaped out at you!_
- Pikipek: No dialogue. Before the fourth step in grass.
- Exeggutor: _Ahhh! What is that, xxx?!_
- Main RNG egg: _But you want the Egg your Pokemon was holding. right?_
- Starters: _Having accepted on another, you'll surely be friends for life"._
