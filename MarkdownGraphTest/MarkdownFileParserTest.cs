using MarkdownGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarkdownGraphTest
{
    public class MarkdownFileParserTest
    {
        private MarkdownFileParser _markdownFileParser;
        public MarkdownFileParserTest()
        {
            _markdownFileParser = new MarkdownFileParser();
        }


        [Fact]
        public void MarkdownParser_ReturnsConnectedMdFiles()
        {
            var inputFile = @"C:\Nikhil\Learning\MarkdownGraph\Planion\MarkdownGraph\docs\ReadMe.md";

            var result = _markdownFileParser.ParseMarkdownFile(inputFile);

            var expectedMdFiles = new List<string> { "Basics", "Filters","Hello", "Development" };
            Assert.Equal(expectedMdFiles, result);
        }
    }
}
