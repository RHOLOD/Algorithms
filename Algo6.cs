using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
    class Deque<T>
    {
        DoublyNode<T> head; 
        DoublyNode<T> tail; 
        int count;  
        public Deque()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddFront(T item)
        {
            // добавление в голову
            DoublyNode<T> node = new DoublyNode<T>(item);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            DoublyNode<T> node = new DoublyNode<T>(item);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public T RemoveFront()
        {
            // удаление из головы
            if (count == 0)
            {
                return default(T);

            }
            T outputItem = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return outputItem;            
        }

        public T RemoveTail()
        {
            // удаление из хвоста
            if (count == 0)
            {
                return default(T);
            }
            T outputItem = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
            return outputItem;
        }

        public int Size()
        {
            return count; // размер очереди
        }
    }

}
