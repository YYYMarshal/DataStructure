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
        #region Create
        // https://blog.csdn.net/chenxun_2010/article/details/42365763?utm_medium=distribute.pc_relevant.none-task-blog-BlogCommendFromBaidu-3.control&depth_1-utm_source=distribute.pc_relevant.none-task-blog-BlogCommendFromBaidu-3.control
        /// <summary>
        /// (CSDN)创建二叉树（从上到下，从左至右）；
        /// 插入过程为先序遍历的顺序
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void Create(ref BTNode<T> btNode, T[] array, int index = 0)
        {
            if (index >= array.Length)
                return;
            btNode = new BTNode<T>()
            {
                data = array[index]
            };
            Create(ref btNode.leftChild, array, 2 * index + 1);
            Create(ref btNode.rightChild, array, 2 * index + 2);
        }
        #endregion

        #region Traversal
        /// <summary>
        /// (TQ)层次遍历
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void LevelTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode == null)
                return;
            Queue<BTNode<T>> queue = new Queue<BTNode<T>>();
            queue.Enqueue(btNode);
            while (queue.Count != 0)
            {
                BTNode<T> node = queue.Dequeue();
                callback?.Invoke(node);
                if (node.leftChild != null)
                    queue.Enqueue(node.leftChild);
                if (node.rightChild != null)
                    queue.Enqueue(node.rightChild);
            }
        }
        #endregion

        #region Traversal Recursion
        /// <summary>
        /// (TQ)先序遍历
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void PreorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode != null)
            {
                callback(btNode);
                PreorderTraversal(btNode.leftChild, callback);
                PreorderTraversal(btNode.rightChild, callback);
            }
        }
        /// <summary>
        /// (TQ)中序遍历
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void InorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode != null)
            {
                InorderTraversal(btNode.leftChild, callback);
                callback(btNode);
                InorderTraversal(btNode.rightChild, callback);
            }
        }
        /// <summary>
        /// (TQ)后序遍历
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void PostorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode != null)
            {
                PostorderTraversal(btNode.leftChild, callback);
                PostorderTraversal(btNode.rightChild, callback);
                callback(btNode);
            }
        }
        #endregion

        #region Non-Recursion Traversal 
        /// <summary>
        /// (TQ)先序遍历---非递归
        /// </summary>
        public void PreordeNonRecursionTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
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
                if (node.rightChild != null)
                    stack.Push(node.rightChild);
                if (node.leftChild != null)
                    stack.Push(node.leftChild);
            }
        }
        /// <summary>
        /// (TQ)中序遍历---非递归
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void InorderNonRecursionTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            if (btNode == null)
                return;
            Stack<BTNode<T>> stack = new Stack<BTNode<T>>();
            BTNode<T> node = btNode;
            while (stack.Count != 0 || node != null)
            {
                // 左孩子存在，则左孩子入栈
                while (node != null)
                {
                    stack.Push(node);
                    node = node.leftChild;
                }
                if (stack.Count != 0)
                {
                    node = stack.Pop();
                    callback(node);
                    node = node.rightChild;
                }
            }
        }
        /// <summary>
        /// (TQ)后序遍历---非递归
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void PostorderNonRecursionTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
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
                // 注意和先序非递归遍历的区别，这里是先左后右
                if (node.leftChild != null)
                    stackOne.Push(node.leftChild);
                if (node.rightChild != null)
                    //stackTwo.Push(node.rightChild);
                    stackOne.Push(node.rightChild);
            }
            while (stackTwo.Count != 0)
            {
                // 出栈顺序即为后序遍历顺序列
                node = stackTwo.Pop();
                callback(node);
            }
        }
        #endregion

        #region Get Info
        /// <summary>
        /// (LeetCode TQ)获取树的深度（递归）
        /// </summary>
        /// <param name="btNode"></param>
        /// <returns></returns>
        public int GetDepth(BTNode<T> btNode)
        {
            if (btNode == null)
                return 0;
            return Math.Max(GetDepth(btNode.leftChild), GetDepth(btNode.rightChild)) + 1;
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
            else if (btNode.leftChild == null && btNode.rightChild == null)
                return 1;
            else
                return GetLeafNodeCount(btNode.leftChild) + GetLeafNodeCount(btNode.rightChild);
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
            return GetAllNodeCount(btNode.leftChild) + GetAllNodeCount(btNode.rightChild) + 1;
        }
        #endregion
    }
}


