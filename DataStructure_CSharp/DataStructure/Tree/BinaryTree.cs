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
        // https://blog.csdn.net/chenxun_2010/article/details/42365763?utm_medium=distribute.pc_relevant.none-task-blog-BlogCommendFromBaidu-3.control&depth_1-utm_source=distribute.pc_relevant.none-task-blog-BlogCommendFromBaidu-3.control
        /// <summary>
        /// 创建二叉树（从上到下，从左至右）；
        /// 插入过程为先序遍历的顺序
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CreateTree(ref BTNode<T> btNode, T[] array, int index)
        {
            if (index >= array.Length)
                return;
            btNode = new BTNode<T>()
            {
                Data = array[index]
            };
            CreateTree(ref btNode.LeftChild, array, 2 * index + 1);
            CreateTree(ref btNode.RightChild, array, 2 * index + 2);
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
            return Math.Max(GetDepth(btNode.LeftChild), GetDepth(btNode.RightChild)) + 1;
        }
        /// <summary>
        /// 获取树的所有叶子结点的数量
        /// </summary>
        /// <param name="btNode"></param>
        /// <returns></returns>
        public int GetLeafNodeCount(BTNode<T> btNode)
        {
            if (btNode == null)
                return 0;
            else if (btNode.LeftChild == null && btNode.RightChild == null)
                return 1;
            else
                return GetLeafNodeCount(btNode.LeftChild) + GetLeafNodeCount(btNode.RightChild);
        }
        /// <summary>
        /// 获取树的所有结点的数量
        /// </summary>
        /// <param name="btNode"></param>
        /// <returns></returns>
        public int GetAllNodeCount(BTNode<T> btNode)
        {
            if (btNode == null)
                return 0;
            return GetAllNodeCount(btNode.LeftChild) + GetAllNodeCount(btNode.RightChild) + 1;
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
                    BTNode<T> node = queue.Dequeue();
                    callback(node);
                    //callback.Invoke(btNode);
                    if (node.LeftChild != null)
                        queue.Enqueue(node.LeftChild);
                    if (node.RightChild != null)
                        queue.Enqueue(node.RightChild);
                }
            }
        }
        /// <summary>
        /// 先序遍历
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void PreorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode != null)
            {
                callback(btNode);
                PreorderTraversal(btNode.LeftChild, callback);
                PreorderTraversal(btNode.RightChild, callback);
            }
        }
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void InorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode != null)
            {
                InorderTraversal(btNode.LeftChild, callback);
                callback(btNode);
                InorderTraversal(btNode.RightChild, callback);
            }
        }
        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
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
        /// 先序遍历---非递归
        /// </summary>
        public void PreordeTraversalNonRecursion(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode == null)
                return;
            Stack<BTNode<T>> stack = new Stack<BTNode<T>>();
            stack.Push(btNode);
            while (stack.Count != 0)
            {
                BTNode<T> node = stack.Pop();
                callback(node);
                // 必须：先右后左
                if (node.RightChild != null)
                    stack.Push(node.RightChild);
                if (node.LeftChild != null)
                    stack.Push(node.LeftChild);
            }
        }
        /// <summary>
        /// 中序遍历---非递归
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void InorderTraversalNonRecursion(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode == null)
                return;
            Stack<BTNode<T>> stack = new Stack<BTNode<T>>();
            BTNode<T> node = btNode;
            while (stack.Count != 0 || node != null)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.LeftChild;
                }
                if (stack.Count != 0)
                {
                    node = stack.Pop();
                    callback(node);
                    node = node.RightChild;
                }
            }
        }
        /// <summary>
        /// 后序遍历---非递归
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void PostorderTraversalNonRecursion(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode == null)
                return;
            Stack<BTNode<T>> stackOne = new Stack<BTNode<T>>();
            Stack<BTNode<T>> stackTwo = new Stack<BTNode<T>>();
            stackOne.Push(btNode);
            BTNode<T> node;
            while (stackOne.Count != 0)
            {
                node = stackOne.Pop();
                stackTwo.Push(node);
                if (node.LeftChild != null)
                    stackOne.Push(node.LeftChild);
                if (node.RightChild != null)
                    stackTwo.Push(node.RightChild);
            }
            while (stackTwo.Count != 0)
            {
                // 出栈顺序即为后序遍历顺序
                node = stackTwo.Pop();
                callback(node);
            }
        }
    }
}
