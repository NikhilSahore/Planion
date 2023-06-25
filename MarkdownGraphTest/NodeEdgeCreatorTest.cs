using MarkdownGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace MarkdownGraphTest
{
    public class NodeEdgeCreatorTest
    {
        private NodeEdgeCreator _nodeEdgeCreator;
        public NodeEdgeCreatorTest()
        {
            _nodeEdgeCreator = new NodeEdgeCreator();
        }

        [Fact]
        public void NodeEdgeCreator_ReturnsXmlDocument()
        {
            var rootDirectory = @"C:\Nikhil\Learning\MarkdownGraph\Planion\MarkdownGraphTest\Sample";

            var result = _nodeEdgeCreator.GetMarkdownLinks(rootDirectory);

            Assert.Equal("Development", result.FirstChild.ChildNodes.Item(4).Attributes["Target"].Value);
        }
    }
}
