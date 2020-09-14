using System;

namespace Uppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Skriv ett program som frågar efter användarens namn och skriver ut en hälsning på konsolen.
             * Om namnet är "David" ska det skriva ut "Hej David!"*/

            /*Console.WriteLine("Vad heter du?");
            string name = Console.ReadLine();

            Console.WriteLine($"Hej {name} !");*/
            
            

            /*Uppdatera programmet i uppgift 1 så att det även frågar efter ett tal. Skriv hälsningen så många gånger som användaren anger.*/

            Console.WriteLine("Vad heter du?");
            string name = Console.ReadLine();
            Console.Write("Skriv ett tal: ");
            int num = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < num; i++)
            { 
               
                    Console.WriteLine($"Hej {name}!");
              
            }
           
            

        }
    }
}
