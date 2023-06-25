using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarkdownGraph
{
    public class MarkdownFileParser
    {
        private readonly string LINK_PATTERN = @"\[([^\[]+)\](\(.*\))";
        private readonly string MD_FILE_PATTERN = @".md";
        private readonly string WEB_PATTERN = @"\S*(?:https?|ftp):\/\/\S+|(_(?![^_\n]*(?:https?|ftp):\/\/[^_\n]*_)[^_\n]+_)";


        public List<string> ParseMarkdownFile(string filePath)
        {
            var connectedFiles = new List<string>();
            var mdContent = File.ReadAllText(filePath);

            var regexdata = Regex.Matches(mdContent, LINK_PATTERN);
            foreach (Match match in regexdata)
            {
                var groupMatchCollection = match.Groups;
                IEnumerable<Group> groupList = groupMatchCollection.Cast<Group>().ToList();
                var connectedFile = groupList.Last().Value;
                connectedFile = connectedFile.Substring(connectedFile.IndexOf('(') + 1, connectedFile.IndexOf(')') - 1);
                var connectedFileExtension = Path.GetExtension(connectedFile);
                if (IsValidConnectedFile(connectedFile, connectedFileExtension) && !connectedFiles.Contains(connectedFile))
                {
                    connectedFiles.Add(connectedFile);
                }
            }
            return connectedFiles;
        }

        private bool IsValidConnectedFile(string connectedFile, string connectedFileExtension)
        {
            if ((connectedFileExtension.Equals(MD_FILE_PATTERN) || connectedFileExtension.Equals("")) &&
                !Regex.IsMatch(connectedFile, WEB_PATTERN))
            {
                return true;
            }
            return false;
        }
    }
}
