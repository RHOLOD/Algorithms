using System.Collections.Generic;
using System;
using System.IO;
using System.Collections;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        BitArray flags;
        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            // создаём битовый массив длиной f_len ...
            flags = new BitArray(filter_len, false);
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            // 17
            int multiplier = 17;
            int value = 0;            
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                value = (value + code)* multiplier;
            }
            int result = Math.Abs(value % filter_len);
            // реализация ...
            return result;
        }
        public int Hash2(string str1)
        {
            // 223
            int multiplier = 223;
            int value = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                value = (value + code) * multiplier;
            }
            int result = Math.Abs(value % filter_len);
            // реализация ...
            return result;
        }

        public void Add(string str1)
        {
            int index1 = Hash1(str1);
            int index2 = Hash2(str1);
            flags[index1] = true;
            flags[index2] = true;

            // добавляем строку str1 в фильтр
        }

        public bool IsValue(string str1)
        {
            int index1 = Hash1(str1);
            int index2 = Hash2(str1);
            if (flags[index1] == true && flags[index2] == true)
            {
                return true;
            }

            // проверка, имеется ли строка str1 в фильтре
            return false;
        }
    }
}