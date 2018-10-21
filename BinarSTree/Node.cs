using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarSTree
{
    class Node
    {
        public double value;
        public Node RightNode { get; set; }
        public Node LeftNode { get; set; }

        public Node(double value)
        {
            this.value = value;

        }
        
    }
}
