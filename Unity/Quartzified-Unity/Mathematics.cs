using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Quartzified
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
            if(count == 0)
            {
                throw new InvalidOperationException("Empty Collection");
            }
            else if(count % 2 == 0)
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

            if(inputs != null && inputs.Length > 0)
            {
                Dictionary<int, int> counts = new Dictionary<int, int>();

                foreach(int e in inputs)
                {
                    if (counts.ContainsKey(e))
                        counts[e]++;
                    else counts.Add(e, 1);
                }

                int max = 0;
                foreach(KeyValuePair<int, int> count in counts)
                {
                    if(count.Value > max)
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
        /// Functions based around Numbers
        /// </summary>
        public class Numbers
        {
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

//(Unity)
        /// <summary>
        /// Functions based around Vectors
        /// </summary>
        public class Vectors
        {
            /// <summary>
            /// Returns random Coordinate around startPosition
            /// </summary>
            /// <param name="startPosition"> Center Point</param>
            /// <param name="radius"> Area Radius</param>
            /// <returns></returns>
            public static Vector2 GetRandomVectorArea(Vector2 startPosition, float radius)
            {
                float rndX = Numbers.GetRandom(-radius, radius);
                float rndY = Numbers.GetRandom(-radius, radius);

                Vector2 newPosition = new Vector2(startPosition.x + rndX, startPosition.y + rndY);

                return newPosition;
            }
            /// <summary>
            /// Returns random Coordinate around startPosition
            /// </summary>
            /// <param name="startPosition"> Center Point</param>
            /// <param name="radius"> Area Radius</param>
            /// <returns></returns>
            public static Vector3 GetRandomVectorArea(Vector3 startPosition, float radius)
            {
                float rndX = Numbers.GetRandom(-radius, radius);
                float rndY = Numbers.GetRandom(-radius, radius);
                float rndZ = Numbers.GetRandom(-radius, radius);

                Vector3 newPosition = new Vector3(startPosition.x + rndX, startPosition.y + rndY, startPosition.z + rndZ);

                return newPosition;
            }
        }
//(!Unity)

//(Unity)
        /// <summary>
        ///  Returns the closest transform from a list
        /// </summary>
        /// <param name="transforms">List of Transforms</param>
        /// <param name="location">Location to determine distance from Transform</param>
        /// <returns></returns>
        public static Transform GetNearestTransform(List<Transform> transforms, Vector2 location)
        {
            Transform closest = null;
            foreach (Transform target in transforms)
            {
                if (closest == null || Vector2.Distance(target.position, location) < Vector2.Distance(closest.position, location)) closest = target;
            }
            return closest;
        }
        /// <summary>
        ///  Returns the closest transform from a list
        /// </summary>
        /// <param name="transforms">List of Transforms</param>
        /// <param name="location">Location to determine distance from Transform</param>
        /// <returns></returns>
        public static Transform GetNearestTransform(List<Transform> transforms, Vector3 location)
        {
            Transform closest = null;
            foreach (Transform target in transforms)
            {
                if (closest == null || Vector3.Distance(target.position, location) < Vector3.Distance(closest.position, location)) closest = target;
            }
            return closest;
        }
//(!Unity)

        /// <summary>
        /// Make things look nice
        /// </summary>
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

        public class Endian
        {
            /// <summary>
            /// Converts a Integer into an array of bytes
            /// </summary>
            /// <param name="x">Integer to Convert</param>
            /// <returns></returns>
            public static byte[] IntToBytes(int x)
            {
                return new byte[] 
                { 
                    (byte) (x >> 24),
                    (byte) (x >> 16),
                    (byte) (x >> 8),
                    (byte) x
                };
            }
            /// <summary>
            /// Converts a Interger into an already existing array of bytes. \n 
            /// <para>Does not allocate a new set of bytes</para>
            /// </summary>
            /// <param name="x">Integer to Convert</param>
            /// <param name="bytes">Byte Array to Fill</param>
            public static void IntToBytes(int x, byte[] bytes)
            {
                bytes[0] = (byte) (x >> 24);
                bytes[1] = (byte) (x >> 16);
                bytes[2] = (byte) (x >> 8);
                bytes[3] = (byte) x;
            }

            /// <summary>
            /// Converts Bytes back into an Integer
            /// </summary>
            /// <param name="bytes">Byte Array to Convert</param>
            /// <returns></returns>
            public static int BytesToInt(byte[] bytes)
            {
                return (bytes[0] << 24) | (bytes[1] << 16) | bytes[2] << 8 | bytes[3];
            }
            
        }

        /// <summary>
        /// 2D Direction Property
        /// </summary>
        public enum Direction2D {Up, Down, Left, Right};
//(Unity)
        /// <summary>
        /// Returns the movement Direction in 2D Space
        /// </summary>
        /// <param name="startPoint">First Coordinate Input</param>
        /// <param name="endPoint">Second Coordinate Input</param>
        /// <returns></returns>
        public static Direction2D GetDirection2D(Vector2 startPoint,  Vector2 endPoint)
        {
            float x = startPoint.x + endPoint.x;
            float y = startPoint.y + endPoint.y;

            float xStrength = (float)Math.Pow(x,2);
            float yStrength = (float)Math.Pow(y,2);

            if (yStrength >= xStrength) // Up Down
            {
                return y >= 0 ? Direction2D.Up : Direction2D.Down;
            }
            else
            {
                return x >= 0 ? Direction2D.Right : Direction2D.Left;
            }
        }
//(!Unity)
        public static Direction2D GetDirection2D(float xOne, float yOne, float xTwo, float yTwo)
        {
            float x = xOne + xTwo;
            float y = yOne + yTwo;

            float xStrength = (float)Math.Pow(x, 2);
            float yStrength = (float)Math.Pow(y, 2);

            if (yStrength >= xStrength) // Up Down
            {
                return y >= 0 ? Direction2D.Up : Direction2D.Down;
            }
            else
            {
                return x >= 0 ? Direction2D.Right : Direction2D.Left;
            }
        }

        /// <summary>
        /// 3D Direction Property
        /// </summary>
        public enum Direction3D {Forward, Back, Up, Down, Left, Right};
//(Unity)
        /// <summary>
        /// Return the movement Direction in 3D Space
        /// </summary>
        /// <param name="startPoint">First Coordinate Input</param>
        /// <param name="endPoint">Second Coordinate Input</param>
        /// <returns></returns>
        public static Direction3D GetDirection3D(Vector3 startPoint, Vector3 endPoint)
        {
            float x = startPoint.x + endPoint.x;
            float y = startPoint.y + endPoint.y;
            float z = startPoint.z + endPoint.z;

            float xStrength = (float)Math.Pow(x, 2);
            float yStrength = (float)Math.Pow(y, 2);
            float zStrength = (float)Math.Pow(z, 2);

            if(zStrength >= xStrength)
            {
                if(zStrength >= yStrength) // Z is Better
                {
                    return z >= 0 ? Direction3D.Forward : Direction3D.Back;
                }
                else // Y is Better
                {
                    return y >= 0 ? Direction3D.Up : Direction3D.Down;
                }
            }
            else
            {
                if(xStrength >= yStrength) // X is Better
                {
                    return x >= 0 ? Direction3D.Right : Direction3D.Left;
                }
                else // Y is Better
                {
                    return y >= 0 ? Direction3D.Up : Direction3D.Down;
                }
            }
        }
//(!Unity)
        public static Direction3D GetDirection3D(float xOne, float yOne, float zOne, float xTwo, float yTwo, float zTwo)
        {
            float x = xOne + xTwo;
            float y = yOne + yTwo;
            float z = zOne + zTwo;

            float xStrength = (float)Math.Pow(x, 2);
            float yStrength = (float)Math.Pow(y, 2);
            float zStrength = (float)Math.Pow(z, 2);

            if (zStrength >= xStrength)
            {
                if (zStrength >= yStrength) // Z is Better
                {
                    return z >= 0 ? Direction3D.Forward : Direction3D.Back;
                }
                else // Y is Better
                {
                    return y >= 0 ? Direction3D.Up : Direction3D.Down;
                }
            }
            else
            {
                if (xStrength >= yStrength) // X is Better
                {
                    return x >= 0 ? Direction3D.Right : Direction3D.Left;
                }
                else // Y is Better
                {
                    return y >= 0 ? Direction3D.Up : Direction3D.Down;
                }
            }
        }

        public class Finance
        {
            public static int GetAssets(int liability, int ownersEquity)
            {
                return liability + ownersEquity;
            }
            public static float GetAssets(float liability, float ownersEquity)
            {
                return liability + ownersEquity;
            }
            public static double GetAssets(double liability, double ownersEquity)
            {
                return liability + ownersEquity;
            }
            public static decimal GetAssets(decimal liability, decimal ownersEquity)
            {
                return liability + ownersEquity;
            }

            public static int GetNetIncome(int revenues, int expenses)
            {
                return revenues - expenses;
            }
            public static float GetNetIncome(float revenues, float expenses)
            {
                return revenues - expenses;
            }
            public static double GetNetIncome(double revenues, double expenses)
            {
                return revenues - expenses;
            }
            public static decimal GetNetIncome(decimal revenues, decimal expenses)
            {
                return revenues - expenses;
            }

            public static int GetBreakEvenPoint(int fixedCosts, int salesPrice, int variableCostPU)
            {
                return (fixedCosts / salesPrice) - variableCostPU;
            }
            public static float GetBreakEvenPoint(float fixedCosts, float salesPrice, float variableCostPU)
            {
                return (fixedCosts / salesPrice) - variableCostPU;
            }
            public static double GetBreakEvenPoint(double fixedCosts, double salesPrice, double variableCostPU)
            {
                return (fixedCosts / salesPrice) - variableCostPU;
            }
            public static decimal GetBreakEvenPoint(decimal fixedCosts, decimal salesPrice, decimal variableCostPU)
            {
                return (fixedCosts / salesPrice) - variableCostPU;
            }

            public static int GetCashRatio(int cash, int currentLiabilities)
            {
                return cash / currentLiabilities;
            }
            public static float GetCashRatio(float cash, float currentLiabilities)
            {
                return cash / currentLiabilities;
            }
            public static double GetCashRatio(double cash, double currentLiabilities)
            {
                return cash / currentLiabilities;
            }
            public static decimal GetCashRatio(decimal cash, decimal currentLiabilities)
            {
                return cash / currentLiabilities;
            }

            public static int GetProfitMargin(int netIncome, int sales)
            {
                return netIncome / sales;
            }
            public static float GetProfitMargin(float netIncome, float sales)
            {
                return netIncome / sales;
            }
            public static double GetProfitMargin(double netIncome, double sales)
            {
                return netIncome / sales;
            }
            public static decimal GetProfitMargin(decimal netIncome, decimal sales)
            {
                return netIncome / sales;
            }

            public static int GetDebt2EquityRatio(int totalLiabilities, int totalEquity)
            {
                return totalLiabilities / totalEquity;
            }
            public static float GetDebt2EquityRatio(float totalLiabilities, float totalEquity)
            {
                return totalLiabilities / totalEquity;
            }
            public static double GetDebt2EquityRatio(double totalLiabilities, double totalEquity)
            {
                return totalLiabilities / totalEquity;
            }
            public static decimal GetDebt2EquityRatio(decimal totalLiabilities, decimal totalEquity)
            {
                return totalLiabilities / totalEquity;
            }

            public static int GetCostofGoodsSold(int costOfMaterial, int costOfOutputs)
            {
                return costOfMaterial - costOfOutputs;
            }
            public static float GetCostofGoodsSold(float costOfMaterial, float costOfOutputs)
            {
                return costOfMaterial - costOfOutputs;
            }
            public static double GetCostofGoodsSold(double costOfMaterial, double costOfOutputs)
            {
                return costOfMaterial - costOfOutputs;
            }
            public static decimal GetCostofGoodsSold(decimal costOfMaterial, decimal costOfOutputs)
            {
                return costOfMaterial - costOfOutputs;
            }

            public static int GetRetainedEarnings(int startRetainedEarnings, int netIncome, int cashDividends)
            {
                return (startRetainedEarnings + netIncome) - cashDividends;
            }
            public static float GetRetainedEarnings(float startRetainedEarnings, float netIncome, float cashDividends)
            {
                return (startRetainedEarnings + netIncome) - cashDividends;
            }
            public static double GetRetainedEarnings(double startRetainedEarnings, double netIncome, double cashDividends)
            {
                return (startRetainedEarnings + netIncome) - cashDividends;
            }
            public static decimal GetRetainedEarnings(decimal startRetainedEarnings, decimal netIncome, decimal cashDividends)
            {
                return (startRetainedEarnings + netIncome) - cashDividends;
            }
        }
    }
}
