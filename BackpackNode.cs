using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2080_Assignment2
{
    class BackpackNode
    {
        public Weapon data;
        public BackpackNode next;
        public BackpackNode(Weapon b)
        {
            data = b;
            next = null;
        }
    }
}
