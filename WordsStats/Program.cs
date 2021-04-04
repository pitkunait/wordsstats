using System;
using System.Linq;
using WordsStats.Services;


namespace WordsStats
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new FileReader();
            var counter = new WordsCounter();

            var words = reader.ReadWords(args[0]);
            var substrings = counter.GenerateSubstrings(words, 4);
            var topTen = counter.GetTopNHits(substrings, 10);
            Console.WriteLine("Frequencies:");
            topTen.ToList().ForEach(item => Console.WriteLine($"{item.Key} {Math.Round(item.Value * 100, 2)}%"));
        }
    }
}