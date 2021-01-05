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
            Test20210105();
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
                while (list != null)
                {
                    Console.WriteLine(list.Data);
                    list = list.Next;
                }
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
                BTNode<int> bTNode = BinarySearchTree<int>.Instance.InitBST(5, 3);
                BTNode<int> searchNode = BinarySearchTree<int>.Instance.RecursionSearch(bTNode, 3, out BTNode<int> bTParent);
                Console.WriteLine($"searchNode.data : {searchNode.Data}");
                Console.WriteLine($"bTParent.data : {bTParent.Data}");
            }

            Console.ReadLine();
        }

    }
}
