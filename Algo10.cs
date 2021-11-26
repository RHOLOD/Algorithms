using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T>
    {
        public int quantity;
        public int size;
        public int step;
        public T[] slots;
        public PowerSet()
        {
            quantity = 0;
            size = 20000;
            step = 1;
            slots = new T[size];
            for (int i = 0; i < size; i++) slots[i] = default(T);
            // ваша реализация хранилища
        }

        public int Size()
        {
            // количество элементов в множестве
            return quantity;
        }

        public void Put(T value)
        {
            int index = SeekSlot(value);
            if (index != -1)
            {
                slots[index] = value;
                quantity++;
            }
            // записываем значение по хэш-функции

            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            // всегда срабатывает
        }

        public bool Get(T value)
        {
            int index = Array.IndexOf(slots, value);
            if (index != -1)
            {
                return true;
            }
            // находит индекс слота со значением, или -1
            // возвращает true если value имеется в множестве,
            // иначе false
            return false;
        }

        public bool Remove(T value)
        {
            if (value == null)
            {
                return false;
            }
            int index = Array.IndexOf(slots, value);            
            if (index != -1)
            {
                slots[index] = default(T);
                quantity--;
                return true;
            }
            // возвращает true если value удалено
            // иначе false
            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            List<T> list1 = DeleteEmptySlots(slots);
            List<T> list2 = DeleteEmptySlots(set2.slots);
            List<T> list3 = new List<T>();
            foreach (T s in list1)
            {
                foreach (T d in list2)
                {
                    if (s.ToString() == d.ToString())
                    {
                        list3.Add(s);
                    }
                }
            }
            PowerSet<T> powerSet = new PowerSet<T>();
            foreach (T s in list3)
            {
                powerSet.Put(s);
            }

            // пересечение текущего множества и set2
            return powerSet;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            List<T> list1 = DeleteEmptySlots(slots);
            List<T> list2 = DeleteEmptySlots(set2.slots);
            List<T> list3 = new List<T>();
            foreach (T s in list1)
            {
                list3.Add(s);
            }
            foreach (T d in list2)
            {
                list3.Add(d);
            }
            PowerSet<T> powerSet = new PowerSet<T>();
            foreach (T s in list3)
            {
                powerSet.Put(s);
            }

            // пересечение текущего множества и set2
            return powerSet;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            List<T> list1 = DeleteEmptySlots(slots);
            List<T> list2 = DeleteEmptySlots(set2.slots);
            List<T> list3 = new List<T>();
            bool done = false;
            foreach (T s in list1)
            {
                foreach (T d in list2)
                {
                    if (s.ToString() == d.ToString())
                    {
                        done = true;
                        break;
                    }
                }
                if (done == false)
                {
                    list3.Add(s);
                }
                done = false;
            }
            PowerSet<T> powerSet = new PowerSet<T>();
            foreach (T s in list3)
            {
                powerSet.Put(s);
            }
            // разница текущего множества и set2
            return powerSet;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            List<T> list1 = DeleteEmptySlots(slots);
            List<T> list2 = DeleteEmptySlots(set2.slots);
            List<T> list3 = new List<T>();
            foreach (T s in list1)
            {
                foreach (T d in list2)
                {
                    if (s.ToString() == d.ToString())
                    {
                        list3.Add(s);
                    }
                }
            }
            int n2 = list2.Count;
            int n3 = list3.Count;

            if (n2 == n3)
            {
                for (int i = 0; i < n2; i++)
                {
                    if (list2[i].ToString() != list3[i].ToString())
                    {
                        return false;
                    }
                }
                return true;
            }

            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
            return false;
        }
        public int HashFun(T value)
        {
            int key = Math.Abs(value.GetHashCode());
            int index = key % size;
            // всегда возвращает корректный индекс слота
            return index;
        }

        public int SeekSlot(T value)
        {
            int indexHash = HashFun(value);
            int index = indexHash;

            if (slots[index] == null)
            {
                return index;
            }
            else
            {
                if (slots[index].ToString() == value.ToString())
                {
                    return -1;
                }
                index = index + step;
                if (index >= size)
                {
                    index = step - (size - indexHash);
                }
                while (index != indexHash)
                {
                    if (slots[index] == null) return index;
                    else if (slots[index].ToString() == value.ToString())
                    {
                        return -1;
                    }
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
        public List<T> DeleteEmptySlots(T[] array)
        {
            List<T> list = new List<T>();
            foreach (T item in array)
            {
                if (item != null) list.Add(item);
            }
            return list;
        }
    }
}
