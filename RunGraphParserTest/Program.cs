using MarkdownGraph;
using System;

namespace RunGraphParserTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MarkdownFileParser markdownFileParser = new MarkdownFileParser();
            markdownFileParser.TestParser();
        }
    }
}
