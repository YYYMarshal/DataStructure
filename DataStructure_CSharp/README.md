# DataStructure

# Before

1. TestSinglyLinkedList
   1. Create
      1. CreateListTail(T[] array)
      2. CreateListHead(T[] array)
      3. CreateList(T[] array)
   2. GetElem
      1. GetElemByPosition(LNode<T> head, int pos)
      2. GetElemeByData(LNode<T> list, T data)
   3. Insert
      1. Insert(LNode<T> head, int pos, T data)
   4. Delete
      1. DeleteByPosition(LNode<T> head, int pos)
      2. DeleteByData(LNode<T> list, T data)
   5. Merge
      1. MergeList(LNode<T> listOne, LNode<T> listTwo)
2. TestBinaryTree
   1. Create
      1. Create(ref BTNode<T> btNode, T[] arrya, int inde = 0)
   2. Recursion Traversal
      1. PreorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
      2. InorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
      3. PostorderTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
   3. Non-Recursion Traversal
      1. PreorderNonRecursionTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
      2. InorderNonRecursionTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
      3. PostorderNonRecursionTraversal(BTNode<T> btNode, Action<BTNode<T>> callback)
   4. Get
      1. GetDepth(BTNode<T> btNode)
      2. GetLeafNodeCount(BTNode<T> btNode)
      3. GetAllNodeCount(BTNode<T> btNode)



# 2021-6-17 11:28:27

1. TestSortAlgorithm
   1. InsertSort
   2. BubbleSort