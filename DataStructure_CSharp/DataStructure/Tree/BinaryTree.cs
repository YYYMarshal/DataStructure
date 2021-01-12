using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    /// <summary>
    /// 二叉树
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T>
    {
        private static readonly Lazy<BinaryTree<T>> lazy = new Lazy<BinaryTree<T>>(() => new BinaryTree<T>());
        public static BinaryTree<T> Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        /// <summary>
        /// 获取树的深度（递归）
        /// </summary>
        /// <param name="btNode"></param>
        /// <returns></returns>
        public int GetDepth(BTNode<T> btNode)
        {
            if (btNode == null)
                return 0;
            return Math.Max(GetDepth(btNode.LeftChild), GetDepth(btNode.RightChild) + 1);
        }
        /// <summary>
        /// 获取叶子结点的数量
        /// </summary>
        /// <param name="btNode"></param>
        /// <returns></returns>
        public int GetLeafCount(BTNode<T> btNode)
        {
            if (btNode == null)
                return 0;
            else if (btNode.LeftChild == null && btNode.RightChild == null)
                return 1;
            else
                return GetLeafCount(btNode.LeftChild) + GetLeafCount(btNode.RightChild);
        }
        /// <summary>
        /// 获取树的结点的数量
        /// </summary>
        /// <param name="btNode"></param>
        /// <returns></returns>
        public int GetTreeNodeSize(BTNode<T> btNode)
        {
            if (btNode == null)
                return 0;
            return GetTreeNodeSize(btNode.LeftChild) + GetTreeNodeSize(btNode.RightChild) + 1;
        }
        /// <summary>
        /// 二叉树：层次遍历
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void LevelTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            Queue<BTNode<T>> queue = new Queue<BTNode<T>>();
            if (btNode != null)
            {
                queue.Enqueue(btNode);
                while (queue.Count != 0)
                {
                    BTNode<T> tempNode = queue.Dequeue();
                    callback(tempNode);
                    //callback.Invoke(btNode);
                    if (tempNode.LeftChild != null)
                        queue.Enqueue(tempNode.LeftChild);
                    if (tempNode.RightChild != null)
                        queue.Enqueue(tempNode.RightChild);
                }
            }
        }
        public void PreorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode != null)
            {
                callback(btNode);
                PreorderTraversal(btNode.LeftChild, callback);
                PreorderTraversal(btNode.RightChild, callback);
            }
        }
        public void InorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode != null)
            {
                InorderTraversal(btNode.LeftChild, callback);
                callback(btNode);
                InorderTraversal(btNode.RightChild, callback);
            }
        }
        public void PostorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode != null)
            {
                PostorderTraversal(btNode.LeftChild, callback);
                PostorderTraversal(btNode.RightChild, callback);
                callback(btNode);
            }
        }
        /// <summary>
        /// 先序非递归遍历
        /// </summary>
        public void PreordeTraversalNonRecursion(BTNode<T> btNode,Action<BTNode<T>> callback)
        {
            if (btNode == null)
                return;
            Stack<BTNode<T>> stack = new Stack<BTNode<T>>();
            BTNode<T> targetNode = null;
            stack.Push(btNode);
            while (stack.Count!=0)
            {
                targetNode = stack.Pop();
                callback(targetNode);
                if (targetNode.RightChild != null)
                    stack.Push(targetNode.RightChild);
                if (targetNode.LeftChild != null)
                    stack.Push(targetNode.LeftChild);
            }
        }
    }
}
