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
        /// 单链表的建立：尾插法（带头结点0）
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
            //return list.next;
        }
        /// <summary>
        /// 单链表的建立：头插法（带头结点0）
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public ListNode<T> CreateListHead(T[] array)
        {
            ListNode<T> list = new ListNode<T>();
            for (int i = 0; i < array.Length; i++)
            {
                ListNode<T> newNode = new ListNode<T>()
                {
                    data = array[i],
                    next = list.next
                };
                list.next = newNode;
            }
            return list;
            //return list.next;
        }
        /// <summary>
        /// My：在pos位置插入一个结点（头插法）
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool InsertHead(ListNode<T> list, T data, int pos)
        {
            if (pos < 0)
                return false;
            ListNode<T> node = list;
            for (int i = 0; i < pos; i++)
            {
                if (node.next == null)
                    return false;
                node = node.next;
            }
            ListNode<T> newNode = new ListNode<T>()
            {
                data = data,
                next = node.next
            };
            node.next = newNode;
            return true;
        }
        /// <summary>
        /// My：在pos位置插入一个结点（尾插法）
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool InsertTail(ListNode<T> list, T data, int pos)
        {
            if (pos < 0)
                return false;
            ListNode<T> node = list;
            for (int i = 0; i < pos; i++)
            {
                if (node.next == null)
                    return false;
                node = node.next;
            }
            ListNode<T> newNode = new ListNode<T>()
            {
                data = data
            };
            node.next = newNode;
            node = node.next;
            node.next = null;
            return true;
        }
        /// <summary>
        /// 单链表的删除：根据元素值删除结点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool DeleteByData(ListNode<T> list, T data)
        {
            ListNode<T> node = list;
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
        /// 单链表的删除（My）：通过结点位置删除结点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool DeleteByPosition(ListNode<T> list, int pos)
        {
            if (pos < 0)
                return false;
            ListNode<T> node = list;
            for (int i = 0; i < pos; i++)
            {
                if (node.next == null)
                    return false;
                node = node.next;
            }
            node.next = node.next.next;
            return true;
        }
        /// <summary>
        /// 单链表的结点查找：通过结点值查找结点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public ListNode<T> GetNodeByData(ListNode<T> list, T data)
        {
            ListNode<T> node = list;
            while (node != null && !node.data.Equals(data))
                node = node.next;
            return node;
        }
        /// <summary>
        /// 单链表的结点查找：通过结点位置查找结点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public ListNode<T> GetNodeByPosition(ListNode<T> list, int pos)
        {
            if (pos < 0)
                return null;
            ListNode<T> node = list;
            for (int i = 0; i < pos; i++)
            {
                if (node.next == null)
                    return null;
                node = node.next;
            }
            return node;
        }
        /// <summary>
        /// My: Print a singly linked list
        /// </summary>
        /// <param name="list"></param>
        public void Print(ListNode<T> list)
        {
            Console.WriteLine("====== 单链表打印 ======");
            if (list == null)
            {
                Console.WriteLine("null");
                return;
            }
            while (list.next != null)
            {
                Console.WriteLine(list.next.data);
                list = list.next;
            }
        }
    }
}
