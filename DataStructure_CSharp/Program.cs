using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().Id);
            //TestSinglyLinkedList();
            //TestBinaryTree();
            TestSortAlgorithm();

            Console.ReadKey();
        }
        #region Singly Linked List
        private static void TestSinglyLinkedList()
        {
            Console.WriteLine("-------------------- TestSinglyLinkedList --------------------");
            Console.WriteLine("功能选择：\n" +
                "1. Create\n" +
                "2. GetElem\n" +
                "3. Insert\n" +
                "4. Delete\n" +
                "5. Merge\n");
            int selection = 0;
            try
            {
                selection = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("请输入正确的选项！！！");
            }
            switch (selection)
            {
                case 1:
                    TestSinglyLinkedList_Create();
                    break;
                case 2:
                    TestSinglyLinkedList_GetElem();
                    break;
                case 3:
                    TestSinglyLinkedList_Insert();
                    break;
                case 4:
                    TestSinglyLinkedList_Delete();
                    break;
                case 5:
                    TestSinglyLinkedList_Merge();
                    break;
            }
        }
        private static void TestSinglyLinkedList_Create()
        {
            Console.WriteLine("----------   单链表的Create测试   ----------\n");
            SinglyLinkedList<int> function = new SinglyLinkedList<int>();
            int[] array = new int[] { 999, 1, 2, 3, 4, 5 };

            Console.WriteLine("YWM：头插法，逆序反循环，得到正序单链表");
            function.Print(function.CreateList(array));
            function.Print(function.CreateList(null));

            Console.WriteLine("TQ：尾插法");
            function.Print(function.CreateListTail(array));
            function.Print(function.CreateListTail(null));

            Console.WriteLine("TQ：头插法");
            function.Print(function.CreateListHead(array));
            function.Print(function.CreateListTail(null));
        }
        private static void TestSinglyLinkedList_GetElem()
        {
            Console.WriteLine("----------   单链表的GetElem测试   ----------");
            SinglyLinkedList<int> function = new SinglyLinkedList<int>();
            int[] array = new int[] { 999, 1, 2, 3, 4, 5 };
            LNode<int> list = function.CreateList(array);
            function.Print(list);

            Console.WriteLine("GetElemByPosition");
            function.Print(function.GetElemByPosition(list, 0));
            LNode<int> subList = function.GetElemByPosition(list, 2);
            function.Print(subList);
            function.Print(function.GetElemByPosition(list, 6));
            function.Print(function.GetElemByPosition(list, 7));
            function.Print(function.GetElemByPosition(null, 1));
            Console.WriteLine("子表测试\n");
            function.Print(function.GetElemByPosition(subList, 0));
            function.Print(function.GetElemByPosition(subList, 1));

            Console.WriteLine("GetElemByData");
            function.Print(function.GetElemByData(list, 0));
            function.Print(function.GetElemByData(list, 3));
            function.Print(function.GetElemByData(list, 66));
            function.Print(function.GetElemByData(null, 1));
        }
        private static void TestSinglyLinkedList_Insert()
        {
            Console.WriteLine("----------   单链表的Insert测试   ----------");
            SinglyLinkedList<int> function = new SinglyLinkedList<int>();
            int[] array = new int[] { 999, 1, 2, 3, 4, 5 };
            LNode<int> list = function.CreateList(array);
            function.Print(list);

            Console.WriteLine();
            Console.WriteLine(function.Insert(list, 0, 10));
            function.Print(list);
            Console.WriteLine(function.Insert(list, 1, 100));
            function.Print(list);
            Console.WriteLine(function.Insert(list, 6, 106));
            function.Print(list);
            Console.WriteLine(function.Insert(list, 5, 105));
            function.Print(list);
            Console.WriteLine(function.Insert(list, 11, 999));
            function.Print(list);
            Console.WriteLine(function.Insert(list, 10, 99));
            function.Print(list);
            Console.WriteLine(function.Insert(null, 2, 888));
            function.Print(list);
        }
        private static void TestSinglyLinkedList_Delete()
        {
            Console.WriteLine("----------   单链表的Delete测试   ----------");
            SinglyLinkedList<int> function = new SinglyLinkedList<int>();
            int[] array = new int[] { 999, 1, 2, 3, 4, 5 };
            LNode<int> list = function.CreateList(array);
            function.Print(list);

            Console.WriteLine("DeleteByPosition");
            Console.WriteLine(function.DeleteByPosition(list, 0));
            function.Print(list);
            Console.WriteLine(function.DeleteByPosition(list, 1));
            function.Print(list);
            Console.WriteLine(function.DeleteByPosition(list, 5));
            function.Print(list);
            Console.WriteLine(function.DeleteByPosition(list, 5));
            function.Print(list);
            Console.WriteLine(function.DeleteByPosition(null, 2));
            function.Print(list);

            Console.WriteLine("DeleteByData");
            Console.WriteLine(function.DeleteByData(list, 0));
            function.Print(list);
            Console.WriteLine(function.DeleteByData(list, 3));
            function.Print(list);
            Console.WriteLine(function.DeleteByData(null, 1));
            function.Print(list);
        }
        private static void TestSinglyLinkedList_Merge()
        {
            Console.WriteLine("----------   单链表的Merge测试   ----------");
            SinglyLinkedList<int> function = new SinglyLinkedList<int>();

            int[] arrayOne = new int[] { 5, 7, 9, 10 };
            LNode<int> listOne = function.CreateList(arrayOne);
            function.Print(listOne);
            int[] arrayTwo = new int[] { 1, 6, 8, 20 };
            LNode<int> listTwo = function.CreateList(arrayTwo);
            function.Print(listTwo);

            LNode<int> listMergeOne = function.MergeList(listOne.next, listTwo);
            function.Print(listMergeOne);
            function.Print(function.GetElemByPosition(listMergeOne, 0));
            function.Print(function.GetElemByPosition(listMergeOne, 1));
            LNode<int> listMergeTwo = function.MergeList(null, null);
            function.Print(listMergeTwo);
        }
        #endregion

        #region Binary Tree
        private static void TestBinaryTree()
        {
            Console.WriteLine("-------------------- TestBinaryTree --------------------");
            Console.WriteLine("功能选择：\n" +
                "1. Create\n" +
                "2. Recursion Traversal\n" +
                "3. Non-Recursion Traversal\n" +
                "4. Get"
                );
            int selection = 0;
            try
            {
                selection = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("请输入正确的选项！！！");
            }
            switch (selection)
            {
                case 1:
                    TestBinaryTree_Create();
                    break;
                case 2:
                    TestBinaryTree_RecursionTraversal();
                    break;
                case 3:
                    TestBinaryTree_NonRecursionTraversal();
                    break;
                case 4:
                    TestBinaryTree_Get();
                    break;
                case 5:
                    break;
            }
        }
        private static void TestBinaryTree_Create()
        {
            BinaryTree<int> function = new BinaryTree<int>();
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            BTNode<int> btNode = new BTNode<int>();
            //function.Create(ref btNode, null);
            function.Create(ref btNode, array);
            function.LevelTraversal(btNode,
                (node) => Console.Write(node.data + "  "));
        }
        private static void TestBinaryTree_RecursionTraversal()
        {
            BinaryTree<int> function = new BinaryTree<int>();
            int[] array = new int[] { 1, 3, 4, 7, 8, 10 };
            BTNode<int> btNode = new BTNode<int>();
            function.Create(ref btNode, array);

            function.PreorderTraversal(btNode,
                (node) => Console.Write(node.data + "  "));
            Console.WriteLine();

            function.InorderTraversal(btNode,
                (node) => Console.Write(node.data + "  "));
            Console.WriteLine();

            function.PostorderTraversal(btNode,
                (node) => Console.Write(node.data + "  "));
        }
        private static void TestBinaryTree_NonRecursionTraversal()
        {
            BinaryTree<int> function = new BinaryTree<int>();
            int[] array = new int[] { 1, 3, 4, 7, 8, 10 };
            BTNode<int> btNode = new BTNode<int>();
            function.Create(ref btNode, array);

            function.PreordeNonRecursionTraversal(btNode,
                (node) => Console.Write(node.data + "  "));
            Console.WriteLine();

            function.InorderNonRecursionTraversal(btNode,
                (node) => Console.Write(node.data + "  "));
            Console.WriteLine();

            function.PostorderNonRecursionTraversal(btNode,
                (node) => Console.Write(node.data + "  "));
        }
        private static void TestBinaryTree_Get()
        {
            BinaryTree<int> function = new BinaryTree<int>();
            int[] array = new int[] { 1, 3, 4, 7, 8, 10 };
            BTNode<int> btNode = new BTNode<int>();
            function.Create(ref btNode, array);

            Console.WriteLine(function.GetDepth(btNode));
            Console.WriteLine(function.GetLeafNodeCount(btNode));
            Console.WriteLine(function.GetAllNodeCount(btNode));
        }
        #endregion

        #region Sort Algorithm
        private static void TestSortAlgorithm()
        {
            Console.WriteLine("-------------------- TestBinaryTree --------------------");
            Console.WriteLine("功能选择：\n" +
                "1. Insert Sort\n" +
                "2. Exchange\n" +
                "3. \n" +
                "4. "
                );
            int selection = 0;
            try
            {
                selection = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("请输入正确的选项！！！");
            }
            switch (selection)
            {
                case 1:
                    TestSortAlgorithm_InsertSort();
                    break;
                case 2:
                    TestSortAlgorithm_Exchange();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }
        private static void TestSortAlgorithm_InsertSort()
        {
            SortAlgorithm<int> function = new SortAlgorithm<int>();
            int[] array = new int[] { 9, 8, 6, 5, 4, 1, 2 };
            function.InsertSort(array);
            Utility<int>.Print(array);
        }
        private static void TestSortAlgorithm_Exchange()
        {
            SortAlgorithm<int> function = new SortAlgorithm<int>();
            int[] array = new int[] { 3, 5, 8, 7, 4, 1, 2 };
            function.BubbleSort(array);
            Utility<int>.Print(array);

            array = new int[] { 13, 15, 18, 17, 14, 11, 12 };
            function.QuickSort(array, 0, array.Length - 1);
            Utility<int>.Print(array);
        }
        #endregion
    }
}
