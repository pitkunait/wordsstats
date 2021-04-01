using System.Collections.Generic;
using System.Linq;

namespace WordsStats.Services
{
    public class WordsCounter
    {
        public IEnumerable<string> GenerateSubstrings(IEnumerable<string> strings, int substrLength)
        {
            // O(mn2)
            var result = new List<string>();
            foreach (var str in strings)
            {
                for (var i = 0; i <= str.Length - substrLength; i++)
                {
                    for (var j = substrLength; j <= str.Length - i; j++)
                    {
                        result.Add(str.Substring(i, j));
                    }
                }
            }
            return result;
        }

        public IEnumerable<KeyValuePair<string, float>> GetTopNHits(IEnumerable<string> strings, int n)
        {
            var occurrences = CountOccurrences(strings);
            float sum = occurrences.Sum(i => i.Value);
            var hits = occurrences.ToDictionary(k => k.Key, v => v.Value / sum);
            return hits.OrderByDescending(i => i.Value).Take(n);
        }

        private Dictionary<string, int> CountOccurrences(IEnumerable<string> strings)
        {
            var occurrences = new Dictionary<string, int>();
            foreach (var substr in strings)
            {
                if (occurrences.ContainsKey(substr))
                {
                    occurrences[substr] += 1;
                }
                else
                {
                    occurrences.Add(substr, 1);
                }
            }
            return occurrences;
        }
    }
}