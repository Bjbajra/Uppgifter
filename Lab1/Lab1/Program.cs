using System;


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skriv in en menining: ");
            string inputStr = Console.ReadLine();
            Console.WriteLine();

            char checkValue;
            long sum = 0;

            for (int i = 0; i < inputStr.Length; i++)
            {
                checkValue = inputStr[i];

                for (int j = i + 1; j < inputStr.Length; j++)
                {
                    if (!Char.IsNumber(inputStr, j)) break;

                    if (inputStr[j] == checkValue)
                    {
                        string preStr = inputStr.Substring(0, i);
                        string midStr = inputStr.Substring(i, j - i + 1);
                        string endStr = inputStr.Substring(j + 1, inputStr.Length - j - 1);

                        Console.Write(preStr);

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(midStr);
                        Console.ResetColor();

                        Console.WriteLine(endStr);

                        sum += long.Parse(midStr);
                        
                        break;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nSumman av alla delsträng är : {sum}");
            Console.ResetColor();
        }

    }
}
