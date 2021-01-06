namespace DataStructure_CSharp
{
    /// <summary>
    /// Sequential/Sequence
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqList<T>
    {
        public T[] Data = new T[GlobalVariable.MaxSize];
        public int Length;
    }
    /// <summary>
    /// 单链表：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LNode<T>
    {
        public T Data;
        public LNode<T> Next;
    }
    /// <summary>
    /// 双链表：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DLNode<T>
    {
        public T Data;
        public DLNode<T> Pre;
        public DLNode<T> Next;
    }
    /// <summary>
    /// 二叉树：结点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BTNode<T>
    {
        public T Data;
        public BTNode<T> LeftChild;
        public BTNode<T> RightChild;
    }

}
