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
        /// 顺序表：按元素值的查找算法
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int GetElemIndex(SqList<T> sqList, T data)
        {
            for (int i = 0; i < sqList.Length; i++)
            {
                if (data.Equals(sqList.Data))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 顺序表：插入元素
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="pos"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool InsertElem(SqList<T> sqList, int pos, T data)
        {
            if (pos < 0 || pos > sqList.Length || sqList.Length == GlobalVariable.MaxSize)
                return false;
            for (int i = sqList.Length - 1; i >= pos; i--)
                sqList.Data[i + 1] = sqList.Data[i];
            sqList.Data[pos] = data;
            ++sqList.Length;
            return true;
        }
        /// <summary>
        /// 顺序表：删除元素
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="pos"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool DeleteElem(SqList<T> sqList, int pos, out T data)
        {
            data = default;
            if (pos < 0 || pos > sqList.Length - 1)
                return false;
            data = sqList.Data[pos];
            for (int i = pos; i < sqList.Length - 1; i++)
                sqList.Data[i] = sqList.Data[i + 1];
            --sqList.Length;
            return true;
        }
        /// <summary>
        /// 顺序表：初始化
        /// </summary>
        /// <param name="sqList"></param>
        public void InitSqList(SqList<T> sqList)
        {
            sqList.Length = 0;
        }
        /// <summary>
        /// 顺序表：求指定位置元素的算法
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public T GetElem(SqList<T> sqList, int pos)
        {
            if (pos < 0 || pos > sqList.Length - 1)
                return default;
            return sqList.Data[pos];
        }
    }
}
