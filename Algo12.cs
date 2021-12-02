using System.Collections.Generic;
using System;
using System.IO;
using System.Collections;

namespace AlgorithmsDataStructures
{
    public class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int[] hits;
        public int step;

        public NativeCache(int sz,int st)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
            step = st;
        }

        public int HashFun(string key)
        {
            int value = Math.Abs(key.GetHashCode());
            int index = value % size;
            return index;
        }
        public bool IsKey(string key)
        {
            int index = HashFun(key);
            if (slots[index] == key)
            {
                return true;
            }
            else
            {
                index = Find(key);
                if (index != -1)
                {
                    return true;
                }
            }
            // возвращает true если ключ имеется,
            // иначе false
            return false;
        }

        public void Put(string key, T value)
        {
            int index = SeekSlot(key);
            if (index == -1)
            {
                index = Displacement();
            }
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
                if (slots[index] == key)
                {
                    hits[index]++;
                    return values[index];
                }
                else
                {
                    index = Find(key);
                    if (index != -1)
                    {
                        hits[index]++;
                        return values[index];
                    }
                }

            }
            // возвращает value для key, 
            // или null если ключ не найден
            return default(T);
        }
        public int SeekSlot(string value)
        {
            int indexHash = HashFun(value);
            int index = indexHash;

            if (slots[index] == null)
            {
                return index;
            }
            else
            {
                index = index + step;
                if (index >= size)
                {
                    index = step - (size - indexHash);
                }
                while (index != indexHash)
                {
                    if (slots[index] == null) return index;
                    if ((index + step) >= size)
                    {
                        index = step - (size - index);
                    }
                    else
                    {
                        index = index + step;
                    }
                }
            }
            // находит индекс пустого слота для значения, или -1
            return -1;
        }
        public int Find(string value)
        {
            int index = Array.IndexOf(slots, value);
            if (index != -1)
            {
                return index;
            }
            // находит индекс слота со значением, или -1
            return -1;
        }
        public int Displacement()
        {
            int min = hits[0];
            int index = 0;

            for (int i = 0; i < hits.Length; i++)
            {
                if (min > hits[i])
                {
                    min = hits[i];
                    index = i;
                }
            }
            slots[index] = null;
            values[index] = default(T);
            hits[index] = 0;
            //Вытеснение элемента
            return index;
        }
    }
}