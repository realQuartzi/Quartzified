using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quartzified.Mathematics
{
    public class Mathematics
    {
        /// <summary>
        /// Returns the Sum of all inputs added together
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int GetSum(int[] inputs)
        {
            int sum = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i];
            }

            return sum;
        }
        /// <summary>
        /// Returns the Sum of all inputs added together
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static float GetSum(float[] inputs)
        {
            float sum = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i];
            }

            return sum;
        }
        /// <summary>
        /// Returns the Sum of all inputs added together
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static double GetSum(double[] inputs)
        {
            double sum = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i];
            }

            return sum;
        }
        /// <summary>
        /// Returns the Sum of all inputs added together
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static decimal GetSum(decimal[] inputs)
        {
            decimal sum = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i];
            }

            return sum;
        }

        /// <summary>
        /// Returns the Average (Does not return decimals)
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int GetAverage(int[] inputs)
        {
            int average = GetSum(inputs) / inputs.Length;
            return average;
        }
        /// <summary>
        /// Returns the Average
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static float GetAverage(float[] inputs)
        {
            float average = GetSum(inputs) / inputs.Length;
            return average;
        }
        /// <summary>
        /// Returns the Average
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static double GetAverage(double[] inputs)
        {
            double average = GetSum(inputs) / inputs.Length;
            return average;
        }
        /// <summary>
        /// Returns the Average
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static decimal GetAverage(decimal[] inputs)
        {
            decimal average = GetSum(inputs) / inputs.Length;
            return average;
        }

        /// <summary>
        /// Returns the Median (Does not return decimals)
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int GetMedian(int[] inputs)
        {
            int[] temp = inputs;
            Array.Sort(temp);

            int count = temp.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty Collection");
            }
            else if (count % 2 == 0)
            {
                int a = temp[count / 2 - 1];
                int b = temp[count / 2];
                return (a + b) / 2;
            }
            else
            {
                return temp[count / 2];
            }
        }
        /// <summary>
        /// Returns the Median
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static float GetMedian(float[] inputs)
        {
            float[] temp = inputs;
            Array.Sort(temp);

            int count = temp.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty Collection");
            }
            else if (count % 2 == 0)
            {
                float a = temp[count / 2 - 1];
                float b = temp[count / 2];
                return (a + b) / 2;
            }
            else
            {
                return temp[count / 2];
            }
        }
        /// <summary>
        /// Returns the Median
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static double GetMedian(double[] inputs)
        {
            double[] temp = inputs;
            Array.Sort(temp);

            int count = temp.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty Collection");
            }
            else if (count % 2 == 0)
            {
                double a = temp[count / 2 - 1];
                double b = temp[count / 2];
                return (a + b) / 2;
            }
            else
            {
                return temp[count / 2];
            }
        }
        /// <summary>
        /// Returns the Median
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static decimal GetMedian(decimal[] inputs)
        {
            decimal[] temp = inputs;
            Array.Sort(temp);

            int count = temp.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty Collection");
            }
            else if (count % 2 == 0)
            {
                decimal a = temp[count / 2 - 1];
                decimal b = temp[count / 2];
                return (a + b) / 2m;
            }
            else
            {
                return temp[count / 2];
            }
        }

        /// <summary>
        /// Returns the Mode
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int GetMode(int[] inputs)
        {
            int mode = 0;

            if (inputs != null && inputs.Length > 0)
            {
                Dictionary<int, int> counts = new Dictionary<int, int>();

                foreach (int e in inputs)
                {
                    if (counts.ContainsKey(e))
                        counts[e]++;
                    else counts.Add(e, 1);
                }

                int max = 0;
                foreach (KeyValuePair<int, int> count in counts)
                {
                    if (count.Value > max)
                    {
                        mode = count.Key;
                        max = count.Value;
                    }
                }
            }

            return mode;
        }
        /// <summary>
        /// Returns the Mode
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static float GetMode(float[] inputs)
        {
            float mode = 0;

            if (inputs != null && inputs.Length > 0)
            {
                Dictionary<float, int> counts = new Dictionary<float, int>();

                foreach (float e in inputs)
                {
                    if (counts.ContainsKey(e))
                        counts[e]++;
                    else counts.Add(e, 1);
                }

                int max = 0;
                foreach (KeyValuePair<float, int> count in counts)
                {
                    if (count.Value > max)
                    {
                        mode = count.Key;
                        max = count.Value;
                    }
                }
            }

            return mode;
        }
        /// <summary>
        /// Returns the Mode
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static double GetMode(double[] inputs)
        {
            double mode = 0;

            if (inputs != null && inputs.Length > 0)
            {
                Dictionary<double, int> counts = new Dictionary<double, int>();

                foreach (double e in inputs)
                {
                    if (counts.ContainsKey(e))
                        counts[e]++;
                    else counts.Add(e, 1);
                }

                int max = 0;
                foreach (KeyValuePair<double, int> count in counts)
                {
                    if (count.Value > max)
                    {
                        mode = count.Key;
                        max = count.Value;
                    }
                }
            }

            return mode;
        }
        /// <summary>
        /// Returns the Mode
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static decimal GetMode(decimal[] inputs)
        {
            decimal mode = 0;

            if (inputs != null && inputs.Length > 0)
            {
                Dictionary<decimal, int> counts = new Dictionary<decimal, int>();

                foreach (decimal e in inputs)
                {
                    if (counts.ContainsKey(e))
                        counts[e]++;
                    else counts.Add(e, 1);
                }

                int max = 0;
                foreach (KeyValuePair<decimal, int> count in counts)
                {
                    if (count.Value > max)
                    {
                        mode = count.Key;
                        max = count.Value;
                    }
                }
            }

            return mode;
        }

        /// <summary>
        /// Returns the Smallest Number
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int GetMin(int[] inputs)
        {
            int[] temp = inputs;
            Array.Sort(temp);

            return temp[0];
        }
        /// <summary>
        /// Returns the Smallest Number
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static float GetMin(float[] inputs)
        {
            float[] temp = inputs;
            Array.Sort(temp);

            return temp[0];
        }
        /// <summary>
        /// Returns the Smallest Number
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static double GetMin(double[] inputs)
        {
            double[] temp = inputs;
            Array.Sort(temp);

            return temp[0];
        }
        /// <summary>
        /// Returns the Smallest Number
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static decimal GetMin(decimal[] inputs)
        {
            decimal[] temp = inputs;
            Array.Sort(temp);

            return temp[0];
        }

        /// <summary>
        /// Returns the Largest Number
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int GetMax(int[] inputs)
        {
            int[] temp = inputs;
            Array.Sort(temp);

            return temp[temp.Length - 1];
        }
        /// <summary>
        /// Returns the Largest Number
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static float GetMax(float[] inputs)
        {
            float[] temp = inputs;
            Array.Sort(temp);

            return temp[temp.Length - 1];
        }
        /// <summary>
        /// Returns the Largest Number
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static double GetMax(double[] inputs)
        {
            double[] temp = inputs;
            Array.Sort(temp);

            return temp[temp.Length - 1];
        }
        /// <summary>
        /// Returns the Largest Number
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static decimal GetMax(decimal[] inputs)
        {
            decimal[] temp = inputs;
            Array.Sort(temp);

            return temp[temp.Length - 1];
        }

        /// <summary>
        /// Returns the Range
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int GetRange(int[] inputs)
        {
            return GetMax(inputs) - GetMin(inputs);
        }
        /// <summary>
        /// Returns the Range
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static float GetRange(float[] inputs)
        {
            return GetMax(inputs) - GetMin(inputs);
        }
        /// <summary>
        /// Returns the Range
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static double GetRange(double[] inputs)
        {
            return GetMax(inputs) - GetMin(inputs);
        }
        /// <summary>
        /// Returns the Range
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static decimal GetRange(decimal[] inputs)
        {
            return GetMax(inputs) - GetMin(inputs);
        }

        /// <summary>
        /// Returns the Percentage
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static int GetPercent(int value, int total)
        {
            return (value * 100) / total;
        }
        /// <summary>
        /// Returns the Percentage
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static float GetPercent(float value, float total)
        {
            return (value * 100f) / total;
        }
        /// <summary>
        /// Returns the Percentage
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static double GetPercent(double value, double total)
        {
            return (value * 100) / total;
        }
        /// <summary>
        /// Returns the Percentage
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static decimal GetPercent(decimal value, decimal total)
        {
            return (value * 100) / total;
        }

        /// <summary>
        /// Returns true if Percentage is greater than the threshold
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static bool PercentGreaterThan(int value, int total, int threshold)
        {
            return GetPercent(value, total) > threshold ? true : false;
        }
        /// <summary>
        /// Returns true if Percentage is greater than the threshold
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static bool PercentGreaterThan(float value, float total, float threshold)
        {
            return GetPercent(value, total) > threshold ? true : false;
        }
        /// <summary>
        /// Returns true if Percentage is greater than the threshold
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static bool PercentGreaterThan(double value, double total, double threshold)
        {
            return GetPercent(value, total) > threshold ? true : false;
        }
        /// <summary>
        /// Returns true if Percentage is greater than the threshold
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static bool PercentGreaterThan(decimal value, decimal total, decimal threshold)
        {
            return GetPercent(value, total) > threshold ? true : false;
        }

        /// <summary>
        /// Returns true if Percentage is less than the threshold
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static bool PercentLessThan(int value, int total, int threshold)
        {
            return GetPercent(value, total) < threshold ? true : false;
        }
        /// <summary>
        /// Returns true if Percentage is less than the threshold
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static bool PercentLessThan(float value, float total, float threshold)
        {
            return GetPercent(value, total) < threshold ? true : false;
        }
        /// <summary>
        /// Returns true if Percentage is less than the threshold
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static bool PercentLessThan(double value, double total, double threshold)
        {
            return GetPercent(value, total) < threshold ? true : false;
        }
        /// <summary>
        /// Returns true if Percentage is less than the threshold
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static bool PercentLessThan(decimal value, decimal total, decimal threshold)
        {
            return GetPercent(value, total) < threshold ? true : false;
        }

        /// <summary>
        /// Clamp Long between 2 values
        /// </summary>
        /// <param name="value">Value to Clamp</param>
        /// <param name="min">Smallest Number</param>
        /// <param name="max">Largest Number</param>
        /// <returns></returns>
        public static long ClampLong(long value, long min, long max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static float Remap(float value, float f1, float t1, float f2, float t2)
        {
            return (value - f1) / (t1 - f1) * (t2 - f2) + f2;
        }
        public static double Remap(double value, double f1, double t1, double f2, double t2)
        {
            return (value - f1) / (t1 - f1) * (t2 - f2) + f2;
        }
        public static decimal Remap(decimal value, decimal f1, decimal t1, decimal f2, decimal t2)
        {
            return (value - f1) / (t1 - f1) * (t2 - f2) + f2;
        }

        public class Random
        {
            /// <summary>
            /// Returns a Random int between the min and max(inclusive)
            /// </summary>
            /// <param name="min">Smallest number</param>
            /// <param name="max">Largest number</param>
            /// <returns></returns>
            public static int GetRandom(int min = 0, int max = 100)
            {
                System.Random r = new System.Random();

                int rnd = r.Next(min, max + 1);

                return rnd;
            }
            /// <summary>
            /// Returns a Random float between the min and max
            /// </summary>
            /// <param name="min">Smallest number</param>
            /// <param name="max">Largest number</param>
            /// <returns></returns>
            public static float GetRandom(float min = 0f, float max = 100f)
            {
                System.Random r = new System.Random();

                float rnd = (float)(r.NextDouble() * (max - min) + min);

                return rnd;
            }
            /// <summary>
            /// Returns a Random double between the min and max
            /// </summary>
            /// <param name="min">Smallest number</param>
            /// <param name="max">Largest number</param>
            /// <returns></returns>
            public static double GetRandom(double min = 0.0, double max = 100.0)
            {
                System.Random r = new System.Random();

                double rnd = r.NextDouble() * (max - min) + min;

                return rnd;
            }

            /// <summary>
            /// Returns True if the number is less than the threshold
            /// </summary>
            /// <param name="min">Smallest number</param>
            /// <param name="max">Largest number</param>
            /// <param name="threshold">Number Threshold</param>
            /// <returns></returns>
            public static bool GetRandomThreshold(int min = 0, int max = 100, int threshold = 50)
            {
                int rnd = GetRandom(min, max);

                return rnd < threshold ? true : false;
            }
            /// <summary>
            /// Returns True if the number is less than the threshold
            /// </summary>
            /// <param name="min">Smallest number</param>
            /// <param name="max">Largest number</param>
            /// <param name="threshold">Number Threshold</param>
            /// <returns></returns>
            public static bool GetRandomThreshold(float min = 0f, float max = 100f, float threshold = 50f)
            {
                float rnd = GetRandom(min, max);

                return rnd < threshold ? true : false;
            }
            /// <summary>
            /// Returns True if the number is less than the threshold
            /// </summary>
            /// <param name="min">Smallest number</param>
            /// <param name="max">Largest number</param>
            /// <param name="threshold">Number Threshold</param>
            /// <returns></returns>
            public static bool GetRandomThreshold(double min = 0.0, double max = 100.0, double threshold = 50.0)
            {
                double rnd = GetRandom(min, max);

                return rnd < threshold ? true : false;
            }
        }

        public class Round
        {
            /// <summary>
            /// Round value to the Nearast Half
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static float RoundToNearestHalf(float value)
            {
                return Mathf.Round(value * 2f) * 0.5f;
            }

            /// <summary>
            /// Round Vector3 to the Nearast Half
            /// </summary>
            /// <param name="vector3"></param>
            /// <returns></returns>
            public static Vector3 RoundToNearestHalf(Vector3 vector3)
            {
                return new Vector3(RoundToNearestHalf(vector3.x), RoundToNearestHalf(vector3.y), RoundToNearestHalf(vector3.z));
            }
        }

        public class Distance
        {
            /// <summary>
            /// Calculates the Manhattan distance between two points.
            /// </summary>
            /// <param name="x1">The first x coordinate</param>
            /// <param name="y1">The first y coordinate</param>
            /// <param name="x2">The second x coordinate</param>
            /// <param name="y2">The second y coordinate</param>
            /// <returns></returns>
            public static int ManhattanDistance(int x1, int y1, int x2, int y2)
            {
                return Mathf.Abs(x1 - x2) + Mathf.Abs(y1 - y2);
            }
            /// <summary>
            /// Calculates the Manhattan distance between two points.
            /// </summary>
            /// <param name="x1">The first x coordinate</param>
            /// <param name="y1">The first y coordinate</param>
            /// <param name="x2">The second x coordinate</param>
            /// <param name="y2">The second y coordinate</param>
            /// <returns></returns>
            public static float ManhattanDistance(float x1, float y1, float x2, float y2)
            {
                return Mathf.Abs(x1 - x2) + Mathf.Abs(y1 - y2);
            }
            /// <summary>
            /// Calculates the Manhattan distance between two points.
            /// </summary>
            /// <param name="a">The first Vector3 coordinates</param>
            /// <param name="b">The second Vector3 coordinates</param>
            /// <returns></returns>
            public static float ManhattanDistance(Vector3 a, Vector3 b)
            {
                return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z);
            }

            /// <summary>
            /// Calculates the Euclidean distance between two points.
            /// </summary>
            /// <param name="x1">The first x coordinate</param>
            /// <param name="y1">The first y coordinate</param>
            /// <param name="x2">The second x coordinate</param>
            /// <param name="y2">The second y coordinate</param>
            /// <returns></returns>
            public static int EuclideanDistance(int x1, int y1, int x2, int y2)
            {
                return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
            }
            /// <summary>
            /// Calculates the Euclidean distance between two points.
            /// </summary>
            /// <param name="x1">The first x coordinate</param>
            /// <param name="y1">The first y coordinate</param>
            /// <param name="x2">The second x coordinate</param>
            /// <param name="y2">The second y coordinate</param>
            /// <returns></returns>
            public static float EuclideanDistance(float x1, float y1, float x2, float y2)
            {
                return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
            }
            /// <summary>
            /// Calculates the Euclidean distance between two points.
            /// </summary>
            /// <param name="a">The first Vector3 coordinates</param>
            /// <param name="b">The second Vector3 coordinates</param>
            /// <returns></returns>
            public static float EuclideanDistance(Vector3 a, Vector3 b)
            {
                return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y) + (a.z - b.z) * (a.z - b.z);
            }

            /// <summary>
            /// Calculates the Chebyshev distance between two points.
            /// </summary>
            /// <param name="x1">The first x coordinate</param>
            /// <param name="y1">The first y coordinate</param>
            /// <param name="x2">The second x coordinate</param>
            /// <param name="y2">The second y coordinate</param>
            /// <returns></returns>
            public static int ChebyshevDistance(int x1, int y1, int x2, int y2)
            {
                return Mathf.Max(Mathf.Abs(x2 - x1), Mathf.Abs(y2 - y1));
            }
            /// <summary>
            /// Calculates the Chebyshev distance between two points.
            /// </summary>
            /// <param name="x1">The first x coordinate</param>
            /// <param name="y1">The first y coordinate</param>
            /// <param name="x2">The second x coordinate</param>
            /// <param name="y2">The second y coordinate</param>
            /// <returns></returns>
            public static float ChebyshevDistance(float x1, float y1, float x2, float y2)
            {
                return Mathf.Max(Mathf.Abs(x2 - x1), Mathf.Abs(y2 - y1));
            }
            /// <summary>
            /// Calculates the Chebyshev distance between two points.
            /// </summary>
            /// <param name="a">The first Vector3 coordinates</param>
            /// <param name="b">The second Vector3 coordinates</param>
            /// <returns></returns>
            public static float ChebyshevDistance(Vector3 a, Vector3 b)
            {
                return Mathf.Max(Mathf.Abs(b.x - a.x), Mathf.Abs(b.y - a.y), Mathf.Abs(b.z - a.z));
            }
        }
    }
}
