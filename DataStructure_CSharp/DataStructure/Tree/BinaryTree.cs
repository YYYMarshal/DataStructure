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
        /// 二叉树的层次遍历
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
                    if (tempNode.LeftChild != null)
                        queue.Enqueue(tempNode.LeftChild);
                    if (tempNode.RightChild != null)
                        queue.Enqueue(tempNode.RightChild);
                }
            }
        }
        public void PreorderTraversal(BTNode<T> btNode, Action<BTNode<T>> Visit)
        {
            if (btNode != null)
            {
                Visit(btNode);
                PreorderTraversal(btNode.LeftChild, Visit);
                PreorderTraversal(btNode.RightChild, Visit);
            }
        }
        public void InorderTraversal(BTNode<T> btNode, Action<BTNode<T>> Visit)
        {
            if (btNode != null)
            {
                InorderTraversal(btNode.LeftChild, Visit);
                Visit(btNode);
                InorderTraversal(btNode.RightChild, Visit);
            }
        }
        public void PostorderTraversal(BTNode<T> btNode, Action<BTNode<T>> Visit)
        {
            if (btNode != null)
            {
                PostorderTraversal(btNode.LeftChild, Visit);
                PostorderTraversal(btNode.RightChild, Visit);
                Visit(btNode);
            }
        }
    }
}
