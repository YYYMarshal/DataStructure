using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
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
        public BTNode<T> LinearSearch(BTNode<T> p, T key)
        {
            while (p != null)
            {
                if (key.Equals(p.Data))
                    return p;
                else if (key.GetHashCode() < p.Data.GetHashCode())
                    p = p.LeftChild;
                else
                    p = p.RightChild;
            }
            return null;
        }
        /// <summary>
        /// 二叉搜索树：递归查找
        /// </summary>
        public BTNode<T> RecursionSearch(BTNode<T> p, T data)
        {
            if (p == null)
                return null;
            if (data.Equals(p.Data))
                return p;
            else if (data.GetHashCode() < p.Data.GetHashCode())
                return RecursionSearch(p.LeftChild, data);
            else
                return RecursionSearch(p.RightChild, data);
        }
        /// <summary>
        /// 二叉搜索树：递归查找；out查找结点
        /// </summary>
        public BTNode<T> RecursionSearch(BTNode<T> p, T data, out BTNode<T> bTParent)
        {
            bTParent = null;
            if (p == null)
            {
                bTParent = null;
                return null;
            }
            if (data.Equals(p.Data))
                return p;
            else
            {
                bTParent = p;
                if (data.GetHashCode() < p.Data.GetHashCode())
                    return RecursionSearch(bTParent.LeftChild, data, out bTParent);
                else
                    return RecursionSearch(bTParent.RightChild, data, out bTParent);
            }

        }
        public bool Insert(ref BTNode<T> bTNode, T data)
        {
            if (bTNode == null)
            {
                bTNode = new BTNode<T>()
                {
                    Data = data,
                    LeftChild = null,
                    RightChild = null
                };
                return true;
            }
            //if (Data.GetHashCode() == bTNode.Data.GetHashCode())
            if (data.Equals(bTNode.Data))
                return false;
            else if (data.GetHashCode() < bTNode.Data.GetHashCode())
                return Insert(ref bTNode.LeftChild, data);
            else
                return Insert(ref bTNode.RightChild, data);
        }

        public BTNode<T> InitBST(params T[] dataArray)
        {
            BTNode<T> bTNode = null;
            for (int i = 0; i < dataArray.Length; i++)
            {
                if (Insert(ref bTNode, dataArray[i]))
                    Console.WriteLine($"插入 {dataArray[i]} 成功");
                else
                    Console.WriteLine($"插入 {dataArray[i]} 失败");
            }
            return bTNode;
        }

    }
}
