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
