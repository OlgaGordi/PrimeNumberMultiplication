﻿using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumberMultiplication;

namespace PrimeNumberMultiplicationTest
{
    /// <summary>
    /// Test the console application displaying the multiplication table of prime numbers
    /// </summary>
    [TestClass]
    public class PrimeNumberMultiplicationTableTests
    {
        /// <summary>
        /// Name of the exe file to test
        /// </summary>
        const string FILE_NAME = "PrimeNumberMultiplication.exe";

        /// <summary>
        /// Test if the list of acceptable parameters is displayed
        /// </summary>
        [TestMethod]
        public void ShowListOfAcceptableArguments()
        {
            string actualOutput, actualError;
            Assert.AreEqual(0, StartConsoleApplication("", out actualOutput, out actualError));

            Assert.IsTrue(actualOutput.Contains("-----------------------------------------------------\r\n" +
                "Parameters:\n -numcount - prime number count. Default value is 10.\r\n" +
                "-----------------------------------------------------\n"));
        }

        /// <summary>
        /// Test if multiplication table is displayed if no arguments were specified
        /// </summary>
        [TestMethod]
        public void ShowMultiplicationTableIfNoArguments()
        {
            string actualOutput, actualError;
            Assert.AreEqual(0, StartConsoleApplication("", out actualOutput, out actualError));

            Assert.IsTrue(actualOutput.Contains("     2    3    5    7    11   13   17   19   23   29   \n\r\n" +
                "2    4    6    10   14   22   26   34   38   46   58   \r\n" +
                "3    6    9    15   21   33   39   51   57   69   87   \r\n"));
        }

        /// <summary>
        /// Test if multiplication table is displayed correctly if valid argument was specified
        /// </summary>
        [TestMethod]
        public void ShowMultiplicationTableWithValidArgument()
        {
            string actualOutput, actualError;
            Assert.AreEqual(0, StartConsoleApplication("-numcount 2", out actualOutput, out actualError));

            Assert.IsTrue(actualOutput.Contains("   2  3  \n\r\n2  4  6  \r\n3  6  9  \r\n"));
            Assert.IsTrue(!actualOutput.Contains("5    10   15   \r\n"));
        }

        /// <summary>
        /// Test if error message is displayed if value of an argument is missing
        /// </summary>
        [TestMethod]
        public void ShowErrorMessageIfMissingArgumentValue()
        {
            string actualOutput, actualError;
            Assert.AreEqual(0, StartConsoleApplication("-numcount", out actualOutput, out actualError));

            Assert.IsTrue(actualOutput.Contains(PrimeNumberMultiplication.Program.ARGUMENT_VALUE_NOT_FOUND_ERROR));
        }

        /// <summary>
        /// Test if error message is displayed if value of an argument is invalid
        /// </summary>
        [TestMethod]
        public void ShowErrorMessageIfInvalidArgumentValue()
        {
            string actualOutput, actualError;
            Assert.AreEqual(0, StartConsoleApplication("-numcount a", out actualOutput, out actualError));

            Assert.IsTrue(actualOutput.Contains(PrimeNumberMultiplication.Program.INVALID_ARGUMENT_VALUE_ERROR));
        }

        /// <summary>
        /// Start the application and return the output or error
        /// </summary>
        /// <param name="arguments">Arguments as a string</param>
        /// <param name="actualOutput">The output generated by the application</param>
        /// <param name="actualError">The error message generated by the application</param>
        /// <returns>Exit code of an application</returns>
        private int StartConsoleApplication(string arguments, out string actualOutput, out string actualError)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = FILE_NAME;
            proc.StartInfo.Arguments = arguments;

            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;

            proc.StartInfo.WorkingDirectory = Environment.CurrentDirectory;

            proc.Start();
            proc.WaitForExit();

            actualOutput = proc.StandardOutput.ReadToEnd();
            actualError = proc.StandardError.ReadToEnd();

            return proc.ExitCode;
        }
    }
}
