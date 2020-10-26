using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Word_Library
{
    public class WordList
    {
        public string Name { get; }
        public string[] Languages { get; }

        private static readonly char[] ChArray = { ';' };

        private readonly List<Word> myWords = new List<Word>();
        public WordList(string name, params string[] languages)
        {
            Name = name;
            Languages = languages;
        }

        public static string[] GetList()
        {
            var files = Directory.GetFiles(Folder.SpecificFolder)
                .Select(Path.GetFileNameWithoutExtension)
                .ToArray();
            return files;
        }

        public static WordList LoadList(string name)
        {
            if (!File.Exists(Folder.GetFilePath(name.ToLower())))
            {
                var file = Folder.GetFilePath(name);
                var fStream = File.Create(file);
                fStream.Close();
            }

            var fileReader = new StreamReader(Folder.GetFilePath(name));
            var line1 = fileReader.ReadLine();
            if (line1 == null) return null;

            var languages = line1.Split(ChArray, StringSplitOptions.RemoveEmptyEntries);
            var wordList = new WordList(name, languages);
            var line = " ";
            while ((line = fileReader.ReadLine()) != null)
            {
                wordList.Add(line.Split(ChArray, StringSplitOptions.RemoveEmptyEntries));
            }
            return wordList;
        }

        public void Save()
        {
            var file = Folder.GetFilePath(Name);
            var fStream = File.Create(file);
            fStream.Close();
            LoadList(Name);

            foreach (var lang in Languages)
            {
                File.AppendAllText(file, $"{lang}");
            }

            foreach (var word in myWords)
            {
                File.AppendAllText(file, $"\n");

                for (int i = 0; i < Languages.Length; i++)
                {
                    File.AppendAllText(file, $"{word.Translations[i]};");
                }
            }
        }

        public void Add(params string[] translations)
        {
            try
            {
                if (translations.Length != Languages.Length)
                {
                    myWords.Add(new Word());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool Remove(int translations, string word)
        {
            var remove_Index = 0;
            if (myWords.Any(i => i.Translations[translations] == word))
            {
                remove_Index = myWords.IndexOf(myWords.First(i => i.Translations[translations] == word));
            }

            myWords.RemoveAt(remove_Index);
            Save();
            return true;
        }

        public int Count()
        {
            return myWords.Count;
        }

        public void List(int sortByTranslations, Action<string[]> showTranslations)
        {
            var sortedTranslations = myWords.OrderBy(x => x.Translations[sortByTranslations]).ToArray();
            LoadList(Name);
            
            foreach (var translation in sortedTranslations)
            {
                showTranslations(translation.Translations);
            }
        }

        public Word GetWordToPractice()
        {
            Random rnd = new Random();
            int randomWord = rnd.Next(myWords.Count);
            int fromLanguage = rnd.Next(Languages.Length);
            int toLanguage = rnd.Next(Languages.Length);

            while (toLanguage == fromLanguage)
            {
                toLanguage = rnd.Next(Languages.Length);
            }

            Word word = new Word(rnd.Next(Languages.Length),
                rnd.Next(Languages.Length), myWords[randomWord].Translations);
            return word;

        }
    }

    public class Folder
    {
        private static string PathFolder => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static string SpecificFolder => Path.Combine(PathFolder, "Lab4");

        public static void CreateFolder()
        {
            Directory.CreateDirectory(SpecificFolder);
        }

        public static string GetFilePath(string name)
        {
            return $@"{SpecificFolder}\{name}.dat";
        }
    }
}
