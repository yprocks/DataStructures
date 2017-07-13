using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            // TreeTest();
            // HashTest();
            // PriorityQueue();
            Tries();
            Console.ReadLine();
        }

        static void Tries()
        {
            Trie tr = new Trie();
            tr.Insert("lard");
            tr.Insert("lamptd");
            tr.Insert("card");
            tr.Insert("cartoon");
            tr.Insert("jard");
            tr.Insert("mard");
            tr.Insert("aard");
            tr.Insert("tard");
            tr.Insert("gamaprd");
            tr.Insert("gamdu");

            //tr.Print();
        
            string word = "card";
            Console.WriteLine(word + " Present: " + tr.SearchFullWord(word));

            string word2 = "cartoon";
            Console.WriteLine(word2 + " Present within word: " + tr.SearchPartialWord(word2));

            string toRemove = "card";
            tr.Delete(toRemove);
            Console.WriteLine(toRemove + " Removed ");

            Console.WriteLine(toRemove + " Present: " + tr.SearchFullWord(toRemove));
            
            Console.WriteLine(word2 + " Present: " + tr.SearchFullWord(word2));
        }

        static void TreeTest()
        {
            BinaryTree<int> btree = new BinaryTree<int>();
            btree.Add(50);
            btree.Add(40);
            btree.Add(80);
            btree.Add(30);
            btree.Add(45);
            btree.Add(60);
            btree.Add(90);
            btree.Add(55);
            btree.Add(70);
            btree.Add(85);
            btree.Add(95);
            btree.Add(83);
            btree.Add(20);
            btree.Add(35);
            btree.Add(42);
            btree.Add(49);
            btree.Add(33);
            btree.Add(43);

            btree.Print(btree.RootNode);

            btree.Remove(50);
            //  btree.Remove(42);

            Console.WriteLine("\nAfter Removing 15\n");

            btree.Print(btree.RootNode);

            //Console.WriteLine(btree.Find(btree.RootNode, 9) != null ? "Value present" : "Value not present");


            Console.WriteLine();

            BinaryTree<string> btree1 = new BinaryTree<string>();
            btree1.Add("fd");
            btree1.Add("bc");
            btree1.Add("de");
            btree1.Add("ab");

            btree1.Print(btree1.RootNode);

        }

        static void HashTest()
        {
            HashSet set = new HashSet(10);
            set.Add("A", "Yash");
            set.Add("B", "Meet");
            set.Add("C", "Rashmi");
            set.Add("D", "Piyush");
            set.Add("E", "Rest All");

            set.Remove("A");
            set.Remove("C");
            set.Remove("E");

            set.PrintSet();

            Console.WriteLine(set.GetValue("A"));
        }

        static void PriorityQueue()
        {
            PriorityQueue pq = new PriorityQueue(5);
            pq.Enqueue(1, 5);
            pq.Enqueue(8, 6);
            pq.Enqueue(2, 1);
            pq.Enqueue(6, 4);
            pq.Enqueue(4, 3);
            pq.PrintQueue();

            Console.WriteLine("\nAfter Dequeue");
            pq.Dequeue();
            pq.PrintQueue();

            Console.WriteLine("\nAfter Dequeue");
            pq.Dequeue();
            pq.PrintQueue();

            Console.WriteLine("\nAfter Dequeue");
            pq.Dequeue();
            pq.PrintQueue();

            Console.WriteLine("\nAfter Dequeue");
            pq.Dequeue();
            pq.PrintQueue();
            
            Console.WriteLine("\nAfter Dequeue");
            pq.Dequeue();
            pq.PrintQueue();

            Console.WriteLine("\nAfter Dequeue");
            pq.Enqueue(2, 9);
            pq.PrintQueue();

            Console.WriteLine("\nAfter Dequeue");
            pq.Enqueue(5, 1);
            pq.PrintQueue();
        }
    }
}