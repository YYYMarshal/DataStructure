using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    public class SortAlgorithm<T>
    {
        private static readonly Lazy<SortAlgorithm<T>> lazy = new Lazy<SortAlgorithm<T>>(() => new SortAlgorithm<T>());
        public static SortAlgorithm<T> Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        #region 插入类排序
        /// <summary>
        /// 直接插入排序：">"是递增排序
        /// </summary>
        /// <param name="array"></param>
        public void InsertSort(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                T temp = array[i];
                int j = i - 1;
                while (j >= 0 && array[j].GetHashCode() > temp.GetHashCode())
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }
        #endregion

        #region 交换类排序
        /// <summary>
        /// 冒泡排序：">"是递增排序
        /// </summary>
        /// <param name="array"></param>
        public void BubbleSort(T[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j].GetHashCode() > array[j + 1].GetHashCode())
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        public void QuickSort(T[] array, int low, int high)
        {
            if (low >= high)
                return;
            T temp = array[low];
            int i = low;
            int j = high;
            while (i < j)
            {
                while (i < j && array[j].GetHashCode() >= temp.GetHashCode())
                    j--;
                if (i < j)
                {
                    array[i] = array[j];
                    i++;
                }
                while (i < j && array[i].GetHashCode() < temp.GetHashCode())
                {
                    i++;
                }
                if (i < j)
                {
                    array[j] = array[i];
                    j--;
                }
            }
            array[i] = temp;
            QuickSort(array, low, i - 1);
            QuickSort(array, i + 1, high);
        }
        #endregion

        #region 选择类排序
        /// <summary>
        /// 简单选择排序
        /// </summary>
        /// <param name="array"></param>
        public void SelectSort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int k = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[k].GetHashCode() > array[j].GetHashCode())
                        k = j;
                }
                T temp = array[i];
                array[i] = array[k];
                array[k] = temp;
            }
        }
        #endregion
    }
}
