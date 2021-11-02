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
            // Тест проверяет добавление элементов по возростанию.
            OrderedList<int> orderedList = new OrderedList<int>(true);
            LinkedList<int> expected = new LinkedList<int>();
            LinkedList<int> actual = new LinkedList<int>();

            actual.AddLast(1);
            actual.AddLast(10);
            actual.AddLast(20);
            actual.AddLast(25);
            actual.AddLast(26);
            actual.AddLast(30);
            actual.AddLast(40);

            orderedList.Add(10);
            orderedList.Add(20);
            orderedList.Add(30);
            orderedList.Add(25);
            orderedList.Add(1);
            orderedList.Add(40);
            orderedList.Add(26);

            while (orderedList.head != null)
            {
                expected.AddLast(orderedList.head.value);
                orderedList.head = orderedList.head.next;
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            OrderedList<int> orderedList = new OrderedList<int>(true);
            LinkedList<int> expected = new LinkedList<int>();
            LinkedList<int> actual = new LinkedList<int>();

            actual.AddLast(40);
            actual.AddLast(30);
            actual.AddLast(25);
            actual.AddLast(20);
            actual.AddLast(10);
            actual.AddLast(1);

            orderedList.Add(10);
            orderedList.Add(20);
            orderedList.Add(30);
            orderedList.Add(25);
            orderedList.Add(1);
            orderedList.Add(40);

            while (orderedList.tail != null)
            {
                expected.AddLast(orderedList.tail.value);
                orderedList.tail = orderedList.tail.prev;
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            // Тест проверяет добавление элементов по убыванию.
            OrderedList<int> orderedList = new OrderedList<int>(false);
            LinkedList<int> expected = new LinkedList<int>();
            LinkedList<int> actual = new LinkedList<int>();

            actual.AddLast(40);
            actual.AddLast(30);
            actual.AddLast(26);
            actual.AddLast(25);
            actual.AddLast(20);
            actual.AddLast(10);
            actual.AddLast(1);

            orderedList.Add(10);
            orderedList.Add(20);
            orderedList.Add(30);
            orderedList.Add(25);
            orderedList.Add(1);
            orderedList.Add(40);
            orderedList.Add(26);

            while (orderedList.head != null)
            {
                expected.AddLast(orderedList.head.value);
                orderedList.head = orderedList.head.next;
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            // Тест проверяет добавление элементов по возростанию.
            OrderedList<string> orderedList = new OrderedList<string>(true);
            LinkedList<string> expected = new LinkedList<string>();
            LinkedList<string> actual = new LinkedList<string>();

            actual.AddLast("a");
            actual.AddLast("b");
            actual.AddLast("c");
            actual.AddLast("d");
            actual.AddLast("e");

            orderedList.Add("a");
            orderedList.Add("b");
            orderedList.Add("e");
            orderedList.Add("d");
            orderedList.Add("c");


            while (orderedList.head != null)
            {
                expected.AddLast(orderedList.head.value);
                orderedList.head = orderedList.head.next;
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod5()
        {
            // Тест проверяет удаление элемента.
            OrderedList<string> orderedList = new OrderedList<string>(true);
            LinkedList<string> expected = new LinkedList<string>();
            LinkedList<string> actual = new LinkedList<string>();

            actual.AddLast("b");
            actual.AddLast("d");

            orderedList.Add("a");
            orderedList.Add("b");
            orderedList.Add("d");
            orderedList.Add("e");
            orderedList.Delete("e");
            orderedList.Delete("a");


            while (orderedList.head != null)
            {
                expected.AddLast(orderedList.head.value);
                orderedList.head = orderedList.head.next;
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod6()
        {
            // Тест проверяет добавление элементов по возростанию.
            OrderedList<int> orderedList = new OrderedList<int>(true);
            LinkedList<int> expected = new LinkedList<int>();
            LinkedList<int> actual = new LinkedList<int>();

            actual.AddLast(0);
            actual.AddLast(0);
            actual.AddLast(1);
            actual.AddLast(1);
            actual.AddLast(1);
            actual.AddLast(2);
            actual.AddLast(2);

            orderedList.Add(0);
            orderedList.Add(2);
            orderedList.Add(1);
            orderedList.Add(1);
            orderedList.Add(2);
            orderedList.Add(1);
            orderedList.Add(0);

            while (orderedList.head != null)
            {
                expected.AddLast(orderedList.head.value);
                orderedList.head = orderedList.head.next;
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod7()
        {
            // Тест проверяет добавление элементов по убыванию.
            OrderedList<int> orderedList = new OrderedList<int>(false);
            LinkedList<int> expected = new LinkedList<int>();
            LinkedList<int> actual = new LinkedList<int>();

            actual.AddLast(2);
            actual.AddLast(2);
            actual.AddLast(1);
            actual.AddLast(1);
            actual.AddLast(1);
            actual.AddLast(0);
            actual.AddLast(0);

            orderedList.Add(0);
            orderedList.Add(2);
            orderedList.Add(1);
            orderedList.Add(1);
            orderedList.Add(2);
            orderedList.Add(1);
            orderedList.Add(0);

            while (orderedList.head != null)
            {
                expected.AddLast(orderedList.head.value);
                orderedList.head = orderedList.head.next;
            }
            CollectionAssert.AreEqual(expected, actual);
        }
    }

}
