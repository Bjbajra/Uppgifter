using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace NewWord_Library
{
    public class WordList
    {
        public static readonly string PathFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static readonly string SpecificFolder = Path.Combine(PathFolder, "NewWord_Practice");
        public static void CreateFolder() => Directory.CreateDirectory(SpecificFolder);
        
        public static string GetFile(string name) => $@"{SpecificFolder}\{name.ToLower()}.dat";

        private readonly List<Word> _myWords = new List<Word>();

        public string Name { get; set; }
        public string[] Languages { get; }

        public WordList(string name, params string[] languages)
        {
            Name = name;
            Languages = languages;
        }

        public static string[] GetLists()
        {
            CreateFolder();
            var files = Directory.GetFiles(SpecificFolder)
                .Select(Path.GetFileNameWithoutExtension)
                .ToArray();
            return files;
        }
        public static WordList LoadList(string name)
        {
            CreateFolder();
           
            var filePath = GetFile(name);

            if (File.Exists(filePath))
            {

                using var streamReader = new StreamReader(filePath);
                var firstLine = streamReader.ReadLine();
                var languages = firstLine?.ToLower().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var wordList = new WordList(name, languages);
                string line = streamReader.ReadLine();

                while (line != null)
                {
                    var word = new Word(line.ToLower()
                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                    wordList._myWords.Add(word);
                    line = streamReader.ReadLine();

                }

                streamReader.Close();
                return wordList;
            }
            
            return null;
        }

        public void Save()
        {
            CreateFolder();
            var filePath = GetFile(Name); 

            using var streamWriter = new StreamWriter(filePath, false);
            foreach (var lang in Languages)
            {
                streamWriter.Write($"{lang.ToLower()};");
            }

            streamWriter.WriteLine();

            foreach (var word in _myWords)
            {
                foreach (var translation in word.Translations)
                {
                    streamWriter.Write($"{translation.ToLower()};");
                }

                streamWriter.WriteLine();
            }

            streamWriter.Close();

        }
        public void Add(params string[] translations)
        {
            try
            {
                var newWordTranslations = new Word(translations);
                _myWords.Add(newWordTranslations);
            }
            catch (ArgumentException exception) when (translations.Length != Languages.Length)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public bool Remove(int translations, string word)
        {
            //var removeIndex = 0;

            if (_myWords.Any(i => i.Translations[translations] == word.ToLower()))
            {
                var removeIndex = _myWords.IndexOf(_myWords.First(x => x.Translations[translations] == word.ToLower()));

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
            if (_myWords == null) return;
            var sortedTranslations = _myWords.OrderBy(x => x.Translations[sortByTranslations]).ToArray();


            foreach (var translation in sortedTranslations)
            {
                showTranslations(translation.Translations);
            }
        }
        public Word GetWordToPractice()
        {
            Random rnd = new Random();
            int randWord = rnd.Next( _myWords.Count);
            int fromLanguage = rnd.Next(Languages.Length);
            int toLanguage = rnd.Next(Languages.Length);

            while (toLanguage == fromLanguage)
            {
                toLanguage = rnd.Next(Languages.Length);
            }

            var words = new Word(fromLanguage, toLanguage, _myWords[randWord].Translations);
            return words;
        }

    }
    
}
