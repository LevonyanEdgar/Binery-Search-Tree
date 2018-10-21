using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarSTree
{
    class Program
    {
        static void Main(string[] args)
        {
           BSTree t = new BSTree();

            t.Insert(5);
            t.Insert(3);
            t.Insert(9);
            t.Insert(1);
            t.Insert(4);
            t.Insert(8);
            t.Insert(10);

            Console.WriteLine("\nTree (inorder)");
            t.InOderTreeDisply(t.root);
            Console.WriteLine();
            t.FindeValue(t.root, 1);

            t.Remove(5);
            t.Remove(77);
            t.Remove(1);
            t.Remove(10);
            Console.WriteLine();
            t.InOderTreeDisply(t.root);
            Console.ReadLine();
        }
    }
}
