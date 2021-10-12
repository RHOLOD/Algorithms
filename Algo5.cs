using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class Queue<T>
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;
        public Queue()
        {
            head = null;
            tail = null;
            count = 0;
            // инициализация внутреннего хранилища очереди
        }

        public void Enqueue(T item)
        {
            Node<T> node = new Node<T>(item);
            Node<T> tempNode = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            count++;
            // вставка в хвост
        }

        public T Dequeue()
        {
            if (count > 0)
            {
                // выдача из головы
                T queueHead = head.Data;
                head = head.Next;
                count--;
                return queueHead;
            }
            else
            {
                return default(T); // если очередь пустая
            }           
        }

        public int Size()
        {
            return count; // размер очереди
        }
    }
}