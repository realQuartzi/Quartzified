using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quartzified.Mathematics.Directions
{
    public class Directions2D
    {
        /// <summary>
        /// 2D Direction Property
        /// </summary>
        public enum Direction2D { Up, Down, Left, Right };

        /// <summary>
        /// Returns the movement Direction in 2D Space
        /// </summary>
        /// <param name="startPoint">First Coordinate Input</param>
        /// <param name="endPoint">Second Coordinate Input</param>
        /// <returns></returns>
        public static Direction2D GetDirection2D(Vector2 startPoint, Vector2 endPoint)
        {
            float x = startPoint.x + endPoint.x;
            float y = startPoint.y + endPoint.y;

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

    }

    public class Directions3D
    {
        /// <summary>
        /// 3D Direction Property
        /// </summary>
        public enum Direction3D { Forward, Back, Up, Down, Left, Right };

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
