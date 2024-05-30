using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensSolver.Entities
{
    public class Queen
    {
        public int column, row;
        public Queen(int x, int y)
        {
            column = y;
            row = x;
        }
    }
}
