namespace DataStructure_CSharp
{
    /// <summary>
    /// Sequential/Sequence List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqList<T>
    {
        public T[] data = new T[GlobalVariable.MaxSize];
        public int length;
    }
    /// <summary>
    /// Definition for singly-linked list.
    /// 单链表：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListNode<T>
    {
        public T data;
        public ListNode<T> next;
    }
    /// <summary>
    /// 双（向）链表：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleListNode<T>
    {
        public T data;
        public DoubleListNode<T> pre;
        public DoubleListNode<T> next;
    }
    /// <summary>
    /// 顺序栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqStack<T>
    {
        public T[] data = new T[GlobalVariable.MaxSize];
        public int top;
    }
    /// <summary>
    /// 二叉树：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BTNode<T>
    {
        public T data;
        public BTNode<T> leftChild;
        public BTNode<T> rightChild;
    }

}
