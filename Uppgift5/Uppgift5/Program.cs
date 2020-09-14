using System;

namespace Uppgift5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Skriv ett program som upprepade gånger frågar användaren efter ett tal
             * ända till man skriver något som inte är ett tal (t.ex bara trycker enter).
             * Efter varje inmatning ska summan av alla tal som matats in skrivas ut, innan nästa inmatning efterfrågas. 
             * Innan programmet avslutas ska man även skriva ut medelvärde av de inmatade talen. Hint: TryParse() */

            bool isRunning; 
            double sum = 0;
            int countNum = 0;


            do
            {
                Console.Write("Skriv ett tal: ");
                isRunning = Int32.TryParse(Console.ReadLine(), out int number);
                sum += number;
                Console.WriteLine($"Summan av alla tal är: {sum}");
                if (isRunning) countNum++;

            } while (isRunning == true);

            Console.WriteLine($"Medelvärde av de inmatade talen är: {sum / countNum}");
            
        }
    }
}
