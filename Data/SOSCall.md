# SOS Call

This part of RNG use SFMT 32bits mode, reseeded when battle starts.

#### 1) Calls for help: Rand % 100 < Rate1, Pass
Rate1 =  H * AO * BCR. Rounded to the nearest multiple of 1/4096 and finally the nearest integer, capped at 100.
- H: HP Status Bonus (HP Bar Color)
  - 1/5 < HP < 1/2 (Yellow): **x3**
  - HP < 1/5 (Red): **x5**
- AO: Adrenaline Orb Bonus. If used **x2**
- [BCR](BasicCallRate.txt) : Basic call rate, depends on species and form, can be 3, 6, 9 or 15.
#### 2) Ally appears: Rand % 100 < Rate2, Pass
Rate2 = 4 * A * S1 * S2 * S3 * BCR. Rounded to the nearest multiple of 1/4096 and finally the nearest integer, capped at 100.
- A: Lead Pokemon Ability Bonus. If Ability is Intimidate / Unnerve / Pressure: **x1.2 (0x4CCC/0x4000)**
- S1: If the Pokemon called for help last turn and is calling for help this turn: **x1.5**
- S2: If the ally Pokemon that was called was hit with supereffective attack on the first turn it appeared: **x2**
- S3: If the Pokemon called for help, but none appeared, the previous turn: **x3**

#### Note: Actual Chance of SOS Call Success
Rate1 % x Rate2 %

#### 3) Lead Ability Check - Rand % 100
- **Synchronize/Static/Magnetic/Pressure/Hustle/Vital Spirit**: >= 50 Pass. < 50 Fail.
- **CuteCharm**: < 67 Pass, >=67 Fail
#### 4) If weather is active, Rand % 100 for weather slots
Each encounter area have 2 weather slots per weather (Rain, Snow, Sandstorm)
- **0**: Weather slot 1(1%), Skip next
- **1-10**: Weather slot 2(10%), Skip next
- **11-99:** Regular SOS Slot
#### 5) Regular SOS slots - Rand % 100
Slot 1-7: 1% / 1% / 1% / 10% / 10% / 10% / 67%
#### 6) Level - Rand % (max - min + 1)
#### 7) Something - Rand % 100

### Pokemon Generation from main RNG

#### 8) Held Item - Rand % 100
#### 9) Bump IVs - Rand % 6
#### 10) Hidden Ability - Rand % 100
