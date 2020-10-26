using System;
using Word_Library;
using System.IO;


namespace Lab4_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                string s = args[0];
            }
            Folder.CreateFolder();
            Console.WriteLine("Use any of following parameters:\n");
            Console.WriteLine("-lists");
            Console.WriteLine("-new < list name > < language 1 > < language 2 > .. < langauge n >");
            Console.WriteLine("-add < list name >");
            Console.WriteLine("-remove < list name > < language > < word 1 > < word 2 > .. < word n >");
            Console.WriteLine("-words<listname> < sortByLanguage >");
            Console.WriteLine("-count < listname >");
            Console.WriteLine("-practice<listname>\n");

            switch (Console.ReadLine().ToLower())
            {
                case "-lists":
                    var files = WordList.GetList();
                    foreach (var file in files)
                    {
                        Console.WriteLine(file);
                    }
                    break;

                case "-new":
                    Console.WriteLine("Give the name of the list and the languages used in the list");
                    var read = Console.ReadLine().ToLower().Split(' ');
                    var name = read[0];
                    var languageArray = new string[read.Length - 1];
                    for (var i = 1; i < read.Length; i++) languageArray[i - 1] = read[i];
                    var filePath = Folder.GetFilePath(name);
                    var fs = File.Create(filePath);
                    fs.Close();
                    AddWords(WordList.LoadList(name), languageArray);
                    break;

                case "-add":
                    Console.WriteLine("Write the name of the list you want to add files");
                    name = Console.ReadLine().ToLower();
                    AddWords(WordList.LoadList(name), WordList.LoadList(name).Languages);
                    break;

                case "-remove":
                    read = Console.ReadLine().ToLower().Split(' ');
                    var language = 0;
                    WordList.LoadList(read[0]);
                    for (var i = 0; i < WordList.LoadList(read[0]).Languages.Length; i++)
                    {
                        if (read[1] != WordList.LoadList(read[0]).Languages[i]) continue;
                        language = i;
                        WordList.LoadList(read[0]).Remove(language, read[2]);
                    }
                    break;

                case "-words":
                    var langugae = 0;
                    Console.WriteLine("Write the name of the list you want to print.");
                    Console.WriteLine(
                        "Choose language which you will sort by:");
                    read = Console.ReadLine().ToLower().Split(' ');
                    var sortBy = 0;

                    languageArray = WordList.LoadList(read[0]).Languages;

                    foreach (var languages in languageArray)
                    {
                        Console.Write(languages.PadLeft(20).ToUpper());
                    }

                    Console.WriteLine();
                    WordList.LoadList(read[0]).List(sortBy, x =>
                    {
                        foreach (var t in x)
                        {
                            Console.Write(t.PadLeft(20));
                        }

                        Console.WriteLine();
                    });
                    break;

                case "-count":
                    Console.WriteLine("Give the name of the list that you want to count  words");
                    name = Console.ReadLine().ToLower();

                    Console.WriteLine(WordList.LoadList(name).Count());
                    break;

                case "-practice":
                    name = Console.ReadLine().ToLower();
                    Random rnd = new Random();
                    languageArray = WordList.LoadList(name).Languages;
                    var wordlist = WordList.LoadList(name);
                    Word practice = wordlist.GetWordToPractice();
                    bool enterNotPressed = true;
                    while (enterNotPressed)
                    {
                        Console.WriteLine(
                            $"Here is the {languageArray[practice.FromLanguage]} word {practice.Translations[practice.FromLanguage]}");
                        Console.WriteLine($"Do you know the {languageArray[practice.ToLanguage]} translation?");
                        var input = Console.ReadLine().ToLower();
                        if (input == practice.Translations[practice.ToLanguage].ToLower())
                        {
                            Console.WriteLine("Wow Great!");
                        }

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            break;
                        }
                    }
                    break;
            }
            Console.ReadLine();
        }

        private static void AddWords(WordList wordList, string[] languages)
        {
            Console.WriteLine("To stop adding words, input an empty string");
            bool enterNotPressed = true;
            while (enterNotPressed)
            {
                var words = new string[languages.Length];
                for (var i = 0; i < languages.Length; i++)
                {
                    Console.WriteLine(i == 0
                        ? $"Please write the {languages[i]} word"
                        : $"Please write the {languages[i]} translation");
                    var input = Console.ReadLine().ToLower();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        wordList.Save();
                        enterNotPressed = false;
                        break;
                    }
                    words[i] = input;
                }

                if (enterNotPressed) wordList.Add(words);
            }
        }
    }
}
