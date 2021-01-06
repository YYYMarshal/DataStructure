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
        private static readonly Lazy<SinglyLinkedList<T>> lazy = new Lazy<SinglyLinkedList<T>>(() => new SinglyLinkedList<T>());
        public static SinglyLinkedList<T> Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        /// <summary>
        /// 单链表的建立：尾插法
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public LNode<T> CreateListTail(T[] array)
        {
            LNode<T> list = new LNode<T>
            {
                Next = null
            };
            LNode<T> tailNode = list;
            for (int i = 0; i < array.Length; i++)
            {
                LNode<T> newNode = new LNode<T>()
                {
                    Data = array[i]
                };
                tailNode.Next = newNode;
                tailNode = tailNode.Next;
            }
            tailNode.Next = null;
            return list.Next;
        }
        /// <summary>
        /// 单链表的建立：头插法
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public LNode<T> CreateListHead(T[] array)
        {
            LNode<T> list = new LNode<T>()
            {
                Next = null
            };
            for (int i = 0; i < array.Length; i++)
            {
                LNode<T> newNode = new LNode<T>()
                {
                    Data = array[i],
                    Next = list.Next
                };
                list.Next = newNode;
            }
            return list.Next;
        }
        /// <summary>
        /// 单链表的删除：根据元素值删除结点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete(LNode<T> list, T data)
        {
            LNode<T> targetNode = list;
            while (targetNode.Next != null)
            {
                if (targetNode.Next.Data.Equals(data))
                    break;
                targetNode = targetNode.Next;
            }
            if (targetNode.Next == null)
                return false;
            else
            {
                targetNode.Next = targetNode.Next.Next;
                return true;
            }
        }
    }
}
