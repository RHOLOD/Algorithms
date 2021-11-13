using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            int key = Math.Abs(value.GetHashCode());
            int index = key % size;
            // всегда возвращает корректный индекс слота
            return index;
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
                        index =step - (size - index);
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

        public int Put(string value)
        {
            int index = SeekSlot(value);
            if (index != -1 )
            {
                slots[index] = value;
                return index;
            }
            // записываем значение по хэш-функции

            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
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
    }

}