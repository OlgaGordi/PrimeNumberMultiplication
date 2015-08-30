using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeNumbers;

namespace PrimeNumberMultiplication
{
    /// <summary>
    /// Console application displaying the multiplication table of prime numbers
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Error message to display if argument value is missing
        /// </summary>
        public const string ARGUMENT_VALUE_NOT_FOUND_ERROR = "Value of -numcount parameter not found.\n";

        /// <summary>
        /// Error message to display if argument value is invalid
        /// </summary>
        public const string INVALID_ARGUMENT_VALUE_ERROR = "Value of -numcount parameter is not an integer.\n";

        /// <summary>
        /// Count of prime numbers to include in the table
        /// </summary>
        const string COUNT_PARAM = "-numcount";

        /// <summary>
        /// Default value of -numcount parameter
        /// </summary>
        const int DEFAULT_COUNT = 10;

        /// <summary>
        /// Console application displaying the multiplication table of prime numbers
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Parameters:\n -numcount - prime number count. Default value is " + DEFAULT_COUNT + ".");
            Console.WriteLine("-----------------------------------------------------\n");

            int count = DEFAULT_COUNT;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case COUNT_PARAM:
                        int customCount;
                        if (args.Length < i + 2)
                        {
                            Console.WriteLine(ARGUMENT_VALUE_NOT_FOUND_ERROR);
                        }
                        else if (!int.TryParse(args[i + 1], out customCount))
                        {
                            Console.WriteLine(INVALID_ARGUMENT_VALUE_ERROR);
                        }
                        else
                        {
                            count = customCount;
                        }
                        break;
                }
            }

            BuildTable(count);
        }

        /// <summary>
        /// Builds the multiplication table of prime numbers
        /// </summary>
        /// <param name="count">Count of prime numbers</param>
        private static void BuildTable(int count)
        {
            List<ulong> primeNums = PrimeNumbers.SieveOfEratosthenes.GetPrimeNumbers(count);
            if (primeNums.Count == 0)
            {
                return;
            }

            int width = (primeNums.Last() * primeNums.Last()).ToString().Length + 2;

            var sb = new StringBuilder();

            // build header
            sb.Append(string.Empty.PadRight(width));
            foreach (var num in primeNums)
            {
                sb.Append(num.ToString().PadRight(width));
            }

            sb.Append("\n");
            Console.WriteLine(sb.ToString());

            // build body
            for (int i = 0; i < primeNums.Count; i++)
            {
                sb.Clear();
                // start from -1 for the first cell with prime number
                for (int j = -1; j < primeNums.Count; j++)
                {
                    if (j == -1)
                    {
                        sb.Append(primeNums.ElementAt(i).ToString().PadRight(width));
                    }
                    else
                    {
                        ulong result = primeNums.ElementAt(i) * primeNums.ElementAt(j);
                        sb.Append(result.ToString().PadRight(width));
                    }
                }

                Console.WriteLine(sb.ToString());
            }
        }
    }
}
