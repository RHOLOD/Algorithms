using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            T[] previousArray;
            if (array == null)
            {
                previousArray = new T[16];
            }
            else
            {
                previousArray = array;
            }
            array = new T[new_capacity];
            if (count <= new_capacity)
            {
                Array.Copy(previousArray, array, count);
            }
            capacity = new_capacity;
        }
        public T GetItem(int index)
        {
            try
            {
                T item = array[index];
                return item;
            }
            catch (IndexOutOfRangeException)
            {
                return default(T);
            }
        }

        public void Append(T itm)
        {
            if (count + 1 <= capacity)
            {
                array[count] = itm;
                count++;
            }
            else
            {
                MakeArray(capacity * 2);
                array[count] = itm;
                count++;
            }
        }

        public void Insert(T itm, int index)
        {

            if (index <= capacity && index <= count)
            {
                T[] previousArray = new T[count - index];
                Array.Copy(array, index, previousArray, 0, count - index);
                if (array == null)
                {
                    Append(itm);
                }
                else
                {
                    if (count == capacity)
                    {
                        MakeArray(capacity * 2);
                    }
                    if (index == count)
                    {
                        Append(itm);
                    }
                    else if (index < count)
                    {
                        count = index;
                        Append(itm);
                        foreach (T identifier in previousArray)
                        {
                            Append(identifier);
                        }
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove(int index)
        {
            if (index < capacity && index <count)
            {
                if (index < count)
                {
                    T[] previousArray = new T[count - index - 1];
                    Array.Copy(array, index + 1, previousArray, 0, count - index - 1);


                    array[count - 1] = default(T);
                    count = index;
                    foreach (T identifier in previousArray)
                    {
                        Append(identifier);
                    }
                    if (capacity / 2 > count && capacity != 16)
                    {
                        if (capacity / 2 >= 16)
                        {
                            int verifyCapacity = (int)(capacity / 1.5);
                            MakeArray(verifyCapacity);
                        }
                        else
                        {
                            MakeArray(16);
                        }

                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
