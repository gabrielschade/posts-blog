using System;
using System.Collections.Generic;

namespace IEnumerableSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            InfinityNumbersList allNumbers = new InfinityNumbersList();
            using (IEnumerator<int> enumerator = allNumbers.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    int value = enumerator.Current;
                    Console.WriteLine(value);

                    if (value >= 100)
                        break;
                }
            }

            foreach (int number in allNumbers)
            {
                Console.WriteLine(number);

                if (number >= 100)
                    break;
            }

            Console.ReadKey();
        }
    }
}
