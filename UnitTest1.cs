using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestAlgo7
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Тест проверяет добавление элементов.
            OrderedList<int> orderedList = new OrderedList<int>(true);
            LinkedList<int> expected = new LinkedList<int>();
            LinkedList<int> actual = new LinkedList<int>();

            actual.AddLast(1);
            actual.AddLast(10);
            actual.AddLast(20);
            actual.AddLast(25);
            actual.AddLast(30);

            orderedList.Add(10);
            orderedList.Add(20);
            orderedList.Add(30);
            orderedList.Add(25);
            orderedList.Add(1);

            while (orderedList.head != null)
            {
                expected.AddLast(orderedList.head.value);
                orderedList.head = orderedList.head.next;
            }
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
