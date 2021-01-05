using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
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
        public void LevelTraversal(BTNode<T> bTNode, Action<BTNode<T>> Visit)
        {
            Queue<BTNode<T>> que = new Queue<BTNode<T>>();
            if (bTNode != null)
            {
                que.Enqueue(bTNode);
                while (que.Count != 0)
                {
                    BTNode<T> tempNode = que.Dequeue();
                    Visit(tempNode);
                    if (tempNode.LeftChild != null)
                        que.Enqueue(tempNode.LeftChild);
                    if (tempNode.RightChild != null)
                        que.Enqueue(tempNode.RightChild);
                }
            }
        }
        public void PreorderTraversal(BTNode<T> bTNode, Action<BTNode<T>> Visit)
        {
            if (bTNode != null)
            {
                Visit(bTNode);
                PreorderTraversal(bTNode.LeftChild, Visit);
                PreorderTraversal(bTNode.RightChild, Visit);
            }
        }
        public void InorderTraversal(BTNode<T> bTNode, Action<BTNode<T>> Visit)
        {
            if (bTNode != null)
            {
                InorderTraversal(bTNode.LeftChild, Visit);
                Visit(bTNode);
                InorderTraversal(bTNode.RightChild, Visit);
            }
        }
        public void PostorderTraversal(BTNode<T> bTNode, Action<BTNode<T>> Visit)
        {
            if (bTNode != null)
            {
                PostorderTraversal(bTNode.LeftChild, Visit);
                PostorderTraversal(bTNode.RightChild, Visit);
                Visit(bTNode);
            }
        }
    }
}
