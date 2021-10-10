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
    public class Stack<T>
    {
        Node<T> head;
        int count;
        public Stack() 
        {

            head = null;
            count = 0;
            // инициализация внутреннего хранилища стека
        }

        public int Size()
        {
            // размер текущего стека		  
            return count;
        }

        public T Pop()
        {
            if (count > 0)
            {
                Node<T> temp = head;
                head = head.Next; // переустанавливаем верхушку стека на следующий элемент
                count--;
                return temp.Data;
            }
            return default(T); // null, если стек пустой
        }

        public void Push(T val)
        {
            Node<T> node = new Node<T>(val);
            node.Next = head; // переустанавливаем верхушку стека на новый элемент
            head = node;
            count++;
        }

        public T Peek()
        {
            if (count > 0)
            {
                return head.Data;
            }
            return default(T); // null, если стек пустой
        }
    }
}
