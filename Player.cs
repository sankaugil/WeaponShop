using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2080_Assignment2
{
    class Player
    {

        public Backpack back;
        public string name;
        public int numItems;
        public double money;
        public double weight = 0;

        public Player(string n, double m)
        {
            name = n;
            money = m;
            numItems = 0;
            back = new Backpack(50);
        }

        public void buy(Weapon w)
        {
            if ((w.weight+back.presentWeight) <= back.maxWeight) {
            Console.WriteLine(w.weaponName + " bought...");          
            back.addLast(w);
            numItems++;
            weight = weight + w.weight;
            Console.Write(numItems);
            }
            else
            {
                Console.WriteLine("Too heavy");
            }
        }
        public void withdraw(double amt)
        {
            money = money - amt;
        }

        public bool inventoryFull()
        {
            bool full = false;
            if (numItems == 10) full = true;
            return full;
        }

        public void printCharacter()
        {
            Console.WriteLine(" Name:" + name + "\n Money:" + money);
            printBackpack();
        }
        
        public void printBackpack()
        {
            Console.WriteLine(" " + name + ", you own " + numItems + " Weapons:");
            back.printList();
        }
    }
}
