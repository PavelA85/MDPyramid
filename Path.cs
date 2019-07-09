using System.Collections.Generic;

namespace MDPyramid
{
    public class Path
    {
        public int Sum { get; set; }
        public List<int> Nodes { get; set; }

        public Path(List<int> nodes, int sum)
        {
            Nodes = nodes;
            Sum = sum;
        }

        public override string ToString()
        {
            return $"{nameof(Sum)}: {Sum}, {nameof(Nodes)}: {string.Join(">", Nodes)}";
        }
    }
}