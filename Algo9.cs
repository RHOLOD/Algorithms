using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            int value = Math.Abs(key.GetHashCode());
            int index = value % size;
            // всегда возвращает корректный индекс слота
            return index;
        }

        public bool IsKey(string key)
        {
            int index = HashFun(key);
            if (slots[index] == key)
            {
                return true;
            }
            // возвращает true если ключ имеется,
            // иначе false
            return false;
        }

        public void Put(string key, T value)
        {
            int index = HashFun(key);
            slots[index] = key;
            values[index] = value;

            // гарантированно записываем 
            // значение value по ключу key
        }

        public T Get(string key)
        {
            if (IsKey(key))
            {
                int index = HashFun(key);
                return values[index];
            }
            // возвращает value для key, 
            // или null если ключ не найден
            return default(T);
        }
    }
}