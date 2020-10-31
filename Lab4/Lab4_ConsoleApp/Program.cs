using System;
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
                        AddWords(name, WordList.LoadList(name).Languages);
                        break;

                    case "-remove":
                        int language = 0;
                        WordList.LoadList(args[1]);
                        for (int i = 0; i < WordList.LoadList(args[1]).Languages.Length; i++)
                        {
                            if (args[2] != WordList.LoadList(args[1]).Languages[i]) continue;
                            language = i;
                        }

                        for (int i = 3; i < args.Length; i++)
                        {
                            WordList.LoadList(args[1]).Remove(language, args[i]);
                            Console.WriteLine(
                                WordList.LoadList(args[1]).Remove(language, args[i])
                                    ? $"The {WordList.LoadList(args[1]).Languages[language]} word {args[i]} was removed"
                                    : "Nothing was removed");
                        }
                        break;

                    case "-words":
                        var sortBy = 0;
                        arrayOfLanguage = WordList.LoadList(args[1]).Languages;
                        if (args.Length > 2)
                        {
                            for (int i = 0; i < arrayOfLanguage.Length; i++)
                            {
                                if (args.Length > 1 && args[2] == arrayOfLanguage[i])
                                    sortBy = i;
                            }
                        }

                        foreach (var languages in arrayOfLanguage)
                        {
                            Console.Write(languages.PadRight(20).ToUpper());
                        }

                        Console.WriteLine();
                        WordList.LoadList(args[1]).List(sortBy, x =>
                        {
                            foreach (var text in x)
                            {
                                Console.Write(text.PadRight(20));
                            }

                            Console.WriteLine();
                        });
                        break;

                    case "-count":
                        name = args[1];
                        Console.WriteLine(name != null
                            ? $"{WordList.LoadList(name).Count()} words in the list '{name}'\n"
                            : "The given list does not exists.\n");
                        break;

                    case "-practice":
                        name = args[1];
                        if (WordList.LoadList(name) != null)
                        {
                            arrayOfLanguage = WordList.LoadList(name).Languages;
                            wordList = WordList.LoadList(name);
                            if (wordList.Count() != 0)
                            {
                                var enterNotPressed = true;
                                var score = 0;
                                var attempts = 0;
                                while (enterNotPressed)
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
                                    Console.WriteLine($"{(score * 100 / attempts)}% of your answers were correct.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("This list is empty.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Given list does not exists!");
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
            Console.WriteLine($"{list.Count()} word was added to list '{name}'");
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
