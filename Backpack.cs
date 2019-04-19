using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2080_Assignment2
{
    class Backpack
    {
        // This class implements a backpack as a linked list
        // The backpack can hold any number of weapons as long as maxWeight is not crossed.
        // If an attempt to add a weapon to backpack is rejected due to weight
        
        public double maxWeight;
        public double presentWeight;

        public BackpackNode head;
        public Backpack(double m)
        {
            head = null;
            maxWeight = m;
            presentWeight = 0;
        }
        public void addLast(Weapon b)
        {
            BackpackNode newNode = new BackpackNode(b);
            if (head == null) 
            {
                head = newNode;
                return;
            }
            BackpackNode curr = head;
            while (curr.next != null)
            {
                curr = curr.next;               
            }
            curr.next = newNode;
        }
        public void printList()
        {
            BackpackNode curr = head;
            while (curr != null)
            {
                Console.Write(" {0} ", curr.data.weaponName);
                curr = curr.next;
            }
            Console.WriteLine();
        }
    }
}
