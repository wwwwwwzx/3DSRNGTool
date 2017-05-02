// Copyright 2007-2008 Rory Plaire (codekaizen@gmail.com)

// Adapted from:

/* C# Version Copyright (C) 2001-2004 Akihilo Kramot (Takel).  */
/* C# porting from a C-program for MT19937, originaly coded by */
/* Takuji Nishimura and Makoto Matsumoto, considering the suggestions by */
/* Topher Cooper and Marc Rieffel in July-Aug. 1997.           */
/* This library is free software under the Artistic license:   */
/*                                                             */
/* You can find the original C-program at                      */
/*     http://www.math.keio.ac.jp/~matumoto/mt.html            */
/*                                                             */

// and:

/////////////////////////////////////////////////////////////////////////////
// C# Version Copyright (c) 2003 CenterSpace Software, LLC                 //
//                                                                         //
// This code is free software under the Artistic license.                  //
//                                                                         //
// CenterSpace Software                                                    //
// 2098 NW Myrtlewood Way                                                  //
// Corvallis, Oregon, 97330                                                //
// USA                                                                     //
// http://www.centerspace.net                                              //
/////////////////////////////////////////////////////////////////////////////

// and, of course:
/* 
   A C-program for MT19937, with initialization improved 2002/2/10.
   Coded by Takuji Nishimura and Makoto Matsumoto.
   This is a faster version by taking Shawn Cokus's optimization,
   Matthe Bellew's simplification, Isaku Wada's real version.

   Before using, initialize the state by using init_genrand(seed) 
   or init_by_array(init_key, key_length).

   Copyright (C) 1997 - 2002, Makoto Matsumoto and Takuji Nishimura,
   All rights reserved.                          

   Redistribution and use in source and binary forms, with or without
   modification, are permitted provided that the following conditions
   are met:

     1. Redistributions of source code must retain the above copyright
        notice, this list of conditions and the following disclaimer.

     2. Redistributions in binary form must reproduce the above copyright
        notice, this list of conditions and the following disclaimer in the
        documentation and/or other materials provided with the distribution.

     3. The names of its contributors may not be used to endorse or promote 
        products derived from this software without specific prior written 
        permission.

   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
   A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE COPYRIGHT OWNER OR
   CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
   EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
   PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
   PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
   LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
   NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
   SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.


   Any feedback is very welcome.
   http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html
   email: m-mat @ math.sci.hiroshima-u.ac.jp (remove space)
*/


using System;

namespace Pk3DSRNGTool.RNG
{
    /// <summary>
    ///     Generates pseudo-random numbers using the Mersenne Twister algorithm.
    /// </summary>
    /// <remarks>
    ///     See
    ///     <a href="http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html">
    ///         http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html
    ///     </a>
    ///     for details
    ///     on the algorithm.
    /// </remarks>
    public class MersenneTwister : IRNG, RNGState
    {
        /* Period parameters */
        private const Int32 N = 624;
        private const Int32 M = 397;
        private const uint MatrixA = 0x9908b0df; /* constant vector a */
        private const uint UpperMask = 0x80000000; /* most significant w-r bits */
        private const uint LowerMask = 0x7fffffff; /* least significant r bits */

        /* Tempering parameters */
        private const uint TemperingMaskB = 0x9d2c5680;
        private const uint TemperingMaskC = 0xefc60000;
        private static readonly uint[] _mag01 = { 0x0, MatrixA };
        private readonly uint[] _mt = new uint[N]; /* the array for the state vector  */
        private Int16 _mti;
        //private uint p;

        /// <summary>
        ///     Creates a new pseudo-random number generator with a given seed.
        /// </summary>
        /// <param name="seed">A value to use as a seed.</param>
        public MersenneTwister(uint seed)
        {
            init(seed);
        }

        // copy constructor
        public MersenneTwister(MersenneTwister old)
        {
            _mt = old._mt;
            _mti = old._mti;
        }

        #region IRNG Members

        public void Reseed(uint seed)
        {
            init(seed);
        }

        /// <summary>
        ///     Returns the next pseudo-random <see cref="uint" />.
        /// </summary>
        /// <returns>
        ///     A pseudo-random <see cref="uint" /> value.
        /// </returns>
        public uint Nextuint()
        {
            return Generateuint();
        }

        // Interface call
        public void Next()
        {
            uint y;

            /* _mag01[x] = x * MatrixA  for x=0,1 */
            if (_mti >= N) /* generate N words at one time */
            {
                short kk = 0;

                for (; kk < N - M; ++kk)
                {
                    y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
                    _mt[kk] = _mt[kk + M] ^ (y >> 1) ^ _mag01[y & 0x1];
                }

                for (; kk < N - 1; ++kk)
                {
                    y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
                    _mt[kk] = _mt[kk + (M - N)] ^ (y >> 1) ^ _mag01[y & 0x1];
                }

                y = (_mt[N - 1] & UpperMask) | (_mt[0] & LowerMask);
                _mt[N - 1] = _mt[M - 1] ^ (y >> 1) ^ _mag01[y & 0x1];

                _mti = 0;
            }

            _y = _mt[_mti++];
        }

        public uint _y;

        public string CurrentState() => _y.ToString("X8");

        #endregion

        /// <summary>
        ///     Generates a new pseudo-random <see cref="uint" />.
        /// </summary>
        /// <returns>
        ///     A pseudo-random <see cref="uint" />.
        /// </returns>
        protected uint Generateuint()
        {
            Next();
            uint y = _y;
            
            y ^= temperingShiftU(y);
            y ^= temperingShiftS(y) & TemperingMaskB;
            y ^= temperingShiftT(y) & TemperingMaskC;
            y ^= temperingShiftL(y);

            return y;
        }

        private static uint temperingShiftU(uint y)
        {
            return (y >> 11);
        }

        private static uint temperingShiftS(uint y)
        {
            return (y << 7);
        }

        private static uint temperingShiftT(uint y)
        {
            return (y << 15);
        }

        private static uint temperingShiftL(uint y)
        {
            return (y >> 18);
        }

        public static uint Next624(uint[] MTarray)
        {
            uint y = (MTarray[0] & 0x80000000) | (MTarray[1] & 0x7FFFFFFF);
            MTarray[0] = MTarray[397] ^ (y >> 1);
            if ((y & 1) == 1)
            {
                MTarray[0] = MTarray[0] ^ 0x9908b0df;
            }
            return MTarray[0];
        }

        public static uint[] generateArray(uint seed)
        {
            var MTarray = new uint[624];
            MTarray[0] = seed;
            for (int i = 1; i <= 623; i++)
            {
                MTarray[i] = (uint)(0x6c078965 * (MTarray[i - 1] ^ (MTarray[i - 1] >> 30)) + i) & 0xFFFFFFFF;
            }
            return MTarray;
        }

        private void init(uint seed)
        {
            _mt[0] = seed & 0xffffffffU;

            for (_mti = 1; _mti < N; _mti++)
            {
                _mt[_mti] = (uint)(1812433253U * (_mt[_mti - 1] ^ (_mt[_mti - 1] >> 30)) + _mti);
                // See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier. 
                // In the previous versions, MSBs of the seed affect   
                // only MSBs of the array _mt[].                        
                // 2002/01/09 modified by Makoto Matsumoto             
                //note: this is expensive and is probably unnessisary, look into removal later
                _mt[_mti] &= 0xffffffffU;
                // for >32 bit machines
            }
        }
    }

    public class MersenneTwisterFast : IRNG
    {
        /* Period parameters */
        private const Int32 N = 624;
        private const Int32 M = 397;
        private const uint MatrixA = 0x9908b0df; /* constant vector a */
        private const uint UpperMask = 0x80000000; /* most significant w-r bits */
        private const uint LowerMask = 0x7fffffff; /* least significant r bits */

        /* Tempering parameters */
        private const uint TemperingMaskB = 0x9d2c5680;
        private const uint TemperingMaskC = 0xefc60000;
        private const uint TemperingMaskC2 = 0xef000000;
        private static readonly uint[] _mag01 = { 0x0, MatrixA };
        private readonly uint[] _mt = new uint[N]; /* the array for the state vector  */
        private Int16 _mti;
        private int maxCalls;

        /// <summary>
        ///     Creates a new pseudo-random number generator with a given seed.
        /// </summary>
        /// <param name="seed">A value to use as a seed.</param>
        /// <param name="calls">The number of calls to make </param>
        public MersenneTwisterFast(uint seed, int calls)
        {
            maxCalls = calls;

            if (maxCalls > 227)
            {
                throw (new ArgumentOutOfRangeException(maxCalls.ToString(),
                                                       "Number of calls exceeds Fast IVRNG maximum!"));
            }
            init(seed);
        }

        #region IRNG Members

        public void Reseed(uint seed)
        {
            init(seed);
        }

        /// <summary>
        ///     Returns the next pseudo-random <see cref="uint" />.
        /// </summary>
        /// <returns>
        ///     A pseudo-random <see cref="uint" /> value.
        /// </returns>
        public uint Nextuint()
        {
            return Generateuint();
        }

        // Interface call
        public void Next()
        {
            Generateuint();
        }

        #endregion

        /// <summary>
        ///     Generates a new pseudo-random <see cref="uint" />.
        /// </summary>
        /// <returns>
        ///     A pseudo-random <see cref="uint" />.
        /// </returns>
        protected uint Generateuint()
        {
            uint y;


            /* _mag01[x] = x * MatrixA  for x=0,1 */
            if (_mti >= (M + maxCalls)) /* generate N words at one time */
            {
                Int16 kk = 0;

                for (; kk < maxCalls; ++kk)
                {
                    //y = (_mt[kk] & UpperMask) | (_mt[(kk + 1) % N] & LowerMask);
                    y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
                    _mt[kk] = _mt[(kk + M)] ^ (y >> 1) ^ _mag01[y & 0x1];
                }


                _mti = 0;
            }

            y = _mt[_mti++];


            y ^= temperingShiftU(y);
            y ^= temperingShiftS(y) & TemperingMaskB;
            y ^= temperingShiftT(y) & TemperingMaskC2;


            // removed because we only need the top 5 bits, so this is unnecessary
            //y ^= temperingShiftL(y);

            return y;
        }

        private static uint temperingShiftU(uint y)
        {
            return (y >> 11);
        }

        private static uint temperingShiftS(uint y)
        {
            return (y << 7);
        }

        private static uint temperingShiftT(uint y)
        {
            return (y << 15);
        }

        private static uint temperingShiftL(uint y)
        {
            return (y >> 18);
        }

        public static uint[] generateArray(uint seed, uint maxCalls)
        {
            var MTarray = new uint[397 + maxCalls];
            MTarray[0] = seed;
            for (int i = 1; i <= 397 + maxCalls; i++)
            {
                MTarray[i] = (uint)(0x6c078965 * (MTarray[i - 1] ^ (MTarray[i - 1] >> 30)) + i) & 0xFFFFFFFF;
            }
            return MTarray;
        }

        private void init(uint seed)
        {
            //_mt[0] = seed & 0xffffffffU;
            _mt[0] = seed;

            if (maxCalls > (N - M))
            {
                maxCalls = N - M;
            }

            int max = M + maxCalls;
            for (_mti = 1; _mti < max; ++_mti)
            {
                _mt[_mti] = (uint)(1812433253U * (_mt[_mti - 1] ^ (_mt[_mti - 1] >> 30)) + _mti);
                // See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier. 
                // In the previous versions, MSBs of the seed affect   
                // only MSBs of the array _mt[].                        
                // 2002/01/09 modified by Makoto Matsumoto

                //this should do absolutely nothing and be quite expensive, removed for now
                //tested and it appears to do nothing
                /*
                uint a = _mt[_mti];
                _mt[_mti] &= 0xffffffffU;
                uint b = _mt[_mti];
                if (a != b)
                {
                    System.Windows.Forms.MessageBox.Show(a.ToString() + " " + b.ToString());
                }*/
                // for >32 bit machines
            }
        }
    }

    public class MersenneTwisterUntempered : IRNG
    {
        /* Period parameters */
        private const Int32 N = 624;
        private const Int32 M = 397;
        private const uint MatrixA = 0x9908b0df; /* constant vector a */
        private const uint UpperMask = 0x80000000; /* most significant w-r bits */
        private const uint LowerMask = 0x7fffffff; /* least significant r bits */

        /* Tempering parameters */
        private const uint TemperingMaskB = 0x9d2c5680;
        private const uint TemperingMaskC = 0xefc60000;
        private static readonly uint[] _mag01 = { 0x0, MatrixA };
        private readonly uint[] _mt = new uint[N]; /* the array for the state vector  */
        private Int16 _mti;

        /// <summary>
        ///     Creates a new pseudo-random number generator with a given seed.
        /// </summary>
        /// <param name="seed">A value to use as a seed.</param>
        public MersenneTwisterUntempered(Int32 seed)
        {
            init((uint)seed);
        }

        #region IRNG Members

        public void Reseed(uint seed)
        {
            init(seed);
        }

        /// <summary>
        ///     Returns the next pseudo-random <see cref="uint" />.
        /// </summary>
        /// <returns>
        ///     A pseudo-random <see cref="uint" /> value.
        /// </returns>
        public uint Nextuint()
        {
            return Generateuint();
        }

        // Interface call
        public void Next()
        {
            Generateuint();
        }

        #endregion

        /// <summary>
        ///     Generates a new pseudo-random <see cref="uint" />.
        /// </summary>
        /// <returns>
        ///     A pseudo-random <see cref="uint" />.
        /// </returns>
        protected uint Generateuint()
        {
            uint y;

            /* _mag01[x] = x * MatrixA  for x=0,1 */
            if (_mti >= N) /* generate N words at one time */
            {
                Int16 kk = 0;

                for (; kk < N - M; ++kk)
                {
                    y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
                    _mt[kk] = _mt[kk + M] ^ (y >> 1) ^ _mag01[y & 0x1];
                }

                for (; kk < N - 1; ++kk)
                {
                    y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
                    _mt[kk] = _mt[kk + (M - N)] ^ (y >> 1) ^ _mag01[y & 0x1];
                }

                y = (_mt[N - 1] & UpperMask) | (_mt[0] & LowerMask);
                _mt[N - 1] = _mt[M - 1] ^ (y >> 1) ^ _mag01[y & 0x1];

                _mti = 0;
            }

            y = _mt[_mti++];

            return y;
        }

        private static uint temperingShiftU(uint y)
        {
            return (y >> 11);
        }

        private static uint temperingShiftS(uint y)
        {
            return (y << 7);
        }

        private static uint temperingShiftT(uint y)
        {
            return (y << 15);
        }

        private static uint temperingShiftL(uint y)
        {
            return (y >> 18);
        }

        private void init(uint seed)
        {
            _mt[0] = seed & 0xffffffffU;

            for (_mti = 1; _mti < N; _mti++)
            {
                _mt[_mti] = (uint)(1812433253U * (_mt[_mti - 1] ^ (_mt[_mti - 1] >> 30)) + _mti);
                // See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier. 
                // In the previous versions, MSBs of the seed affect   
                // only MSBs of the array _mt[].                        
                // 2002/01/09 modified by Makoto Matsumoto             
                _mt[_mti] &= 0xffffffffU;
                // for >32 bit machines
            }
        }
    }
}