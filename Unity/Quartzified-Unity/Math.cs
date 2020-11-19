using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quartzified
{
    public class Math
    {
        public class Numbers
        {
            public static long ClampLong(long value, long min, long max)
            {
                if (value < min) return min;
                if (value > max) return max;
                return value;
            }

            public static int GetRandom(int min = 0, int max = 100)
            {
                System.Random r = new System.Random();

                int rnd = r.Next(min, max + 1);

                return rnd;
            }
            public static float GetRandom(float min = 0f, float max = 100f)
            {
                System.Random r = new System.Random();

                float rnd = (float)(r.NextDouble() * (max - min) + min);

                return rnd;
            }
            public static double GetRandom(double min = 0.0, double max = 100.0)
            {
                System.Random r = new System.Random();

                double rnd = r.NextDouble() * (max - min) + min;

                return rnd;
            }

            public static bool GetRandomThreshold(int min = 0, int max = 100, int threshold = 50)
            {
                int rnd = GetRandom(min, max);

                return rnd < threshold ? true : false;
            }
            public static bool GetRandomThreshold(float min = 0f, float max = 100f, float threshold = 50f)
            {
                float rnd = GetRandom(min, max);

                return rnd < threshold ? true : false;
            }
            public static bool GetRandomThreshold(double min = 0.0, double max = 100.0, double threshold = 50.0)
            {
                double rnd = GetRandom(min, max);

                return rnd < threshold ? true : false;
            }
        }

        public class Vectors
        {
            public static Vector2 GetRandomVector2Area(Vector2 startPosition, float radius)
            {
                float rndX = Numbers.GetRandom(-radius, radius);
                float rndY = Numbers.GetRandom(-radius, radius);

                Vector2 newPosition = new Vector2(startPosition.x + rndX, startPosition.y + rndY);

                return newPosition;
            }

            public static Vector3 GetRandomVector3Area(Vector3 startPosition, float radius)
            {
                float rndX = Numbers.GetRandom(-radius, radius);
                float rndY = Numbers.GetRandom(-radius, radius);
                float rndZ = Numbers.GetRandom(-radius, radius);

                Vector3 newPosition = new Vector3(startPosition.x + rndX, startPosition.y + rndY, startPosition.z + rndZ);

                return newPosition;
            }
        }

        public static Transform GetNearestTransform(List<Transform> transforms, Vector2 location)
        {
            Transform closest = null;
            foreach (Transform target in transforms)
            {
                if (closest == null || Vector2.Distance(target.position, location) < Vector2.Distance(closest.position, location)) closest = target;
            }
            return closest;
        }
        public static Transform GetNearestTransform(List<Transform> transforms, Vector3 location)
        {
            Transform closest = null;
            foreach (Transform target in transforms)
            {
                if (closest == null || Vector3.Distance(target.position, location) < Vector3.Distance(closest.position, location)) closest = target;
            }
            return closest;
        }

        public class Pretty
        {
            public static string Seconds(float seconds)
            {
                TimeSpan t = TimeSpan.FromSeconds(seconds);
                string res = "";
                if (t.Days > 0) res += t.Days + "d";
                if (t.Hours > 0) res += " " + t.Hours + "h";
                if (t.Minutes > 0) res += " " + t.Minutes + "m";

                if (t.Milliseconds > 0) res += " " + t.Seconds + "." + (t.Milliseconds / 100) + "s";
                else if (t.Seconds > 0) res += " " + t.Seconds + "s";

                return res != "" ? res : "0s";
            }

            public static string Time(float seconds)
            {
                TimeSpan t = TimeSpan.FromSeconds(seconds);
                string res = "";

                res += t.Hours > 0 ? ":" + t.Hours.ToString("00") : "00";
                res += t.Minutes > 0 ? ":" + t.Minutes.ToString("00") : "00";
                res += t.Seconds > 0 ? ":" + t.Seconds.ToString("00") : "00";

                return res;
            }
        }

    }
}
