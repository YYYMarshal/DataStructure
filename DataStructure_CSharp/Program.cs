using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSinglyLinkedList();
            //TestSequenceList();
            //TestBinaryTree();

            //Test20210118Three();
            void Test20210118Three()
            {
                string[] array = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                Random random = new Random();
                int count = 50;
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(array[random.Next(array.Length)]);
                }
            }
            void Test20210118()
            {
                double num = Convert.ToDouble(DateTime.Now.ToShortTimeString().Replace(":", ""));
                Console.WriteLine(num);
                Console.WriteLine(DateTime.Now.ToShortTimeString());
            }
            void Test20210116()
            {
                SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();
                int[] array = { 7, 1, 2, 3, 4, 5, 6 };
                ListNode<int> listTail = singlyLinkedList.CreateListTail(array);
                //singlyLinkedList.Delete(listTail, 4);
                singlyLinkedList.DeleteByData(listTail, 7);
                //singlyLinkedList.Delete(listTail, 6);
                singlyLinkedList.Print(listTail);

                ListNode<int> listHead = singlyLinkedList.CreateListHead(array);
                singlyLinkedList.Print(listTail);
            }
            void Test20210113Two()
            {
                //int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                int[] array = { 1, 2, 3, 4, 5 };
                BTNode<int> btNode = null;
                BinaryTree<int> binaryTree = new BinaryTree<int>();
                binaryTree.Create(ref btNode, array, 0);
                Console.WriteLine(binaryTree.GetDepth(btNode));
                Console.WriteLine(binaryTree.GetLeafNodeCount(btNode));
                Console.WriteLine(binaryTree.GetAllNodeCount(btNode));
                Console.WriteLine("LevelTraversal");
                binaryTree.LevelTraversal(btNode, (tree) => Console.WriteLine(tree.data));
                Console.WriteLine("PreorderTraversal");
                binaryTree.PreorderTraversal(btNode, (tree) => Console.WriteLine(tree.data));
                Console.WriteLine("InorderTraversal");
                binaryTree.InorderTraversal(btNode, (tree) => Console.WriteLine(tree.data));
                Console.WriteLine("PostorderTraversal");
                binaryTree.PostorderTraversal(btNode, (tree) => Console.WriteLine(tree.data));
                Console.WriteLine("PreordeTraversalNonRecursion");
                binaryTree.PreordeTraversalNonRecursion(btNode, (tree) => Console.WriteLine(tree.data));
                Console.WriteLine("InorderTraversalNonRecursion");
                binaryTree.InorderTraversalNonRecursion(btNode, (tree) => Console.WriteLine(tree.data));
                Console.WriteLine("PostorderTraversalNonRecursion");
                binaryTree.PostorderTraversalNonRecursion(btNode, (tree) => Console.WriteLine(tree.data));
                Console.WriteLine();
            }
            void Test20210112()
            {
                int value = 234;
                int[] values = new int[4];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = value % 10;
                    value /= 10;
                }
                Console.WriteLine();
            }
            void Test20210109()
            {
                DateTime.TryParse("2020.10.01", out DateTime result);
                Console.WriteLine(result);
                Console.WriteLine(result.ToShortDateString());
                Console.WriteLine(DateTime.Now.ToShortDateString());

                double a = 10;
                a += a *= a /= a - 6;
                Console.WriteLine(a);
            }
            //Test20210106();
            void Test20210106()
            {
                int[] array = new int[] { 9, 8, 5, 4, 1, 2 };
                Utility<int>.Print(array);
                //SortAlgorithm<int>.Instance.InsertSort(array);
                //SortAlgorithm<int>.Instance.BubbleSort(array);
                //SortAlgorithm<int>.Instance.QuickSort(array, 0, array.length - 1);
                SortAlgorithm<int>.Instance.SelectSort(array);
                Utility<int>.Print(array);
            }
            void Test20210105()
            {
                Console.WriteLine("头插法");
                int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();
                ListNode<int> list = singlyLinkedList.CreateListHead(array);
                singlyLinkedList.Print(list);
            }
            void Test20201228()
            {
                Console.WriteLine("尾插法");
                int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();
                ListNode<int> list = singlyLinkedList.CreateListTail(array);
                while (list != null)
                {
                    Console.WriteLine(list.data);
                    list = list.next;
                }
            }
            Console.ReadLine();
        }
        private static void TestSinglyLinkedList()
        {
            SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();
            int[] array = { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("\n尾插法建立单链表");
            ListNode<int> listTail = singlyLinkedList.CreateListTail(array);
            singlyLinkedList.Print(listTail);

            //Console.WriteLine("头插法建立单链表");
            //ListNode<int> listHead = singlyLinkedList.CreateListHead(array);
            //singlyLinkedList.Print(listHead);

            Console.WriteLine("\n头插");
            singlyLinkedList.InsertHead(listTail, 9, -1);
            singlyLinkedList.InsertHead(listTail, 10, 0);
            singlyLinkedList.InsertHead(listTail, 11, 3);
            singlyLinkedList.InsertHead(listTail, 12, 10);
            singlyLinkedList.Print(listTail);

            Console.WriteLine("\n按位置（3）查找结点");
            ListNode<int> node = singlyLinkedList.GetNodeByPosition(listTail, 3);
            singlyLinkedList.Print(node);
            Console.WriteLine("\n按值（3）查找结点");
            ListNode<int> nodeTwo = singlyLinkedList.GetNodeByData(listTail, 3);
            singlyLinkedList.Print(nodeTwo);

            //Console.WriteLine("头插");
            //singlyLinkedList.InsertHead(node, 9, -1);
            //singlyLinkedList.InsertHead(node, 10, 0);
            //singlyLinkedList.InsertHead(node, 11, 3);
            //singlyLinkedList.InsertHead(node, 12, 10);
            //singlyLinkedList.Print(node);

            Console.WriteLine("\n通过值（10）删除");
            singlyLinkedList.DeleteByData(listTail, 10);
            singlyLinkedList.Print(listTail);

            Console.WriteLine("\n通过位置（4）删除");
            singlyLinkedList.DeleteByPosition(listTail, 4);
            singlyLinkedList.Print(listTail);

            //Console.WriteLine("通过位置删除");
            //singlyLinkedList.DeleteByPosition(listTail, 6);
            //singlyLinkedList.Print(listTail);

        }
        private static void TestSequenceList()
        {
            SequenceList<int> sequenceList = new SequenceList<int>();
            int[] array = { 8, 1, 2, 3, 4, 5, 6, 7 };
            SqList<int> sqList = sequenceList.Create(array);
            sequenceList.Print(sqList);
            Console.WriteLine("\n" + sqList.length);
            sequenceList.Insert(sqList, 1, 10);
            sequenceList.Print(sqList);
            sequenceList.Delete(sqList, 5, out int data);
            sequenceList.Print(sqList);
            Console.WriteLine("\n值：" + data);
            int node = sequenceList.GetElem(sqList, 2);
            Console.WriteLine("\n值：" + node);
            int index = sequenceList.GetIndex(sqList, 3);
            Console.WriteLine("\n索引：" + index);
        }
        private static void TestBinaryTree()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            BTNode<int> btNode = new BTNode<int>();
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            binaryTree.Create(ref btNode, array, 0);
            binaryTree.LevelTraversal(btNode, (node) => Console.WriteLine(node.data));
            Console.WriteLine("先序遍历");
            binaryTree.PreorderTraversal(btNode, (node) => Console.WriteLine(node.data));
            Console.WriteLine("中序遍历");
            binaryTree.InorderTraversal(btNode, (node) => Console.WriteLine(node.data));
            Console.WriteLine("后序遍历");
            binaryTree.PostorderTraversal(btNode, (node) => Console.WriteLine(node.data));
        }
    }
}
