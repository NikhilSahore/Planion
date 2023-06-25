using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MarkdownGraph
{
    public class NodeEdgeCreator : IMarkdownTraverser
    {
        private MarkdownFileParser _markdownFileParser;
        private XmlDocument _markdownXmlDocument;
        private XmlElement _rootElement;
        private string _rootDirectory;

        public NodeEdgeCreator()
        {
            _markdownFileParser = new MarkdownFileParser();
            _markdownXmlDocument = new XmlDocument();
            _rootElement = _markdownXmlDocument.CreateElement("Edges");
        }

        public XmlDocument GetMarkdownLinks(string rootDirectory)
        {
            _rootDirectory = rootDirectory;
            return ProcessMarkdownFiles();
        }

        private XmlDocument ProcessMarkdownFiles()
        {
            var sourceNodes = CreateSourceNodes();                 
            
            foreach (var sourceNode in sourceNodes)
            {
                var targetNodes = CreateTargetNodes(sourceNode);
                if (targetNodes.Any())
                {
                    foreach (var targetNode in targetNodes)
                    {
                        var edge = CreateEdge(sourceNode, targetNode);
                        var edgeElement = CreateEdgeElement(edge);
                        _rootElement.AppendChild(edgeElement);
                    }
                }
            }
            _markdownXmlDocument.AppendChild(_rootElement);            
            return _markdownXmlDocument;
        }

        private IEnumerable<Node> CreateSourceNodes()
        {
            return Directory.GetFiles(_rootDirectory, "*.md", SearchOption.AllDirectories).Select(md => CreateNode(md));
        }

        private IEnumerable<Node> CreateTargetNodes(Node sourceNode)
        {
            return _markdownFileParser.ParseMarkdownFile(sourceNode.File).Select(md => CreateNode(md));
        }         

        private Node CreateNode(string file)
        {
            var node = new Node();
            node.File = file;
            return node;
        }

        private Edge CreateEdge(Node source, Node target)
        {
            var edge = new Edge();
            edge.Source = source;
            edge.Target = target;
            return edge;
        }

        private XmlElement CreateEdgeElement(Edge edge)
        {
            XmlElement xmlElementEdge = _markdownXmlDocument.CreateElement("Edge");
            xmlElementEdge.SetAttribute("Source", edge.Source.File);
            xmlElementEdge.SetAttribute("Target", edge.Target.File);
            return xmlElementEdge;
        }
    }
}
