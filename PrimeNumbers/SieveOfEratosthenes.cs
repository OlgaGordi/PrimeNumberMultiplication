using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbers
{
    /// <summary>
    /// Generates the list of prime numbers based on sieve of Eratosthenes
    /// </summary>
    public static class SieveOfEratosthenes
    {
        /// <summary>
        /// Returns the list of prime numbers with specified length
        /// </summary>
        /// <param name="count">Number of elements in the list</param>
        /// <returns>List of prime numbers</returns>
        public static List<ulong> GetPrimeNumbers(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("Count parameter cannot be negative number.");
            }

            if (count == 0)
            {
                return new List<ulong>();
            }

            ulong limit = ApproximateNthPrime(count);
            bool[] notPrime = GeneratePrimesSieveOfEratosthenes(limit);
            List<ulong> primes = new List<ulong>();
            int found = 0;
            for (ulong i = 0; i < (ulong)notPrime.Length && found < count; i++)
            {
                if (!notPrime[i])
                {
                    primes.Add(i);
                    found++;
                }
            }
            return primes;
        }

        /// <summary>
        /// Finds appriximate prime number
        /// </summary>
        /// <param name="n">index of the prime number</param>
        /// <returns>Approximate prime number</returns>
        public static ulong ApproximateNthPrime(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("N parameter cannot be negative number.");
            }

            double fn = (double)n;
            double flogn, flog2n, upper;

            flogn = Math.Log(n);
            flog2n = Math.Log(flogn);

            if (n >= 688383)
            {
                upper = fn * (flogn + flog2n - 1.0 + ((flog2n - 2.00) / flogn));
            }
            else if (n >= 178974)
            {
                upper = fn * (flogn + flog2n - 1.0 + ((flog2n - 1.95) / flogn));
            }
            else if (n >= 39017)
            {
                upper = fn * (flogn + flog2n - 0.9484);
            }
            else if (n >= 7022)
            {
                upper = fn * (flogn + 0.6000 * flog2n);
            }
            else if (n >= 6)
            {
                upper = n * flogn + n * flog2n;
            }
            else if (n > 0)
            {
                upper = new int[] { 2, 3, 5, 7, 11 }[n - 1];
            }
            else
            {
                upper = 0;
            }

            // check for overflow
            if (upper >= (double)ulong.MaxValue)
            {
                throw new ArgumentException("Prime number upper limit overflow.");
            }

            return (ulong)upper;
        }

        /// <summary>
        /// Returns the array of booleans representing IsNotPrime values
        /// </summary>
        /// <param name="limit">Upper limit of prime number candidates</param>
        /// <returns>Array of boolean values</returns>
        public static bool[] GeneratePrimesSieveOfEratosthenes(ulong limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException("Limit parameter cannot be negative or zero.");
            }

            bool[] notPrimeArray = new bool[limit + 1];
            notPrimeArray[0] = true;
            notPrimeArray[1] = true;

            for (ulong i = 2; i * i <= limit; i++)
            {
                if (!notPrimeArray[i])
                {
                    for (ulong j = i * i; j <= limit; j += i)
                    {
                        notPrimeArray[j] = true;
                    }
                }
            }
            return notPrimeArray;
        }
    }
}
