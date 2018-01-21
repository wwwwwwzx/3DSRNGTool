# Gen6 Memories RNG

This is a exclusive feature of generation 6 Pokemon games.

#### What does it work for

The memories of Pokemon may change over time as it has new experiences with its trainer. So it will use RNG values to determine the memory change when a new event happens.

There are 4 types of value:
- [Intensity](https://bulbapedia.bulbagarden.net/wiki/Memory_Girl#Possible_feelings)
- [Memory Type](https://bulbapedia.bulbagarden.net/wiki/Memory_Girl#Possible_memories)
- TextVar
- [Feeling](https://bulbapedia.bulbagarden.net/wiki/Memory_Girl#Possible_emotions)

#### When does it happen

- Meet legendary Pokemon
- Use an item, such as fishing rod or honey
- Soaring in the sky
- Etc.

#### What does it affect

Each Pokemon in your party will consume 3 to 4 RNG values from TinyMT, which will advance a indefinite frame number before the actual RNG process we want:

- Synchronize check of legends (Called Cut-scene Sync in TTT)
- Horde encounters because of the usage of the honey
- Fishing delays and encounters because of the usage of the fishing rod

#### How to avoid it messing other RNG process

According to the [mechanics](https://pastebin.com/h1RHL7nR), there are several ways we can do:

- Enhance the memory intensity of your party Pokemon
- Let all your party Pokemon have the same memory type as the new event.

**Note: 3DSRNGTool will assume you have already solved this issue and advance 3 frames per Pokemon.**