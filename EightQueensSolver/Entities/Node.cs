using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensSolver.Entities
{
    public class Node
    {
        public int[] State;
        public int g;
        public int f;
        public Node Parent;

        public Node(int[] state, int g, Node parent)
        {
            State = state;
            this.g = g;
            f = 0;
            Parent = parent;
        }
    }
}
