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
            catch(IndexOutOfRangeException)
            {
                return default(T);
            }                        
        }

        public void Append(T itm)
        {
            if (count +1 <= capacity)
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
            T[] previousArray =array;
            if (index >= capacity)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (count-1 > index)
                {
                    if (count == capacity)
                    {
                        MakeArray(capacity * 2);
                    }
                    array[index] = itm;
                    int lengthCopyArray = count - index - 1;
                    Array.Copy(previousArray, index, array, index + 1, lengthCopyArray);
                    count++;
                }
                else 
                {
                    array[index] = itm;
                    count++;
                }

            }
        }

        public void Remove(int index)
        {
            T[] previousArray = array;
            if (index >= capacity)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                int lengthCopyArray = count - index - 1;
                Array.Copy(previousArray, index+1, array, index, lengthCopyArray);
                count--;
                int verifyCapacity = (int)(capacity / 1.5);
                if (count < verifyCapacity || verifyCapacity > 16)
                {
                    MakeArray(verifyCapacity);
                }
            }
        }
    }
}