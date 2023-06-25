using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownGraph
{
    public class Node
    {
        private string _file;
        public string File 
        {
            get
            {
                return _file;
            }
            set
            {
                _file = value;
            }
        }
    }
}
