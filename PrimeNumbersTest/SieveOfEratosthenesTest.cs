using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumbers;

namespace PrimeNumbersTest
{
    /// <summary>
    /// Testing of prime number generator
    /// </summary>
    [TestClass]
    public class SieveOfEratosthenesTest
    {
        #region GetPrimeNumbers tests

        /// <summary>
        /// Generate the list of prime numbers containing 0 elements
        /// </summary>
        [TestMethod]
        public void GetPrimeNumbersTestWithZeroCount()
        {
            var primeList = PrimeNumbers.SieveOfEratosthenes.GetPrimeNumbers(0);
            Assert.AreEqual(0, primeList.Count);
        }

        /// <summary>
        /// Generate the list of prime numbers containing negative number of elements
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Count parameter cannot be negative number.")]
        public void GetPrimeNumbersTestWithNegativeCount()
        {
            var primeList = PrimeNumbers.SieveOfEratosthenes.GetPrimeNumbers(-10);
        }

        /// <summary>
        /// Generate the list of prime numbers containing 10 elements
        /// </summary>
        [TestMethod]
        public void GetPrimeNumbersTest()
        {
            var primeList = PrimeNumbers.SieveOfEratosthenes.GetPrimeNumbers(10);
            Assert.AreEqual(10, primeList.Count);
        }

        #endregion

        #region ApproximateNthPrime tests

        /// <summary>
        /// Find approximate 0th prime
        /// </summary>
        [TestMethod]
        public void Approximate0thPrime()
        {
            var prime = PrimeNumbers.SieveOfEratosthenes.ApproximateNthPrime(0);
            Assert.IsTrue(prime == 0);
        }

        /// <summary>
        /// Test method with negative n
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "N parameter cannot be negative number.")]
        public void ApproximateNthPrimeWithNegativeN()
        {
            var prime = PrimeNumbers.SieveOfEratosthenes.ApproximateNthPrime(-10);
        }

        /// <summary>
        /// Find approximate 5th prime
        /// </summary>
        [TestMethod]
        public void Approximate5thPrime()
        {
            var prime = PrimeNumbers.SieveOfEratosthenes.ApproximateNthPrime(5);
            Assert.IsTrue(prime >= 11);
        }

        /// <summary>
        /// Find approximate 6th prime
        /// </summary>
        [TestMethod]
        public void Approximate6thPrime()
        {
            var prime = PrimeNumbers.SieveOfEratosthenes.ApproximateNthPrime(6);
            Assert.IsTrue(prime >= 13);
        }

        /// <summary>
        /// Find approximate 7022th prime
        /// </summary>
        [TestMethod]
        public void Approximate7022thPrime()
        {
            var prime = PrimeNumbers.SieveOfEratosthenes.ApproximateNthPrime(7022);
            Assert.IsTrue(prime >= 70919);
        }

        /// <summary>
        /// Find approximate 39017th prime
        /// </summary>
        [TestMethod]
        public void Approximate39017thPrime()
        {
            var prime = PrimeNumbers.SieveOfEratosthenes.ApproximateNthPrime(39017);
            Assert.IsTrue(prime >= 467473);
        }

        /// <summary>
        /// Find approximate 178974th prime
        /// </summary>
        [TestMethod]
        public void Approximate178974thPrime()
        {
            var prime = PrimeNumbers.SieveOfEratosthenes.ApproximateNthPrime(178974);
            Assert.IsTrue(prime >= 2439889);
        }

        /// <summary>
        /// Find approximate 688383th prime
        /// </summary>
        [TestMethod]
        public void Approximate688383thPrime()
        {
            var prime = PrimeNumbers.SieveOfEratosthenes.ApproximateNthPrime(688383);
            Assert.IsTrue(prime >= 10384261);
        }

        #endregion

        #region GeneratePrimesSieveOfEratosthenes tests

        /// <summary>
        /// Generate sieve with the highest prime number candidate equaling 0
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Limit parameter cannot be negative or zero.")]
        public void GeneratePrimesSieveOfEratosthenesWithZeroLimit()
        {
            bool[] notPrime = PrimeNumbers.SieveOfEratosthenes.GeneratePrimesSieveOfEratosthenes(0);
        }

        /// <summary>
        /// Generate sieve with the highest prime number candidate equaling 1
        /// </summary>
        [TestMethod]
        public void GeneratePrimesSieveOfEratosthenesWith1Limit()
        {
            List<bool> expectedValue = new List<bool>(new bool[] { true, true });
            bool[] notPrime = PrimeNumbers.SieveOfEratosthenes.GeneratePrimesSieveOfEratosthenes(1);
            List<bool> actualValue = new List<bool>(notPrime);
            CollectionAssert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        /// Generate sieve with the highest prime number candidate equaling 5
        /// </summary>
        [TestMethod]
        public void GeneratePrimesSieveOfEratosthenes()
        {
            List<bool> expectedValue = new List<bool>(new bool[] { true, true, false, false, true, false });
            bool[] notPrime = PrimeNumbers.SieveOfEratosthenes.GeneratePrimesSieveOfEratosthenes(5);
            List<bool> actualValue = new List<bool>(notPrime);
            CollectionAssert.AreEqual(expectedValue, actualValue);
        }

        #endregion
    }
}
