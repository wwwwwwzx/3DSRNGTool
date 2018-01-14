## Introduction

![](https://i.imgur.com/TIZOP9B.png)

When you press A at the above screen:  
1. Get your previous seed from your save and initialize a new TinyMT table.
2. Use TinyMT to generate the rank up bonus you receive this time.
3. Pull another seed from main RNG (SFMT) and save to RAM, and later to your save if you save afterwards.

This means Festival Plaza facility is determined when you receive the **previous** rank up bonus. (Similar to Gen6 Egg RNG)

### Frame1: Random % 100 to determine the number of stars of the facility

| Rank  |  ★1  |  ★2  |  ★3  |  ★4  |  ★5  |
| :---: | :--: | :--: | :--: | :--: | :--: |
|  0-1  | 100% |  0%  |  0%  |  0%  |  0%  |
|   2   | 100% |  0%  |  0%  |  0%  |  0%  |
|   3   | 75%  | 19%  |  6%  |  0%  |  0%  |
|   4   | 75%  | 17%  |  8%  |  0%  |  0%  |
|   5   | 75%  | 15%  | 10%  |  0%  |  0%  |
|   6   | 50%  | 38%  | 12%  |  0%  |  0%  |
|   7   | 50%  | 36%  | 14%  |  0%  |  0%  |
|   8   | 50%  | 34%  | 16%  |  0%  |  0%  |
|   9   | 50%  | 32%  | 18%  |  0%  |  0%  |
|  10   | 40%  | 35%  | 20%  |  5%  |  0%  |
| 11-20 | 30%  | 40%  | 22%  |  7%  |  1%  |
| 21-30 | 25%  | 40%  | 24%  |  9%  |  2%  |
| 31-40 | 20%  | 35%  | 31%  | 11%  |  3%  |
| 41-50 | 15%  | 30%  | 38%  | 13%  |  4%  |
| 51-60 | 10%  | 25%  | 45%  | 15%  |  5%  |
| 61-70 | 10%  | 20%  | 47%  | 17%  |  6%  |
| 71-80 | 10%  | 15%  | 49%  | 19%  |  7%  |
| 81-90 | 10%  | 15%  | 46%  | 21%  |  8%  |
| 91-99 | 10%  | 15%  | 43%  | 23%  |  9%  |
| 100+  | 10%  | 15%  | 40%  | 25%  | 10%  |

### Frame2: Random % N to determine the type of the facility

N depends on the number of stars, i.e N = the total number of facilities which have a certain number of stars

| Rank | ★1   | ★2   | ★3   | ★4   | ★5   |
| ---- | ---- | ---- | ---- | ---- | ---- |
| Sun  | 26   | 9    | 16   | 7    | 14   |
| Moon | 26   | 8    | 17   | 6    | 15   |
| US   | 27   | 10   | 17   | 7    | 14   |
| UM   | 27   | 9    | 18   | 6    | 15   |

In the following order, starting from 0:

|      Type       |         Name          |  ★1  | ★2 (S) | ★2 (M) | ★3 (S) | ★3 (M) | ★4 (S) | ★4 (M) | ★5 (S) | ★5 (M) |
| :-------------: | :-------------------: | :--: | :----: | :----: | :----: | :----: | :----: | :----: | :----: | :----: |
|     Lottery     |      Big Dreams       |  0   |        |   0    |   0    |        |        |   0    |   0    |        |
|                 |       Gold Rush       |  1   |        |   1    |   1    |        |        |   1    |   1    |        |
|                 |     Treasure Hunt     |  2   |        |   2    |   2    |        |        |   2    |   2    |        |
|     Haunted     |      Ghosts Den       |  3   |   0    |        |        |   0    |   0    |        |        |   0    |
|                 |      Trick Room       |  4   |   1    |        |        |   1    |   1    |        |        |   1    |
|                 |      Confuse Ray      |  5   |   2    |        |        |   2    |   2    |        |        |   2    |
|      Goody      |       Ball Shop       |  6   |        |   3    |        |   3    |        |        |        |        |
|                 |     General Shop      |  7   |   3    |        |        |   4    |   3    |        |        |   3    |
|                 |      Battle Shop      |  8   |        |   4    |        |   5    |        |        |        |        |
|                 |    Soft Drink Shop    |  9   |   4    |        |   3    |        |        |        |        |        |
|                 |       Pharmacy        |  10  |   5    |        |   4    |        |        |        |        |        |
|   Food Stalls   |     Rare Kitchen      |  11  |        |   5    |   5    |        |        |   3    |   3    |        |
|                 |     Battle Table      |  12  |        |        |   6    |        |        |        |        |        |
|                 |    Friendship Cafe    |  13  |        |   6    |        |   6    |        |   4    |        |   4    |
|                 |   Friendship Parlor   |  14  |   6    |        |   7    |        |   4    |        |   4    |        |
|     Bouncy      |        Atk-SpA        |  15  |        |   7    |        |   7    |        |   5    |        |   5    |
|                 |        Def-SpD        |  16  |   7    |        |   8    |        |   5    |        |   5    |        |
|                 |        HP-Spe         |  17  |   8    |        |        |   8    |   6    |        |        |   6    |
|     Fortune     |   Kanto(M)/Johto(S)   |  18  |        |        |   9    |   9    |        |        |   6    |   7    |
|                 |  Hoenn(M)/Sinnoh(S)   |  19  |        |        |   10   |   10   |        |        |   7    |   8    |
|                 |   Unova(M)/Kalos(S)   |  20  |        |        |   11   |   11   |        |        |   8    |   9    |
|                 |        Pokemon        |  21  |        |        |        |   12   |        |        |   9    |   10   |
|       Dye       |   Red(S)/Yellow(M)    |  22  |        |        |   12   |   13   |        |        |   10   |   11   |
|                 |   Green(S)/Blue(M)    |  23  |        |        |   13   |   14   |        |        |   11   |   12   |
|                 | Orange(S)/NavyBlue(M) |  24  |        |        |   14   |   15   |        |        |   12   |   13   |
|                 |   Purple(S)/Pink(M)   |  25  |        |        |   15   |   16   |        |        |   13   |   14   |
| Exchange (USUM) |      Switcheroo       |  26  |   9    |   8    |   16   |   17   |        |        |        |        |


### Frame3: Random % 12 to determine the NPC of the facility

| Random(12) |       0/1       |     2/3     |        4/5        |      6/7      |     8/9     |      10/11      |
| :--------: | :-------------: | :---------: | :---------------: | :-----------: | :---------: | :-------------: |
|    NPC     | Ace Trainer F/M | Veteran F/M | Office Worker M/F | Punk Guy/Girl | Breeder M/F | Youngster /Lass |

### Frame4: Random % 100 to determine the color of the facility

| Color                | 3     | 2      | 1             | 0              |
| -------------------- | ----- | ------ | ------------- | -------------- |
|                      | 5%    | 15%    | 30%           | 50%            |
| Lottery Shops        | Black | Gold   | Blue          | Red            |
| Haunted Houses       | Black | Orange | Yellow(Shiny) | Purple(Normal) |
| Goody Shops          | Black | Orange | Blue          | Pink           |
| Food Stalls          | Black | Red    | Green         | Blue           |
| Bouncy Houses        | Black | Orange | Yellow        | Purple         |
| Fortune-teller Tents | Black | Yellow | Blue          | Red            |
| Exchange Centers     | Black | Orange | Blue(Shiny)   | White(Normal)  |
