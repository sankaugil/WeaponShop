using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2080_Assignment2
{
    class WNode
    {
        public Weapon data;
        public WNode left;
        public WNode right;
        
        public WNode(Weapon d)
        {
            data = d;
            left = right = null;
        }
    }
}
