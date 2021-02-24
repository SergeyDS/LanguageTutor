using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LanguageTutor
{
    public class WordStorage
    {
        private const string _path = "wordstorage.txt";
        public Dictionary<string, string> GetAllWords()
        {
            var dic = new Dictionary<string, string>();
            if (File.Exists(_path))
            {
                foreach (var line in File.ReadAllLines(_path))
                {
                    var words = line.Split('|');
                    if (words.Length == 2)
                    {
                        dic.Add(words[0], words[1]);
                    }
                }
            }
            return dic;
        }

        public void AddWord(string eng, string rus)
        {
            using (var writer = new StreamWriter(_path, true))
            {
                writer.WriteLine($"{eng}|{rus}");
            }
        }
    }
}
