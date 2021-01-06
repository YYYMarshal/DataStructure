using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    /// <summary>
    /// 第九章《查找》
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchAlgorithm<T>
    {
        private static readonly Lazy<SearchAlgorithm<T>> lazy = new Lazy<SearchAlgorithm<T>>(() => new SearchAlgorithm<T>());
        public static SearchAlgorithm<T> Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        #region 顺序查找
        /// <summary>
        /// 顺序查找(顺序表)：查找成功则返回key所在的索引；否则返回-1
        /// </summary>
        /// <param name="array"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int SequentialSearch(T[] array, T key)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (key.Equals(array[i]))
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// 顺序查找(链表)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public LNode<T> SequentialSearch(LNode<T> head, T key)
        {
            LNode<T> tailNode = head.Next;
            while (tailNode != null)
            {
                if (key.Equals(tailNode.Data))
                    return tailNode;
                tailNode = tailNode.Next;
            }
            return null;
        }
        #endregion

        #region 二分查找（折半查找）
        /// <summary>
        /// 二分查找（折半查找）
        /// </summary>
        public int BinarySearch(T[] array, int low, int high, T key)
        {
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (key.Equals(array[mid]))
                    return mid;
                else if (key.GetHashCode() < array[mid].GetHashCode())
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            return -1;
        }
        #endregion

    }
}
