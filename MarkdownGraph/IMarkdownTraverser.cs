using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MarkdownGraph
{
    public interface IMarkdownTraverser
    {
        /// <summary>
        /// Takes root directory as input for all md files.
        /// And returns Xml document with all md files Links.
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <returns></returns>
        XmlDocument GetMarkdownLinks(string rootDirectory);
    }
}
