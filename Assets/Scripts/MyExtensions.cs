using UnityEngine;
using System;

namespace mDEV.Extensions
{
    public static class MyExtensions
    {
        public static T[] Random<T>(this T[] value)
        {
            T[] tmp = new T[value.Length];
            int i = 0;
            while (value.Length > 0)
            {
                int iTmp = UnityEngine.Random.Range(0, value.Length);
                tmp[i] = value[iTmp];
                i++;
                for (int j = iTmp; j < value.Length - 1; j++)
                {
                    value[j] = value[j + 1];
                }
                T[] tmp2 = new T[value.Length - 1];
                for (int j = 0; j < tmp2.Length; j++)
                {
                    tmp2[j] = value[j];
                }
                value = tmp2;
            }
            value = tmp;

            return value;
        }
    }
}
