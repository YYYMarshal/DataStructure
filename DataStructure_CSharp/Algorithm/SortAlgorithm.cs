using System;
using System.Collections.Generic;

namespace DataStructure_CSharp
{
    public class SortAlgorithm<T>
    {
        #region 插入类排序
        /* 
         * 1. 直接插入排序
         * 2. 折半插入排序
         * 3. 希尔排序
         */

        /// <summary>
        /// (TQ)直接插入排序：">"是递增排序
        /// </summary>
        /// <param name="array"></param>
        public void InsertSort(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                T temp = array[i];
                int j = i - 1;
                // 下面这个循环完成了从待排关键字之前的关键字开始扫描，
                // 如果大于待排关键字，则后移一位
                while (j >= 0 && array[j].GetHashCode() > temp.GetHashCode())
                {
                    array[j + 1] = array[j];
                    j--;
                }
                // 找到插入位置，将temp中暂存的待排关键字插入
                array[j + 1] = temp;
            }
        }
        #endregion

        #region 交换类排序
        /// <summary>
        /// (MY)冒泡排序：">"是递增排序
        /// </summary>
        /// <param name="array"></param>
        public void MyBubbleSort(T[] array)
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
        /// <summary>
        /// (TQ)冒泡排序
        /// </summary>
        /// <param name="array"></param>
        public void BubbleSort(T[] array)
        {
            for (int i = array.Length - 1; i >= 1; i--)
            {
                // 变量 #isChanged# 用来标记本趟排序是否发生了交换
                bool isChanged = false;
                for (int j = 1; j <= i; j++)
                {
                    if (array[j - 1].GetHashCode() > array[j].GetHashCode())
                    {
                        T temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                        isChanged = true;
                    }
                }
                // 一趟排序过程中没有发生关键字交换，则证明序列有序，排序结束
                if (!isChanged)
                    return;
            }
        }
        /// <summary>
        /// (TQ)快速排序
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public void QuickSort(T[] array, int low, int high)
        {
            if (low >= high)
                return;

            // 对从 arrar[low] 到 array[high] 的关键字进行排序
            T temp = array[low];
            int i = low;
            int j = high;
            // 下面这个循环完成了一趟排序，即将数组中小于temp的关键字放在左边，
            // 大于temp的关键字放在右边
            while (i < j)
            {
                // 从右往左扫描，找到一个小于temp的关键字
                while (i < j && array[j].GetHashCode() >= temp.GetHashCode())
                    j--;
                if (i < j)
                {
                    // 放在temp左边
                    array[i] = array[j];
                    // i右移一位
                    i++;
                }
                // 从左往右扫描，找到一个大于temp的关键字
                while (i < j && array[i].GetHashCode() < temp.GetHashCode())
                    i++;
                if (i < j)
                {
                    // 放在temp右边
                    array[j] = array[i];
                    // j左移一位
                    j--;
                }
            }
            // 将temp放在最终位置
            array[i] = temp;
            // 递归地对temp左边的关键字进行排序
            QuickSort(array, low, i - 1);
            // 递归地对temp右边的关键字进行排序
            QuickSort(array, i + 1, high);
        }
        #endregion

        #region 选择类排序
        /// <summary>
        /// (TQ)简单选择排序
        /// </summary>
        /// <param name="array"></param>
        public void SelectSort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int k = i;
                // 从无序序列中跳出一个最小的关键字
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[k].GetHashCode() > array[j].GetHashCode())
                        k = j;
                }
                // 完成最小关键字与无序序列第一个关键字的交换
                T temp = array[i];
                array[i] = array[k];
                array[k] = temp;
            }
        }
        /// <summary>
        /// (TQ)堆排序
        /// </summary>
        /// <param name="array"></param>
        public void HeapSort(T[] array)
        {
            // 建立初始堆
            for (int i = array.Length; i >= 1; i--)
                Sift(array, i, array.Length);
            // 进行 n-1 次循环，完成堆排序
            for (int i = array.Length; i >= 2; i--)
            {
                T temp = array[1];
                array[1] = array[i];
                array[i] = temp;
                // 在减少了1个关键字的无序序列中进行调整
                Sift(array, 1, i - 1);
            }
        }
        /// <summary>
        /// 在数组的low到high的范围内对在位置low上的结点进行调整
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        private void Sift(T[] array, int low, int high)
        {
            // array[j]是array[i]的左孩子结点
            int i = low;
            int j = 2 * i;
            T temp = array[i];
            while (j <= high)
            {
                // 若右孩子较大，则把j指向右孩子
                if (j < high && array[j].GetHashCode() < array[j + 1].GetHashCode())
                {
                    // j变为 2 * i + 1
                    j++;
                }
                if (temp.GetHashCode() < array[j].GetHashCode())
                {
                    // 将array[j]调整到双亲节点的位置上
                    array[i] = array[j];
                    // 修改i和j的值，以便继续向下调整
                    i = j;
                    j = 2 * i;
                }
                else
                    break;
            }
            // 被调整结点的值放入最终位置
            array[i] = temp;
        }
        #endregion

        #region 二路归并排序
        /// <summary>
        /// 二路归并排序
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public void MergeSort(T[] array, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSort(array, low, mid);
                MergeSort(array, mid + 1, high);
                Merge(array, low, mid, high);
            }
        }
        private void Merge(T[] array, int low, int mid, int high)
        {

        }
        #endregion

        #region 基数排序

        #endregion
    }
}

