using System.Linq;
using WordsStats.Services;
using Xunit;
using Xunit.Abstractions;

namespace Tasks
{
    public class WordsCounterUnitTest
    {
        private FileReader _reader;
        private WordsCounter _counter;
        private readonly ITestOutputHelper _output;

        public WordsCounterUnitTest(ITestOutputHelper output)
        {
            _reader = new FileReader();
            _counter = new WordsCounter();
            _output = output;
        }

        [Fact]
        public void ShouldGenerate3Substrings()
        {
            var str1 = "hello";
            var substrings1 = _counter.GenerateSubstrings(str1.Split(' '), 4);
            Assert.Equal(3, substrings1.Count());
        }

        [Fact]
        public void ShouldGenerate1Substring()
        {
            var str2 = "card";
            var substrings2 = _counter.GenerateSubstrings(str2.Split(' '), 4);
            Assert.Single(substrings2);
        }

        [Fact]
        public void ShouldGenerate0Substrings()
        {
            var str3 = "cat";
            var substrings3 = _counter.GenerateSubstrings(str3.Split(' '), 4);
            Assert.Empty(substrings3);
        }

        [Fact]
        public void ShouldGenerate4Substrings()
        {
            var str4 = "hello cat card";
            var substrings4 = _counter.GenerateSubstrings(str4.Split(' '), 4);
            Assert.Equal(4, substrings4.Count());
        }
        
        [Fact]
        public void TestTopHits100Percent()
        {
            var str1 = "card card card card card";
            var substrings1 = _counter.GenerateSubstrings(str1.Split(' '), 4);
            var topTen = _counter.GetTopNHits(substrings1, 10).ToList();
            Assert.Equal(1, topTen[0].Value);
            Assert.Equal("card", topTen[0].Key);
        }        
        
        [Fact]
        public void TestTopHits5050Percent()
        {
            var str1 = "card card card bark bark bark";
            var substrings1 = _counter.GenerateSubstrings(str1.Split(' '), 4);
            var topTen = _counter.GetTopNHits(substrings1, 10).ToList();
            Assert.Equal(0.5, topTen[0].Value);
            Assert.Equal(0.5, topTen[1].Value);
        }        
        
        [Fact]
        public void TestTopHits7525Percent()
        {
            var str1 = "card card card bark";
            var substrings1 = _counter.GenerateSubstrings(str1.Split(' '), 4);
            var topTen = _counter.GetTopNHits(substrings1, 10).ToList();
            Assert.Equal(0.75, topTen[0].Value);
            Assert.Equal("card", topTen[0].Key);
            Assert.Equal(0.25, topTen[1].Value);
            Assert.Equal("bark", topTen[1].Key);
        }
        
        [Fact]
        public void ReturnsTopTen()
        {
            var str1 = "When we think about the changes that the pandemic has brought in our lives in the past year";
            var substrings1 = _counter.GenerateSubstrings(str1.Split(' '), 4);
            var topTen = _counter.GetTopNHits(substrings1, 10).ToList();
            Assert.Equal(10, topTen.Count);
        }
    }
}