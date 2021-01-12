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
                //SortAlgorithm<int>.Instance.QuickSort(array, 0, array.Length - 1);
                SortAlgorithm<int>.Instance.SelectSort(array);
                Utility<int>.Print(array);
            }
            void Test20210105()
            {
                Console.WriteLine("头插法");
                int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                LNode<int> list = SinglyLinkedList<int>.Instance.CreateListHead(array);
                SinglyLinkedList<int>.Instance.Delete(list, 1);
                SinglyLinkedList<int>.Instance.Delete(list, 3);
                SinglyLinkedList<int>.Instance.Delete(list, 6);
                SinglyLinkedList<int>.Instance.Delete(list, 7);
                SinglyLinkedList<int>.Instance.Delete(list, 8);
                SinglyLinkedList<int>.Instance.Delete(list, 9);
                Utility<int>.Print(list);
            }
            void Test20201228()
            {
                Console.WriteLine("尾插法");
                int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                LNode<int> list = SinglyLinkedList<int>.Instance.CreateListTail(array);
                while (list != null)
                {
                    Console.WriteLine(list.Data);
                    list = list.Next;
                }
            }
            void Test()
            {
                BTNode<int> btNode = BinarySearchTree<int>.Instance.CreateBinarySearchTree(5, 3);
                BTNode<int> searchNode = BinarySearchTree<int>.Instance.RecursionSearch(btNode, 3, out BTNode<int> bTParent);
                Console.WriteLine($"searchNode.data : {searchNode.Data}");
                Console.WriteLine($"bTParent.data : {bTParent.Data}");
            }

            Console.ReadLine();
        }

    }
}
