using System;
using System.Collections.Generic;
using System.IO;

namespace WordsStats.Services
{
    public class FileReader
    {
        public IEnumerable<string> ReadWords(string filePath)
        {
            var text = File.ReadAllText(filePath);
            var split = text.Split(' ');
            return split;
        }
    }
}