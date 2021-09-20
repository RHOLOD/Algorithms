using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
                
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) 
                {
                    nodes.Add(node);

                }                     
                node = node.next;
            }            
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.value.Equals(_value))
                {
                    if (previous != null)
                    {
                        previous.next = current.next;
                        if (current.next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.next;
                        if (head == null)
                            tail = null;
                    }
                    return true;
                }
                previous = current;
                current = current.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            int countItem = FindAll(_value).Count;
            for (int i = 0; i < countItem;i++)
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
            while (node != null)
            {
                count++;
                node = node.next;
            }
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                nodes.Add(node);
                node = node.next;
            }
            if (_nodeAfter == null)
            {
                AddInTail(_nodeToInsert);
            }
            else
            {
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
