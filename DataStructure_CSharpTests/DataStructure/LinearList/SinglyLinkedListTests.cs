using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructure_CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp.Tests
{
    [TestClass()]
    public class SinglyLinkedListTests
    {
        [TestMethod()]
        public void CreateListTailTest()
        {
            SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();
            int[] array = { 1, 2, 3, 4, 5, 6 };
            ListNode<int> list = singlyLinkedList.CreateListTail(array);
            
        }

        [TestMethod()]
        public void CreateListHeadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertHeadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteByDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteByPositionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNodeByDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNodeByPositionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PrintTest()
        {
            Assert.Fail();
        }
    }
}