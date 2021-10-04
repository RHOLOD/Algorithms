using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProjectAlgo3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DynArray<int> dynArray = new DynArray<int>();
            for (int i = 0; i < 14; i++)
            {
                dynArray.Append(i);
            }
            int[] expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 0, 0 };
            int[] actual = dynArray.array;
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            DynArray<int> dynArray = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                dynArray.Append(i);
            }
            dynArray.Insert(111, 15);
            int[] expected = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 111, 15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            int[] actual = dynArray.array;
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            DynArray<int> dynArray = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                dynArray.Append(i);
            }
            dynArray.Insert(111, 16);
            int[] expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 111, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] actual = dynArray.array;
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            DynArray<int> dynArray = new DynArray<int>();
            for (int i = 0; i < 8; i++)
            {
                dynArray.Append(i);
            }
            dynArray.Insert(111, 16);
            int[] expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] actual = dynArray.array;
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod5()
        {
            DynArray<int> dynArray = new DynArray<int>();
            for (int i = 0; i < 8; i++)
            {
                dynArray.Append(i);
            }
            dynArray.Insert(111, 14);
            int[] expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] actual = dynArray.array;
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod6()
        {
            DynArray<int> dynArray = new DynArray<int>();
            for (int i = 0; i < 8; i++)
            {
                dynArray.Append(i);
            }
            dynArray.Insert(111, 18);
            int[] expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] actual = dynArray.array;
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
