using System;

namespace Quartzified.Common
{
    public class EnumExtensions
    {
        public static T Parse<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static int FlagCount<T>()
        {
            return Enum.GetValues(typeof(T)).Length;
        }

        public static int FlagSetCount<T>(T e)
        {
            if (!typeof(T).IsEnum) return -1;

            int setBits = 0;
            long target = (long)(object)e;

            for (int i = 0; i < 32; i++)
            {
                if (((target >> i) & 1) == 1) setBits++;
            }

            return setBits;
        }
    }
}
