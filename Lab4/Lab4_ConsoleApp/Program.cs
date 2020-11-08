using System;
using System.IO;
using System.Linq;
using Word_Library;


namespace Lab4_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine("Use any of following parameters:\n");
                Console.WriteLine("-lists");
                Console.WriteLine("-new < list name > < language 1 > < language 2 > .. < language n >");
                Console.WriteLine("-add < list name >");
                Console.WriteLine("-remove < list name > < language > < word 1 > < word 2 > .. < word n >");
                Console.WriteLine("-words<list name> < sortByLanguage >");
                Console.WriteLine("-count < list name >");
                Console.WriteLine("-practice<list name>\n");
            }
            else
            {

                switch (Input(args)[0])
                {
                    case "-lists":
                        var files = WordList.GetList();
                        foreach (var file in files)
                        {
                            if (WordList.LoadList(file) != null)
                            {
                                Console.WriteLine(file);
                            }
                        }

                        break;

                    case "-new":
                        string name = args[1];

                        if (File.Exists(WordList.GetList() + name + ".dat"))
                        {
                            Console.WriteLine($"{name} already exists! Give new name.");
                            return;
                        }

                        if (args.Length < 4)
                        {
                            Console.WriteLine(
                                $"Add at  least two languages to languages, you added{args.Length - 2}");
                            break;
                        }

                        var arrayOfLanguage = new string[args.Length - 2];
                        for (int i = 2; i < args.Length; i++)
                        {
                            arrayOfLanguage[i - 2] = args[i];
                        }

                        WordList wordList = new WordList(name, arrayOfLanguage);
                        wordList.Save();
                        AddWords(name, arrayOfLanguage);
                        break;

                    case "-add":
                        name = args[1];

                        if (WordList.LoadList(name) == null)
                        {
                            Console.WriteLine("List does not exists!");
                        }
                        else
                        {
                            AddWords(name, WordList.LoadList(name).Languages);
                        }
                        break;

                    case "-remove":
                        int deleteLanguage = 0;
                        var list = WordList.LoadList(args[1]);
                        if (list == null)
                        {
                            Console.WriteLine("List does not exists!");
                        }

                        else
                        {
                            for (int i = 0; i < list.Languages.Length; i++)
                            {
                                if (list.Languages[i] == args[2])
                                {
                                    deleteLanguage = i;
                                }
                            }

                            for (int i = 3; i < args.Length; i++)
                            {
                                Console.WriteLine(
                                    list.Remove(deleteLanguage, args[i])
                                        ? $"The {list.Languages[deleteLanguage]} word {args[i]} was removed\n"
                                        : "Nothing was removed\n");
                            }
                        }
                        break;

                    case "-words":
                        if (WordList.LoadList(args[1]) == null)
                        {
                            Console.WriteLine("List does not exists!\n");
                        }

                        else
                        {
                            var sortByTranslations = 0;
                            arrayOfLanguage = WordList.LoadList(args[1]).Languages;
                            if (args.Length > 2)
                            {
                                for (int i = 0; i < arrayOfLanguage.Length; i++)
                                {
                                    if (args.Length > 1 && args[2] == arrayOfLanguage[i])
                                        sortByTranslations = i;
                                }
                            }

                            foreach (var languages in arrayOfLanguage)
                            {
                                Console.Write(languages.PadRight(20).ToUpper());
                            }

                            Console.WriteLine();
                            WordList.LoadList(args[1]).List(sortByTranslations, x =>
                            {
                                foreach (var text in x)
                                {
                                    Console.Write(text.PadRight(20));
                                }

                                Console.WriteLine();
                            });
                        }

                        break;

                    case "-count":
                        name = args[1];
                        Console.WriteLine(WordList.LoadList(name) == null 
                            ? "List does not exists!\n"
                            :$"{WordList.LoadList(name).Count()} words in the list '{name}'\n");
                        break;

                    case "-practice":
                        name = args[1];
                        if (WordList.LoadList(name) != null)
                        {
                            arrayOfLanguage = WordList.LoadList(name).Languages;
                            wordList = WordList.LoadList(name);
                            if (wordList.Count() != 0)
                            {
                                var isRunning = true;
                                var score = 0;
                                var attempts = 0;
                                while (isRunning)
                                {
                                    var practiceWord = wordList.GetWordToPractice();
                                    Console.Write(
                                        $"Translate the  {arrayOfLanguage[practiceWord.FromLanguage]} word {practiceWord.Translations[practiceWord.FromLanguage]}" +
                                        $" to {arrayOfLanguage[practiceWord.ToLanguage]} translation: ");
                                    var input = Console.ReadLine().ToLower();

                                    if (input == practiceWord.Translations[practiceWord.ToLanguage].ToLower())
                                    {
                                        Console.WriteLine("Wow great! Correct answer!");
                                        score++;
                                        attempts++;
                                    }

                                    else if (!string.IsNullOrWhiteSpace(input))
                                    {
                                        Console.WriteLine("The answer is wrong!");
                                        attempts++;
                                    }

                                    if (!string.IsNullOrWhiteSpace(input)) continue;
                                    Console.WriteLine($"Your score is  {score} out of {attempts}");
                                    Console.WriteLine($"{(score * 100 / attempts)}% of your answers were correct.\n");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("This list is empty.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Given list does not exists!\n");
                        }
                        break;
                }
            }
        }
        private static void AddWords(string name, string[] languages)
        {
            Console.WriteLine("Press enter(empty line) to stop adding new words.\n");
            WordList list = WordList.LoadList(name);
            bool isRunning = true;
            while (isRunning)
            {
                var words = new string[languages.Length];
                for (int i = 0; i < languages.Length; i++)
                {
                    Console.Write(i == 0
                        ? $"Add new word {languages[i]}: "
                        : $"Add {languages[i]} translation: ");
                    var input = Console.ReadLine().ToLower();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        list.Save();
                        isRunning = false;
                        break;
                    }
                    words[i] = input;
                }
                if (isRunning) list.Add(words);
               
            }
            //Console.WriteLine($"{list.ToString().Count()} word was added to list '{name}'\n");
        }

        private static string[] Input(string[] args)
        {
            var userInput = args;
            for (var i = 0; i < args.Length; i++)
            {
                userInput[i] = args[i].ToLower();
            }
            return userInput;
        }
    }
}
