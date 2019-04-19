using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2080_Assignment2
{
    class Program
    {
         public static void addWeapons(BinarySearchTree bst)
         {
             Console.WriteLine("***********WELCOME TO THE WEAPON ADDING MENU*********");
             string weaponName; int weaponRange; int weaponDamage; double weaponWeight; double weaponCost;
             Console.WriteLine("Please enter the NAME of the Weapon ('end' to quit):");
             weaponName = Console.ReadLine();
             while (weaponName.CompareTo("end") != 0)
             {
                 Console.WriteLine("Please enter the Range of the Weapon (0-10):");
                 weaponRange = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Please enter the Damage of the Weapon:");
                 weaponDamage = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Please enter the Weight of the Weapon (in pounds):");
                 weaponWeight = Convert.ToDouble(Console.ReadLine());
                 Console.WriteLine("Please enter the Cost of the Weapon:");
                 weaponCost = Convert.ToDouble(Console.ReadLine());
                 Weapon w = new Weapon(weaponName, weaponRange, weaponDamage, weaponWeight, weaponCost);
                 bst.insert(w);
                 Console.WriteLine("Please enter the NAME of another Weapon ('end' to quit):");
                 weaponName = Console.ReadLine();
             }
         }

         public static void showRoom(BinarySearchTree bst, Player p)
         {
             string choice;
             int numItems = 0;
             Console.WriteLine("WELCOME TO THE SHOWROOM!!!!");
             bst.printInOrder();
             Console.WriteLine(" You have " + p.money + " money.");
             Console.WriteLine("Please select a weapon to buy('end' to quit):");
             choice = Console.ReadLine();
             while (choice.CompareTo("end") != 0 && !p.inventoryFull())
             {
                Weapon w = bst.searchNonRecursion(choice);
                 if (w != null)
                 {
                     if (w.cost > p.money)
                     {
                         Console.WriteLine("Insufficient funds to buy " + w.weaponName);
                     }
                     else
                     {
                         //b.addLast(w);
                         numItems++;
                         p.buy(w);
                         p.withdraw(w.cost);
                     }
                 }
                 else
                 {
                     Console.WriteLine(" ** " + choice + " not found!! **");
                 }
                 Console.WriteLine("Please select another weapon to buy('end' to quit):");
                 choice = Console.ReadLine();
             }
             Console.WriteLine();
         }

         public static void print(Player p)
         {
            Console.Clear();
            Console.WriteLine("------------PLAYER INFO------------");
             p.printCharacter();
            Console.ReadKey();
         }
        
         public static void printBackpack(Player b)
         {
            Console.Clear();
            Console.WriteLine("------------BACKPACK INVENTORY------------");
            b.printBackpack();
            Console.ReadKey();
        }

         public static void delete(BinarySearchTree bst)
         {
             Console.WriteLine("------------REMOVE FROM STORE------------");
             Console.WriteLine("**current inventory**");
             bst.printInOrder();
             Console.WriteLine("Please enter which weapon you would like to remove from the store: ");
             string item = Console.ReadLine();
             Weapon w = bst.searchNonRecursion(item);
             if (w != null)                
             {
                 bst.delete(w);
                 Console.WriteLine("Item was deleted...");
                 Console.WriteLine("**updated inventory**");
                 bst.printInOrder();
             }
             else
             {
                 Console.WriteLine("Weapon is not in the store!");
             }
         }

         public static void showMainMenu()
         {
             Console.Clear();
             Console.WriteLine("--------------WEAPON SHOP--------------\nPlease select a choice from the menu below:\n");
             Console.WriteLine("1: Add Items to the Shop\n2: Delete Items from the Shop\n3: Buy from the Shop\n4: View Backpack\n5: View Player");
             Console.WriteLine("\n6: Exit");
         }

         public static int getValidChoice()
         {
             int choice;
             showMainMenu();
             while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 6))
             {
                 showMainMenu();
                 Console.WriteLine("Please enter a valid choice:");
             }
             return choice;
         }

         static void Main(string[] args)
         {
             string pname;
             Console.WriteLine("Please enter Player name:");
             pname = Console.ReadLine();
             Player pl = new Player(pname, 45);

             BinarySearchTree bst = new BinarySearchTree();
             Weapon w = new Weapon("rock", 3, 4, 2, 1);
             Weapon z = new Weapon("sword", 3, 4, 2, 1);
             bst.insert(w);
             bst.insert(z);

             int choice = getValidChoice();
             while (choice != 6)
             {
                 if (choice == 1) { addWeapons(bst); }
                 if (choice == 2) { delete(bst); }
                 if (choice == 3) { showRoom(bst, pl); }
                 if (choice == 4) { printBackpack(pl); }
                 if (choice == 5) { print(pl); }
                 choice = getValidChoice();
             }

             pl.printCharacter();
             Console.ReadKey();
         }
     }
 }
 /*
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            Weapon w = new Weapon("short gun", 10, 10, 10, 99);
            Weapon a = new Weapon("hand gun", 1, 1, 0, 0);
            Weapon z = new Weapon("long gun", 100, 100, 100, 990);
            bst.insert(w);
            bst.insert(z);
            bst.insert(a);
            // bst.insert("short gun", 10, 10, 10, 10);
            //bst.insert("hand gun", 2, 3,4,5);
            // bst.insert("air bomb", 2, 3, 4, 5);
            // bst.insert("c");
            //bst.insert("y")
            // bst.insert("b");
            // bst.insert("t");
            bst.printInOrder();
            Weapon temp = bst.searchNonRecursion("bomb");
            if (temp != null) { Console.WriteLine(temp.weaponName); }
            temp = bst.searchNonRecursion("air bomb");
            if (temp != null) { Console.WriteLine(temp.weaponName); }
            temp = bst.searchNonRecursion("hand gun");
            if (temp != null) { Console.WriteLine(temp.weaponName); }
            temp = bst.searchNonRecursion("short gun");
            if (temp != null) { Console.WriteLine(temp.weaponName); }
            temp = bst.searchNonRecursion("long gun");
            if (temp != null) { Console.WriteLine(temp.weaponName); }

            Console.WriteLine(w.cost);
            Console.WriteLine(a.cost);
            bst.delete(a);
            bst.printInOrder();
            Console.ReadKey();        
        }
    }
}*/
