# SOS Call

[Basic Call Rate (BCR)](BasicCallRate.txt) : Depends on species, can be 3, 6, 9 or 15.

All RNG use SFMT 32bits mode.

#### Call 1: Rand % 100 < Rate1, Pass

Rate1 =  H * AO * BCR. Round to integer, capped at 100.

- H: HP Status Bonus (HP Bar Color)
  - Green: **x1**
  - Yellow: **x3**
  - Red: **x5**
- AO: Adrenaline Orb Bonus
  - If used: **x2**
  - If not: **x1**

#### Call 2: Rand % 100 < Rate2, Pass

Rate2 = A * S1 * S2 * S3 * BCR. Round to integer, capped at 100

- A: Lead Pokemon Ability Bonus
  - If Ability is Intimidate / Unnerve / Pressure: **x4.8**
  - Otherwise: **x4**
- S1: If the Pokemon called for help last turn and is calling for help this turn **x1.5**
- S2: If the ally Pokemon that was called was hit with supereffective attack on the first turn it appeared **x2**
- S3: If the Pokemon called for help, but none appeared, the previous turn **x3**

- If the Pokemon called for help last turn and is calling for help this turn x1.5

#### Note: Actual Chance of SOS Call Success

Rate1 % x Rate2 %

#### Lead Ability Check - Rand % 100

- **Synchronize/Static/Magnetic/Pressure**: >= 50 Pass. < 50 Fail.
- **CuteCharm**: < 67 Pass, >=67 Fail

#### If weather is active, Rand % 100 for weather slots

Each encounter area have 2 weather slots per weather (Rain, Snow, Sandstorm)

- **0**: Weather slot 1(1%), Skip next

- **1-10**: Weather slot 2(10%), Skip next

- **11-99:** Regular SOS Slot

#### Regular SOS slots - Rand % 100
Slot 1-7: 1% / 1% / 1% / 10% / 10% / 10% / 67%

#### Level - Rand % (max - min + 1)

#### Something - Rand % 100

### Pokemon Generation from main RNG

#### Held Item - Rand % 100

#### Bump IVs - Rand % 6

#### Hidden Ability - Rand % 100







