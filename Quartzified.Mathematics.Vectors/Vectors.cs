using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quartzified.Mathematics.Vectors
{
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
    }
}
