using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TextAnalyticsMVCCoreBootstrap.Models;
using TextAnalyticsMVCCoreBootstrap.MostFrequentChars;

namespace TextAnalyticsMVCCoreBootstrap.MostFrequentChars
{
    public class MostFrequentChar<T> : IAlgoritm<AnswerModel<int>>
    {
                
        public AnswerModel<int> Execute(string text)
        {
            return GetMostFrequentChar(text);
        }
               

        public void PrintWordOccurrenceCount(IDictionary<string, int> wordOccurrenceMap)
        {
            StreamWriter writer = new StreamWriter("output.txt");

            using (writer)

                foreach (KeyValuePair<string, int> wordEntry in wordOccurrenceMap)
                {
                    writer.WriteLine("{0},{1}", wordEntry.Key, wordEntry.Value);
                }
            Console.WriteLine(@"The document is generated. Please check the file ""output.txt"".");
            Console.ReadKey();
        }

        public IDictionary<string, int> GetWordOccurrenceMap(string text)
        {
            string[] tokens = text.Split(' ', '.', ',', '-', '?', '!', '<', '>', '&', '[', ']', '(', ')');
            IDictionary<string, int> words = new SortedDictionary<string, int>(new CaseInsensitiveComparer());
            foreach (string word in tokens)
            {
                if (string.IsNullOrEmpty(word.Trim()))
                {
                    continue;
                }
                int count;
                if (!words.TryGetValue(word, out count))
                {
                    count = 0;
                }
                words[word] = count + 1;
            }
            return words;
        }

        public AnswerModel<int> GetMostFrequentChar(string text)
        {
            string[] tokens = text.Split(' ', '.', ',', '-', '?', '!', '<', '>', '&', '[', ']', '(', ')');
            IDictionary<string, int> words = new SortedDictionary<string, int>(new CaseInsensitiveComparer());
            foreach (string word in tokens)
            {
                if (string.IsNullOrEmpty(word.Trim()))
                {
                    continue;
                }
                int count;
                if (!words.TryGetValue(word, out count))
                {
                    count = 0;
                }
                words[word] = count + 1;
            }

            var keyOfMaxValue = words.Aggregate((x, y) => x.Value > y.Value ? x : y).Key; 
            
            AnswerModel<int> answer = new AnswerModel<int>();
            //answer.Value = words.Values.Max();
            answer.Property = keyOfMaxValue;
            answer.Value = words[keyOfMaxValue];

            return answer; 
        }
               
        class CaseInsensitiveComparer : IComparer<string>
        {
            public int Compare(String s1, string s2)
            {
                return string.Compare(s1, s2, true);
            }
        }
    }
}
