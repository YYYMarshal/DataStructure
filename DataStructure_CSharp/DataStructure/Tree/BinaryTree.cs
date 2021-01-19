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
        public void Create(ref BTNode<T> btNode, T[] array, int index)
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
        /// <summary>
        /// 二叉树：层次遍历
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="callback"></param>
        public void LevelTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
        {
            Queue<BTNode<T>> queue = new Queue<BTNode<T>>();
            if (btNode == null)
                return;
            queue.Enqueue(btNode);
            while (queue.Count != 0)
            {
                BTNode<T> node = queue.Dequeue();
                callback(node);
                //callback.Invoke(btNode);
                if (node.leftChild != null)
                    queue.Enqueue(node.leftChild);
                if (node.rightChild != null)
                    queue.Enqueue(node.rightChild);
            }
        }
        /// <summary>
        /// 二叉树：先序遍历
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
        /// 二叉树：中序遍历
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
        /// 二叉树：后序遍历
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
        /// <summary>
        /// 二叉树：先序遍历---非递归
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
                if (node.rightChild != null)
                    stack.Push(node.rightChild);
                if (node.leftChild != null)
                    stack.Push(node.leftChild);
            }
        }
        /// <summary>
        /// 二叉树：中序遍历---非递归
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
        /// 二叉树：后序遍历---非递归
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
                if (node.leftChild != null)
                    stackOne.Push(node.leftChild);
                if (node.rightChild != null)
                    stackTwo.Push(node.rightChild);
            }
            while (stackTwo.Count != 0)
            {
                // 出栈顺序即为后序遍历顺序
                node = stackTwo.Pop();
                callback(node);
            }
        }
        /// <summary>
        /// 二叉树：获取树的深度（递归）
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
        /// 二叉树：获取树的所有叶子结点的数量
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
        /// 二叉树：获取树的所有结点的数量
        /// </summary>
        /// <param name="btNode"></param>
        /// <returns></returns>
        public int GetAllNodeCount(BTNode<T> btNode)
        {
            if (btNode == null)
                return 0;
            return GetAllNodeCount(btNode.leftChild) + GetAllNodeCount(btNode.rightChild) + 1;
        }
    }
}
