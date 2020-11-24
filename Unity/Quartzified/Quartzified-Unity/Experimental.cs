using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Quartzified
{
    public class Experimental
    {
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
                System.Random r1 = new System.Random();
                System.Random r2 = new System.Random();

                float rndX = (float)r1.NextDouble() * (radius - radius) + radius;
                float rndY = (float)r2.NextDouble() * (radius - radius) + radius;

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
                System.Random r1 = new System.Random();
                System.Random r2 = new System.Random();
                System.Random r3 = new System.Random();

                float rndX = (float)r1.NextDouble() * (radius - radius) + radius;
                float rndY = (float)r2.NextDouble() * (radius - radius) + radius;
                float rndZ = (float)r3.NextDouble() * (radius - radius) + radius;

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
    }
}
