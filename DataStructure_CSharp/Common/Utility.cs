using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    public class Utility<T>
    {
        public static void Print(T[] array)
        {
            Console.WriteLine("====== 数组打印 ======");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        /// <summary>
        /// My: Print a singly linked list
        /// </summary>
        /// <param name="list"></param>
        public static void Print(LNode<T> list)
        {
            while (list != null)
            {
                Console.WriteLine(list.Data);
                list = list.Next;
            }
        }
    }
}
