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
        /// <summary>
        /// 单链表的建立：尾插法（带头结点）
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public ListNode<T> CreateListTail(T[] array)
        {
            ListNode<T> list = new ListNode<T>();
            ListNode<T> tailNode = list;
            for (int i = 0; i < array.Length; i++)
            {
                ListNode<T> newNode = new ListNode<T>()
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
        /// (YMW)单链表的建立：头插法（带头结点）
        /// 逆序for循环，最终得到正序的单链表
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public ListNode<T> CreateListHead(T[] array)
        {
            ListNode<T> list = new ListNode<T>();
            for (int i = array.Length - 1; i >= 0; --i)
            {
                ListNode<T> newNode = new ListNode<T>()
                {
                    data = array[i],
                    next = list.next
                };
                list.next = newNode;
            }
            return list;
        }
        /// <summary>
        /// (YMW)单链表的结点插入：在pos位置前插入一个结点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool Insert(ListNode<T> head, T data, int pos)
        {
            Console.WriteLine($"Insert(head, pos = {pos}, data = {data})");
            ListNode<T> node = head;
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
            ListNode<T> newNode = new ListNode<T>()
            {
                data = data,
                next = node.next
            };
            node.next = newNode;
            return true;
        }
        /// <summary>
        /// 单链表的结点删除：根据元素值删除结点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool DeleteByData(ListNode<T> list, T data)
        {
            Console.WriteLine($"DeleteByData(list, data = {data})");
            if (list == null)
                return false;
            // 过滤掉头结点
            ListNode<T> node = list.next;
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
        /// <summary>
        /// (YMW)单链表的删除：通过结点位置删除结点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool DeleteByPosition(ListNode<T> head, int pos)
        {
            Console.WriteLine($"Delete(head, pos = {pos})");
            if (head == null)
                return false;
            ListNode<T> node = head;
            pos -= 1;
            int counter = 0;
            // 寻找第pos个结点，并令node指向其前驱
            // Note: node.next
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
        /// 单链表的结点查找：通过结点值查找结点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public ListNode<T> GetElemByData(ListNode<T> list, T data)
        {
            Console.WriteLine($"GetElemByData(list, data = {data})");
            if (list == null)
                return null;
            // 过滤掉头结点
            ListNode<T> node = list.next;
            while (node != null && !node.data.Equals(data))
                node = node.next;
            return node;
        }
        /// <summary>
        /// (YMW)单链表的结点查找：通过结点位置查找结点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public ListNode<T> GetElemByPosition(ListNode<T> head, int pos)
        {
            Console.WriteLine($"GetElemByPosition(head, pos = {pos})");
            ListNode<T> node = head;
            int counter = 0;
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
        /// Print a singly linked list
        /// </summary>
        /// <param name="list"></param>
        public void Print(ListNode<T> list, string info = "")
        {
            string str = info == "" ? "" : "：" + info;
            Console.WriteLine($"====== 单链表打印{str} ======");
            while (list != null)
            {
                Console.Write(list.data + "  ");
                list = list.next;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// 两个非递减序列的单链表的合并
        /// </summary>
        /// <param name="listOne"></param>
        /// <param name="listTwo"></param>
        /// <returns></returns>
        public static ListNode<T> MergeList(ListNode<T> listOne, ListNode<T> listTwo)
        {
            if (listOne == null && listTwo == null)
                return null;
            else if (listOne == null || listTwo == null)
                return listOne ?? listTwo;

            ListNode<T> tailOne = listOne.next;
            ListNode<T> tailTwo = listTwo.next;
            ListNode<T> list = listOne;
            ListNode<T> tail = list;
            while (tailOne != null && tailTwo != null)
            {
                if (tailOne.data.GetHashCode() <= tailTwo.data.GetHashCode())
                {
                    tail.next = tailOne;
                    tailOne = tailOne.next;
                }
                else
                {
                    tail.next = tailTwo;
                    tailTwo = tailTwo.next;
                }
                tail = tail.next;
            }
            tail.next = tailOne ?? tailTwo;
            return list;
        }
    }
}
