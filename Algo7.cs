using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                // версия для лексикографического сравнения строк
                result = String.Compare(v1.ToString(), v2.ToString());
            }
            else
            {
                result = v1.ToString().CompareTo(v2.ToString());
                // универсальное сравнение
            }

            return result;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        public void Add(T value)
        {
            Node<T> node = head;
            if (node == null)
            {
                Node<T> _item = new Node<T>(value);
                head = _item;
                head.next = null;
                head.prev = null;
                tail = _item;
            }
            while (node != null)
            {
                int position = Compare(value, node.value);
                if (position == 0) break;
                if (position == 1)
                {
                    if (node.next == null)
                    {
                        Node<T> _item = new Node<T>(value);
                        tail.next = _item;
                        _item.prev = tail;
                        tail = _item;
                        break;
                    }
                    else node = node.next;

                }                    
                if (position == -1)
                {
                    if (node.prev == null)
                    {
                        Node<T> _item = new Node<T>(value);
                        _item.next = head;
                        _item.prev = null;
                        head = _item;
                        Node<T> _itemTail = new Node<T>(value);
                        while (tail != null)
                        {
                            if (tail.prev == null)
                            {
                                _itemTail.next = tail;
                                tail.prev = _itemTail;
                                if (tail.next != null)
                                {
                                    tail = tail.next;
                                }
                                break;

                            }
                            else tail = tail.prev;
                        }    
                    }
                    else
                    {
                        Node<T> _item = new Node<T>(value);
                        _item.next = node;
                        _item.prev = node.prev;
                        node.prev.next = _item;
                        node.prev = _item;
                        break;
                    }
                }
            }

            // автоматическая вставка value 
            // в нужную позицию
        }

        public Node<T> Find(T val)
        {       
            Node<T> node = head;
            while (node != null)
            {
                int position = Compare(val, node.value);
                if (position == 0) return node;
                if (position == -1) return null;
                if (position == 1)
                {
                    if (node.next == null) return null;
                    else node = node.next;   
                }
                                    
            }
            return null; // здесь будет ваш код
        }

        public void Delete(T val)
        {
            Node<T> current = Find(val);

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
            }
            // здесь будет ваш код
        }

        public void Clear(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
            // здесь будет ваш код
        }

        public int Count()
        {
            int count = 0;
            Node<T> node = head;
            while (node != null)
            {
                node = node.next;
                count++;
            }
            return count;  // здесь будет ваш код подсчёта количества элементов в списке
        }

        List<Node<T>> GetAll() // выдать все элементы упорядоченного 
                               // списка в виде стандартного списка
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                Node<T> nodeNull = new Node<T>(node.value);
                r.Add(nodeNull);
                node = node.next;
            }
            return r;
        }
    }

}