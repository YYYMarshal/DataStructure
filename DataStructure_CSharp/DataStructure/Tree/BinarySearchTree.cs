using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    /// <summary>
    /// 二叉搜索树（BST）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> : BinaryTree<T>
    {
        private static readonly Lazy<BinarySearchTree<T>> lazy =
            new Lazy<BinarySearchTree<T>>(() => new BinarySearchTree<T>());
        public static new BinarySearchTree<T> Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        /// <summary>
        /// 二叉搜索树：线性查找
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public BTNode<T> LinearSearch(BTNode<T> root, T key)
        {
            while (root != null)
            {
                if (key.Equals(root.Data))
                    return root;
                else if (key.GetHashCode() < root.Data.GetHashCode())
                    root = root.LeftChild;
                else
                    root = root.RightChild;
            }
            return null;
        }
        /// <summary>
        /// 二叉搜索树：递归查找
        /// </summary>
        /// <param name="root"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public BTNode<T> RecursionSearch(BTNode<T> root, T data)
        {
            if (root == null)
                return null;
            if (data.Equals(root.Data))
                return root;
            else if (data.GetHashCode() < root.Data.GetHashCode())
                return RecursionSearch(root.LeftChild, data);
            else
                return RecursionSearch(root.RightChild, data);
        }
        /// <summary>
        /// 二叉搜索树：递归查找；out查找结点
        /// </summary>
        /// <param name="p"></param>
        /// <param name="data"></param>
        /// <param name="bTParent"></param>
        /// <returns></returns>
        public BTNode<T> RecursionSearch(BTNode<T> root, T data, out BTNode<T> btParent)
        {
            btParent = null;
            if (root == null)
            {
                btParent = null;
                return null;
            }
            if (data.Equals(root.Data))
                return root;
            else
            {
                btParent = root;
                if (data.GetHashCode() < root.Data.GetHashCode())
                    return RecursionSearch(btParent.LeftChild, data, out btParent);
                else
                    return RecursionSearch(btParent.RightChild, data, out btParent);
            }

        }
        /// <summary>
        /// 二叉搜索树的插入
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Insert(ref BTNode<T> btNode, T data)
        {
            if (btNode == null)
            {
                btNode = new BTNode<T>()
                {
                    Data = data,
                    LeftChild = null,
                    RightChild = null
                };
                return true;
            }
            //if (Data.GetHashCode() == bTNode.Data.GetHashCode())
            if (data.Equals(btNode.Data))
                return false;
            else if (data.GetHashCode() < btNode.Data.GetHashCode())
                return Insert(ref btNode.LeftChild, data);
            else
                return Insert(ref btNode.RightChild, data);
        }

        /// <summary>
        /// 二叉搜索树的初始化（建立）
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public BTNode<T> InitBinarySearchTree(params T[] array)
        {
            BTNode<T> btNode = null;
            for (int i = 0; i < array.Length; i++)
            {
                if (Insert(ref btNode, array[i]))
                    Console.WriteLine($"插入 {array[i]} 成功");
                else
                    Console.WriteLine($"插入 {array[i]} 失败");
            }
            return btNode;
        }

    }
}
