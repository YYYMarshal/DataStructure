﻿using System;
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
        /// <summary>
        /// 二叉搜索树的初始化（建立）
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public BTNode<T> CreateBinarySearchTree(params T[] array)
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
            if (data.Equals(btNode.Data))
                return false;
            else if (data.GetHashCode() < btNode.Data.GetHashCode())
                return Insert(ref btNode.LeftChild, data);
            else
                return Insert(ref btNode.RightChild, data);
        }

        /// <summary>
        /// 二叉搜索树：线性查找
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public BTNode<T> LinearSearch(BTNode<T> btNode, T data)
        {
            while (btNode != null)
            {
                if (data.Equals(btNode.Data))
                    return btNode;
                else if (data.GetHashCode() < btNode.Data.GetHashCode())
                    btNode = btNode.LeftChild;
                else
                    btNode = btNode.RightChild;
            }
            return null;
        }
        /// <summary>
        /// 二叉搜索树：递归查找
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public BTNode<T> RecursionSearch(BTNode<T> btNode, T data)
        {
            if (btNode == null)
                return null;
            if (data.Equals(btNode.Data))
                return btNode;
            else if (data.GetHashCode() < btNode.Data.GetHashCode())
                return RecursionSearch(btNode.LeftChild, data);
            else
                return RecursionSearch(btNode.RightChild, data);
        }
        /// <summary>
        /// 二叉搜索树：递归查找；out查找结点
        /// </summary>
        /// <param name="btNode"></param>
        /// <param name="data"></param>
        /// <param name="btParent"></param>
        /// <returns></returns>
        public BTNode<T> RecursionSearch(BTNode<T> btNode, T data, out BTNode<T> btParent)
        {
            btParent = null;
            if (btNode == null)
            {
                btParent = null;
                return null;
            }
            if (data.Equals(btNode.Data))
                return btNode;
            else
            {
                btParent = btNode;
                if (data.GetHashCode() < btNode.Data.GetHashCode())
                    return RecursionSearch(btParent.LeftChild, data, out btParent);
                else
                    return RecursionSearch(btParent.RightChild, data, out btParent);
            }

        }
    }
}
