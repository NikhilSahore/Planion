using System.IO;

namespace MarkdownGraph
{
    public class MarkdownFileParser
    {
        public void TestParser()
        {
            // Specify the path to the source MD file
            var input = @"C:\Nikhil\Learning\MarkdownGraph\Planion\MarkdownGraph\docs\ReadMe.md";

            string mdContent = File.ReadAllText(input);

        }

        public string ParseMarkdown(string rootFolderPath)
        {
            return "Test";
        }
    }
}
