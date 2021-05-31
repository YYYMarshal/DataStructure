using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    #region Linear List
    /// <summary>
    /// SequentialList
    /// 顺序表：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqList<T>
    {
        public T[] data = new T[GlobalVariable.MaxSize];
        public int length;
    }
    /// <summary>
    /// SinglyLinkedListNode
    /// 单链表（链栈）：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LNode<T>
    {
        public T data;
        public LNode<T> next;
    }
    /// <summary>
    /// DoubleLinkedListNode
    /// 双（向）链表：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DLNode<T>
    {
        public T data;
        public DLNode<T> pre;
        public DLNode<T> next;
    }
    #endregion

    #region Stack
    /// <summary>
    /// SequentialStack
    /// 顺序栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqStack<T>
    {
        public T[] data = new T[GlobalVariable.MaxSize];
        public int top;
    }
    #endregion

    #region Queue
    /// <summary>
    /// SequentialQueue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqQueue<T>
    {
        public T[] data = new T[GlobalVariable.MaxSize];
        /// <summary>
        /// 队首指针
        /// </summary>
        public int front;
        /// <summary>
        /// 队尾指针
        /// </summary>
        public int rear;
    }
    /// <summary>
    /// QueueNode
    /// 队列：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QNode<T>
    {
        public T data;
        public QNode<T> next;
    }
    /// <summary>
    /// LinkedQueue
    /// 链队
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LiQueue<T>
    {
        /// <summary>
        /// 队头指针
        /// </summary>
        public LiQueue<T> front;
        /// <summary>
        /// 队尾指针
        /// </summary>
        public LiQueue<T> rear;
    }
    #endregion

    #region Tree
    /// <summary>
    /// BinaryTreeNode
    /// 二叉树：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BTNode<T>
    {
        public T data;
        public BTNode<T> leftChild;
        public BTNode<T> rightChild;
    }
    #endregion
}
