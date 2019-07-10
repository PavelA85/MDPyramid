using System.Collections.Generic;
using System.Linq;

namespace MDPyramid
{
    public class Path
    {
        public List<int> Nodes { get; }
        public int Sum => Nodes.Sum();

        public Path(List<int> nodes)
        {
            Nodes = nodes;
        }

        public override string ToString()
        {
            return $"{nameof(Sum)}: {Sum}, {nameof(Nodes)}: {string.Join(">", Nodes)}";
        }
    }
}