﻿using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            Node nodePrev = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;

            }
            while (nodePrev != null)
            {
                if (nodePrev.value == _value) return nodePrev;
                nodePrev = nodePrev.prev;

            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            Node nodePrev = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);

                }
                node = node.next;
            }
            while (nodePrev != null)
            {
                if (nodePrev.value == _value)
                {
                    nodes.Add(nodePrev);

                }
                nodePrev = nodePrev.prev;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node current = Find(_value);

            if (current != null)
            {
                // если узел не последний
                if (current.next != null)
                {
                    current.next.prev = current.prev;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.prev;
                }

                // если узел не первый
                if (current.prev != null)
                {
                    current.prev.next = current.next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.next;
                }
                return true;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            List<Node> nodes = FindAll(_value);
            int countNodes = nodes.Count;
            for (int i = 0; i < countNodes; i++)
            {
                Remove(_value);
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node node = head;
            Node nodePrev = head;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            while (nodePrev != null)
            {
                count++;
                nodePrev = nodePrev.prev;
            }
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;

            if (_nodeAfter == null || node == null)
            {
                AddFirst(_nodeToInsert);
            }
            else
            {
                while (node.prev != null)
                {
                    node = node.prev;
                }
                while (node != null)
                {
                    nodes.Add(node);
                    node = node.next;
                }
                foreach (Node identifier in nodes)
                {
                    AddInTail(identifier);
                    if (identifier == _nodeAfter)
                    {
                        AddInTail(_nodeToInsert);
                    }
                }
            }
        }

    }
}
