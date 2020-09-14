using System;

namespace Uppgift3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Skriv ett program som frågar användaren efter ett tal. Det ska skriva ut om talet är mindre än 100, lika med 100 eller större.*/

            Console.Write("Skriv in ett tal: ");
            int tal = int.Parse(Console.ReadLine());

            if (tal < 100)
            {
                Console.WriteLine($"{tal} är mindre än 100.");
            }
            else if (tal == 100)
            {
                Console.WriteLine($"{tal} är lika med 100.");
            }
            else
                Console.WriteLine($"{tal} är större än 100.");
        }
    }
}
