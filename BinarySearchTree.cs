using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2080_Assignment2
{
    class BinarySearchTree
    {
        WNode root;

        public BinarySearchTree()
        {
            root = null;
        }
        public void insert(Weapon item)
        {
            root = insertWorker(root, item);
        }

        private WNode insertWorker(WNode curr, Weapon item)
        {
            if (curr == null)
            {
                return new WNode(item);
            }
            if (curr.data.weaponName.CompareTo(item.weaponName) > 0)
            {
                curr.left = insertWorker(curr.left, item);
            }
            if (curr.data.weaponName.CompareTo(item.weaponName) < 0)
            {
                curr.right = insertWorker(curr.right, item);
            }
            return curr;
        }
        
        public Weapon searchNonRecursion(string n)
        {
            WNode curr = root;
            while (curr != null)
            {                
                if (curr.data.weaponName.CompareTo(n) == 0) return curr.data;
                if (curr.data.weaponName.CompareTo(n) > 0) curr = curr.left;
                else curr = curr.right;
            }
            Console.WriteLine("Cannot find \"" + n + "\" in the list!");
            return null;
        }

        public void printInOrder()
        {
            inOrderWorker(root);
            Console.WriteLine();
        }
        
        private void inOrderWorker(WNode curr)
        {
            string s = "\nName: \tRange: \tDamage: \tWeight: \tCost:\n";
            if (curr == null) return;
            inOrderWorker(curr.left);
            s = s + curr.data.weaponName + "\t" + curr.data.range + "\t" + curr.data.damage + "\t" + curr.data.weight + "\t" + curr.data.cost;
            Console.WriteLine("{0} ", s);
            inOrderWorker(curr.right);
        }
        
        public void delete(Weapon item)
        {
            root = deleteWorker(root, item);
        }
        public WNode deleteWorker(WNode curr, Weapon item)
        {
            if (curr == null) return curr;
            if (curr.data.weaponName.CompareTo(item.weaponName) > 0) curr.left = deleteWorker(curr.left, item);
            if (curr.data.weaponName.CompareTo(item.weaponName) < 0) curr.right = deleteWorker(curr.right, item);

            if (curr.data.weaponName.CompareTo(item.weaponName) == 0)
            {
                if (curr.left == null) return curr.right;
                if (curr.right == null) return curr.left;
                WNode successor = curr.right;
                while (successor.left != null)
                {
                    successor = successor.left;
                }
                curr.data.weaponName = successor.data.weaponName;
                curr.right = deleteWorker(curr.right, item);
            }
            return curr;
        }
    }
}
