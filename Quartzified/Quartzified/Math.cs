using System;

namespace Quartzified
{
    public class Math
    {
        public class Numbers
        {
            public static int GetRandomInt(int min = 0, int max = 100)
            {
                Random r = new Random();

                int rnd = r.Next(min, max + 1);

                return rnd;
            }

            public static float GetRandomFloat(float min = 0f, float max = 100f)
            {
                Random r = new Random();

                float rnd = (float)(r.NextDouble() * (max - min) + min);

                return rnd;
            }

            public static double GetRandomDouble(double min = 0.0, double max = 100.0)
            {
                Random r = new Random();

                double rnd = r.NextDouble() * (max - min) + min;

                return rnd;
            }

            public static bool GetRandomIntThreshold(int min = 0, int max = 100, int threshold = 50)
            {
                int rnd = GetRandomInt(min, max);

                return rnd < threshold ? true : false;
            }

            public static bool GetRandomFloatThreshold(float min = 0f, float max = 100f, float threshold = 50f)
            {
                float rnd = GetRandomFloat(min, max);

                return rnd < threshold ? true : false;
            }

            public static bool GetRandomDoubleThreshold(double min = 0.0, double max = 100.0, double threshold = 50.0)
            {
                double rnd = GetRandomDouble(min, max);

                return rnd < threshold ? true : false;
            }
        }
    }
}
