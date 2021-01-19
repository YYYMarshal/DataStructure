using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    /// <summary>
    /// 顺序表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SequenceList<T>
    {
        private static readonly Lazy<SequenceList<T>> lazy = new Lazy<SequenceList<T>>(() => new SequenceList<T>());
        public static SequenceList<T> Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        /// <summary>
        /// 顺序表：初始化
        /// </summary>
        /// <param name="sqList"></param>
        public void Init(SqList<T> sqList)
        {
            sqList.length = 0;
        }
        /// <summary>
        /// 顺序表：插入元素
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="pos"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Insert(SqList<T> sqList, int pos, T data)
        {
            if (pos < 0 || pos > sqList.length || sqList.length == GlobalVariable.MaxSize)
                return false;
            for (int i = sqList.length - 1; i >= pos; i--)
                sqList.data[i + 1] = sqList.data[i];
            sqList.data[pos] = data;
            ++sqList.length;
            return true;
        }
        /// <summary>
        /// 顺序表：删除元素
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="pos"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete(SqList<T> sqList, int pos, out T data)
        {
            if (pos < 0 || pos > sqList.length - 1)
            {
                data = default;
                return false;
            }
            data = sqList.data[pos];
            for (int i = pos; i < sqList.length - 1; i++)
                sqList.data[i] = sqList.data[i + 1];
            --sqList.length;
            return true;
        }
        /// <summary>
        /// 顺序表：求指定位置元素的算法
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public T GetElem(SqList<T> sqList, int pos)
        {
            if (pos < 0 || pos > sqList.length - 1)
                return default;
            return sqList.data[pos];
        }
        /// <summary>
        /// 顺序表：按元素值的查找算法
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int GetIndex(SqList<T> sqList, T data)
        {
            for (int i = 0; i < sqList.length; i++)
            {
                if (data.Equals(sqList.data))
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// My: Print a sequence list
        /// </summary>
        /// <param name="sqList"></param>
        public void Print(SqList<T> sqList)
        {
            Console.WriteLine("====== 顺序表打印 ======");
            if (sqList.length == 0)
            {
                Console.WriteLine("null");
                return;
            }
            for (int i = 0; i < sqList.length; i++)
            {
                Console.WriteLine(sqList.data[i]);
            }
        }
    }
}
