using System;

namespace Uppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Skriv ett program som frågar användaren efter ett lösenord. 
             * Hitta på ett hemligt lösenord och spara det i en variabel. 
             * När användaren har skrivit in ett ord ska programmet jämföra med det sparade lösenordet
             * och skriva ut om det var rätt eller inte. Använd en if-sats. */

            string password = "DotNet";
            //Console.WriteLine("Skriv in lösenord");
            //string input = Console.ReadLine();
            bool isCorrect = true;
            

            do
            {
                Console.WriteLine("Skriv in lösenord");
                string input = Console.ReadLine();

                if (input == password)
                {
                    Console.WriteLine($"{input} är rätt lösenord");
                    break;
                }

                else
                {
                    Console.WriteLine("Lösenord är fel, försoka igen!");
                    isCorrect = false;
                }
            } while (!isCorrect); // boolean kör till felaktig lösenord blir false d.v.s att lösenord är rätt.

        }
    }
}