using System.Collections.Generic;
using System.Text;

namespace Quartzified.Collections.Extra
{
    public static class ListExtensions
    {
        public static string ToString<T>(this List<T> list, bool link, string separator = ", ")
        {
            if (!link) return list.ToString();

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                stringBuilder.Append(list[i].ToString());
                if (i < list.Count - 1)
                    stringBuilder.Append(separator);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sets a value at a specific index. If the index does not exist, add empty positions untill the index can be set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns>Returns whether the index position existed (False upon development)</returns>
        public static bool AddOrSet<T>(this List<T> list, int index, T value)
        {
            if (list.Count > index)
            {
                list[index] = value;
                return true;
            }
            else
            {
                while (list.Count < index)
                {
                    list.Add(default(T));
                }
                list.Add(value);
                return false;
            }
        }
    }
}
