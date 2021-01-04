using System;
using System.IO;
using System.Linq;
//using Word_Library;
using NewWord_Library;

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
                        var files = WordList.GetLists();
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

                        if (File.Exists(WordList.GetLists() + name + ".dat"))
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

                        var languageList = new string[args.Length - 2];
                        for (int i = 2; i < args.Length; i++)
                        {
                            languageList[i - 2] = args[i];
                        }

                        WordList wordList = new WordList(name, languageList);
                        wordList.Save();
                        AddWords(wordList);
                        break;

                    case "-add":
                        name = args[1];

                        if (WordList.LoadList(name) == null)
                        {
                            Console.WriteLine("List does not exists!");
                        }
                        else
                        {
                            AddWords(WordList.LoadList(name));
                        }
                        break;

                    case "-remove":
                        var deleteLanguage = 0;
                        var list = WordList.LoadList(args[1]);
                        if (args.Length >= 2 && list == null)
                        {
                            Console.WriteLine("List does not exists!");
                        }

                        else if (args.Length > 2 && list != null)
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
                            languageList = WordList.LoadList(args[1]).Languages;
                            if (args.Length > 2)
                            {
                                for (int i = 0; i < languageList.Length; i++)
                                {
                                    if (args.Length > 1 && args[2] == languageList[i])
                                        sortByTranslations = i;
                                }
                            }

                            foreach (var languages in languageList)
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
                            languageList = WordList.LoadList(name).Languages;
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
                                        $"Translate the  {languageList[practiceWord.FromLanguage]} word {practiceWord.Translations[practiceWord.FromLanguage]}" +
                                        $" to {languageList[practiceWord.ToLanguage]} translation: ");
                                    var input = Console.ReadLine().ToLower();

                                    if (input == practiceWord.Translations[practiceWord.ToLanguage].ToLower())
                                    {
                                        Console.WriteLine("Wow great! Correct answer!");
                                        score++;
                                        attempts++;
                                    }

                                    else if (!string.IsNullOrWhiteSpace(input))
                                    {
                                        Console.WriteLine($"The answer is wrong! The correct translation is {practiceWord.Translations[practiceWord.ToLanguage].ToLower()}");
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
        private static void AddWords(WordList wordList)
        {

            Console.WriteLine("Press enter(empty line) to stop adding new words.\n");
            bool isRunning = true;

            do
            {
                var words = new string[wordList.Languages.Length];
                for (int i = 0; i < wordList.Languages.Length; i++)
                {
                    Console.Write(i == 0
                        ? $"Add new word {wordList.Languages[i]}: "
                        : $"Add {wordList.Languages[i]} translation: ");
                    words[i] = Console.ReadLine().ToLower();
                    isRunning = (words[i] == "");
                    if (isRunning) break;

                }

                if (!isRunning) wordList.Add(words);
                wordList.Save();
            } while (isRunning == false);

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
