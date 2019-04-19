using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2080_Assignment2
{
    class Weapon
    {
        public string weaponName;
        public int range;
        public int damage;
        public double weight;
        public double cost;
        public WNode next;

        public Weapon(string n, int rang, int dam, double w, double c)
        {
            weaponName = n;
            damage = dam;
            range = rang;
            weight = w;
            cost = c;
            next = null;
        }
    }
}
