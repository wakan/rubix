using System.Collections.Generic;

namespace ConsoleApp1.Hierarchie
{
    public class Node
    {
        public Node Parent;
        public int[] CubeMove;
        public Move MoveCurrent;
        public int deepth;
        public List<Node> Fils = new List<Node>();
    }
}
