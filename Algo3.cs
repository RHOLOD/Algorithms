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
            T[] previousArray = new T[count];
            Array.Copy(array, previousArray,count);
            if (index < capacity)
            {

                if (array == null )
                {
                    Append(itm);
                }
                else
                {
                    if (count == capacity)
                    {
                        MakeArray(capacity * 2);
                    }
                    if ( index == count)
                    {
                        Append(itm);
                    }
                    else
                    {
                        count = 0;
                        int indexArray = 0;
                        foreach (T identifier in previousArray)
                        {
                            if (indexArray == index)
                            {
                                Append(itm);
                                indexArray++;
                            }
                            Append(identifier);
                            indexArray++;
                        }
                    }                
                }
            }
        }

        public void Remove(int index)
        {
            T[] previousArray = new T[count];
            
            Array.Copy(array, previousArray, count);
            if (index < capacity)
            {
                if (capacity/2 > count-- || capacity != 16)
                {
                    int verifyCapacity = (int)(capacity / 1.5);
                    if (verifyCapacity > 16)
                    {
                        MakeArray(verifyCapacity);
                    }
                }
                array[count] = default(T);
                count = 0;
                int indexArray = 0;
                foreach (T identifier in previousArray)
                {
                    if (indexArray != index)
                    {
                        Append(identifier);
                        indexArray++;
                    }
                    else
                    {
                        indexArray++;
                    }
                }
                
            }
        }
    }
}
