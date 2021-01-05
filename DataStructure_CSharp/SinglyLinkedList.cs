using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
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
        /// 尾插法
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public LNode<T> CreateListTail(T[] array)
        {
            LNode<T> node = new LNode<T>
            {
                Next = null
            };
            LNode<T> tailNode = node;
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
            return node.Next;
        }
        /// <summary>
        /// 头插法
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public LNode<T> CreateListHead(T[] array)
        {
            LNode<T> node = new LNode<T>()
            {
                Next = null
            };
            for (int i = 0; i < array.Length; i++)
            {
                LNode<T> newNode = new LNode<T>()
                {
                    Data = array[i],
                    Next = node.Next
                };
                node.Next = newNode;
            }
            return node.Next;
        }
        /// <summary>
        /// 根据元素值删除结点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete(LNode<T> node, T data)
        {
            LNode<T> tempNode = node;
            while (tempNode.Next != null)
            {
                if (tempNode.Next.Data.Equals(data))
                    break;
                tempNode = tempNode.Next;
            }
            if (tempNode.Next == null)
                return false;
            else
            {
                tempNode.Next = tempNode.Next.Next;
                return true;
            }
        }
    }
}
