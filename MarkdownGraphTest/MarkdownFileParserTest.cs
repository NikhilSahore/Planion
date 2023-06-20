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
        [Fact]
        public static void MarkdownParser_ReturnsXML()
        {
            string rootFolderPath = @"C:\Test\Markdown\";
            MarkdownFileParser markdownFileParser = new MarkdownFileParser();

            var result = markdownFileParser.ParseMarkdown(rootFolderPath);

            Assert.Equal("Test",result);
        }
    }
}
