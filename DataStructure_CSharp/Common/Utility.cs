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
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine();
        }
    }
}
