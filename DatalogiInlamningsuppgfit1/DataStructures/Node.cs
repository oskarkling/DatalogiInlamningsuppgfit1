using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgfit1.DataStructures
{
    // Node structure.
    // Ordinary Node with left and right nodes linked
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public long Data { get; set; }

    }
}
