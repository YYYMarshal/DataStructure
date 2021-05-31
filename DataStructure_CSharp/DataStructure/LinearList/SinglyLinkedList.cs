using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T>
    {
        #region Create
        /// <summary>
        /// (TQ)单链表的建立：尾插法（带头结点）
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public LNode<T> CreateListTail(T[] array)
        {
            if (array == null)
                return null;
            LNode<T> list = new LNode<T>();
            LNode<T> tailNode = list;
            for (int i = 0; i < array.Length; i++)
            {
                LNode<T> newNode = new LNode<T>()
                {
                    data = array[i]
                };
                tailNode.next = newNode;
                tailNode = tailNode.next;
            }
            tailNode.next = null;
            return list;
        }
        /// <summary>
        /// (TQ)单链表的建立：头插法（带头结点）
        /// 会得到跟数组元素顺序相反的单链表
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public LNode<T> CreateListHead(T[] array)
        {
            if (array == null)
                return null;
            LNode<T> list = new LNode<T>();
            for (int i = 0; i < array.Length; i++)
            {
                LNode<T> newNode = new LNode<T>
                {
                    data = array[i],
                    next = list.next
                };
                list.next = newNode;
            }
            return list;
        }
        /// <summary>
        /// (YWM)头插法建立单链表；
        /// 逆序for循环，最终得到正序的单链表
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public LNode<T> CreateList(T[] array)
        {
            if (array == null)
                return null;
            LNode<T> list = new LNode<T>();
            for (int i = array.Length - 1; i >= 0; --i)
            {
                LNode<T> newNode = new LNode<T>()
                {
                    data = array[i],
                    next = list.next
                };
                list.next = newNode;
            }
            return list;
        }
        #endregion
        #region Get
        /// <summary>
        /// (YWM)通过位置查找元素
        /// </summary>
        /// <param name="head">head为带头结点的单链表的头指针</param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public LNode<T> GetElemByPosition(LNode<T> head, int pos)
        {
            if (head == null)
                return null;
            LNode<T> node = head.next;
            int counter = 1;
            // 顺时针向后查找，直到node指向第pos个元素或node为空
            while (node != null && counter < pos)
            {
                node = node.next;
                ++counter;
            }
            // 第pos个元素不存在
            if (node == null || counter > pos)
                return null;
            return node;
        }
        /// <summary>
        /// 通过结点值查找结点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public LNode<T> GetElemByData(LNode<T> list, T data)
        {
            if (list == null)
                return null;
            // 过滤掉头结点
            LNode<T> node = list.next;
            while (node != null && !node.data.Equals(data))
                node = node.next;
            return node;
        }
        #endregion
        #region Insert
        /// <summary>
        /// (YWM)在带头结点的单链线性表中第pos个位置之前插入元素值为data的元素
        /// </summary>
        /// <param name="head">head为带头结点的单链表的头指针</param>
        /// <param name="pos">在第pos个位置之前！！！</param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Insert(LNode<T> head, int pos, T data)
        {
            LNode<T> node = head;
            int counter = 0;
            // 寻找第pos-1个结点
            pos -= 1;
            while (node != null && counter < pos)
            {
                node = node.next;
                ++counter;
            }
            if (node == null || counter > pos)
                return false;
            LNode<T> newNode = new LNode<T>()
            {
                data = data,
                next = node.next
            };
            node.next = newNode;
            return true;
        }
        #endregion
        #region Delete
        /// <summary>
        /// (YWM)单链表的删除：通过结点位置删除结点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool DeleteByPosition(LNode<T> head, int pos)
        {
            if (head == null)
                return false;
            LNode<T> node = head;
            int counter = 0;
            // 寻找第pos个结点，并令node指向其前驱
            pos -= 1;
            while (node.next != null && counter < pos)
            {
                node = node.next;
                ++counter;
            }
            if (node.next == null || counter > pos)
                return false;
            node.next = node.next.next;
            return true;
        }
        /// <summary>
        /// 单链表的结点删除：根据元素值删除结点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool DeleteByData(LNode<T> list, T data)
        {
            if (list == null)
                return false;
            // 过滤掉头结点
            LNode<T> node = list.next;
            while (node.next != null)
            {
                if (node.next.data.Equals(data))
                {
                    node.next = node.next.next;
                    return true;
                }
                node = node.next;
            }
            return false;
        }
        #endregion
        #region Print
        /// <summary>
        /// (My)Print a singly linked list
        /// </summary>
        /// <param name="list"></param>
        public void Print(LNode<T> list)
        {
            Console.WriteLine($"====== 单链表打印 ======");
            while (list != null)
            {
                Console.Write(list.data + "  ");
                list = list.next;
            }
            Console.WriteLine("\n");
        }
        #endregion
        #region Others
        /// <summary>
        /// (LeetCode)两个非递减序列的单链表的合并
        /// </summary>
        /// <param name="listOne"></param>
        /// <param name="listTwo"></param>
        /// <returns></returns>
        public LNode<T> MergeList(LNode<T> listOne, LNode<T> listTwo)
        {
            LNode<T> list = new LNode<T>();
            LNode<T> tailNode = list;
            while (listOne != null && listTwo != null)
            {
                if (listOne.data.GetHashCode() <= listTwo.data.GetHashCode())
                {
                    tailNode.next = listOne;
                    listOne = listOne.next;
                }
                else
                {
                    tailNode.next = listTwo;
                    listTwo = listTwo.next;
                }
                tailNode = tailNode.next;
            }
            tailNode.next = listOne ?? listTwo;
            return list.next;
        }
        #endregion
    }
}
