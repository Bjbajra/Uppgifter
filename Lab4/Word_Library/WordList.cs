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

        private readonly List<Word> _myWords = new List<Word>();
        public WordList(string name, params string[] languages)
        {
            Name = name;
            Languages = languages;
        }

        public static string[] GetList()
        {
            Folder.CreateFolder();
            var files = Directory.GetFiles(Folder.SelectedFolder)
                .Select(Path.GetFileNameWithoutExtension)
                .ToArray();
            return files;
        }

        public static WordList LoadList(string name)
        {
            Folder.CreateFolder();

            if (!File.Exists(Folder.GetFilePath(name.ToLower())))
            {
                var file = Folder.GetFilePath(name);
                var fStream = File.Create(file);
                fStream.Close();
            }

            using var fileReader = new StreamReader(Folder.GetFilePath(name));
            var line1 = fileReader.ReadLine();
            if (line1 == null) return null;

            var languages = line1.ToLower().Split(ChArray, StringSplitOptions.RemoveEmptyEntries);
            var wordList = new WordList(name, languages);
            var line = " ";
            while ((line = fileReader.ReadLine()) != null)
            {
                wordList.Add(line.Split(ChArray, StringSplitOptions.RemoveEmptyEntries));
            }
            fileReader.Close();
            return wordList;
        }

        public void Save()
        {
            LoadList(Name);
            var file = Folder.GetFilePath(Name);
            using var fStream = File.Create(file);
            fStream.Close();

            foreach (var lang in Languages)
            {
                if (!string.IsNullOrWhiteSpace(lang))
                {
                    File.AppendAllText(file, $"{lang};");
                }
            }

            foreach (var word in _myWords)
            {
                File.AppendAllText(file, "\n");

                for (int i = 0; i < Languages.Length; i++)
                {
                    File.AppendAllText(file, $"{word.Translations[i]};");
                }
            }
        }

        public void Add(params string[] translations)
        {
            if (translations.Length != Languages.Length) throw new ArgumentException();
            _myWords.Add(new Word(translations));
            
        }

        public bool Remove(int translations, string word)
        {
            var removeIndex = 0;
            if (_myWords.Any(i => i.Translations[translations] == word))
            {
                removeIndex = _myWords.IndexOf(_myWords.First(i => i.Translations[translations] == word));
            }

            if (_myWords.Count != 0)
            {
                _myWords.RemoveAt(removeIndex);
                Save();
                return true;
            }

            return false;
        }

        public int Count()
        {
            return _myWords.Count;
        }

        public void List(int sortByTranslations, Action<string[]> showTranslations)
        {
            var sortedTranslations = _myWords.OrderBy(x => x.Translations[sortByTranslations]).ToArray();
            LoadList(Name);
            
            foreach (var translation in sortedTranslations)
            {
                showTranslations(translation.Translations);
            }
        }

        public Word GetWordToPractice()
        {
            Random rnd = new Random();
            int randWord = rnd.Next(_myWords.Count);
            int fromLanguage = rnd.Next(Languages.Length);
            int toLanguage = rnd.Next(Languages.Length);

            while (toLanguage == fromLanguage) toLanguage = rnd.Next(Languages.Length);

            return new Word(fromLanguage, toLanguage, _myWords[randWord].Translations);
        }
    }

    public class Folder
    {
        private static string PathFolder => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static string SelectedFolder => Path.Combine(PathFolder, "lab4");

        public static void CreateFolder()
        {
            Directory.CreateDirectory(SelectedFolder);
        }

        public static string GetFilePath(string name)
        {
            return $@"{SelectedFolder}\{name}.dat";
        }
    }
}
