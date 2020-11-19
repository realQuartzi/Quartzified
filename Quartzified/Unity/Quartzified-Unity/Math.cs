using System;
using UnityEngine;

namespace Quartzified
{
    public class Math
    {
        public class Numbers
        {
            public static int GetRandomInt(int min = 0, int max = 100)
            {
                System.Random r = new System.Random();

                int rnd = r.Next(min, max + 1);

                return rnd;
            }

            public static float GetRandomFloat(float min = 0f, float max = 100f)
            {
                System.Random r = new System.Random();

                float rnd = (float)(r.NextDouble() * (max - min) + min);

                return rnd;
            }

            public static double GetRandomDouble(double min = 0.0, double max = 100.0)
            {
                System.Random r = new System.Random();

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

        public class Vectors
        {
            public static Vector2 GetRandomVector2Area(Vector2 startPosition, float radius)
            {
                float rndX = Numbers.GetRandomFloat(-radius, radius);
                float rndY = Numbers.GetRandomFloat(-radius, radius);

                Vector2 newPosition = new Vector2(startPosition.x + rndX, startPosition.y + rndY);

                return newPosition;
            }

            public static Vector3 GetRandomVector3Area(Vector3 startPosition, float radius)
            {
                float rndX = Numbers.GetRandomFloat(-radius, radius);
                float rndY = Numbers.GetRandomFloat(-radius, radius);
                float rndZ = Numbers.GetRandomFloat(-radius, radius);

                Vector3 newPosition = new Vector3(startPosition.x + rndX, startPosition.y + rndY, startPosition.z + rndZ);

                return newPosition;
            }
        }
    }
}
