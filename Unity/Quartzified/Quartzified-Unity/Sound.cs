using UnityEngine;

namespace Quartzified
{
    public class Sound
    {
        /// <summary>
        /// Returns a Random AudioClip from an Array
        /// </summary>
        /// <param name="clips">Array of Clips</param>
        /// <returns></returns>
        public static AudioClip GetRandomClip(AudioClip[] clips)
        {
            int pick = Random.Range(0, clips.Length);

            return clips[pick];
        }

        /// <summary>
        /// Returns a Random Pitch Clamped to Unitys variable limit
        /// </summary>
        /// <param name="min">Lowest Pitch</param>
        /// <param name="max">Highest Pitch</param>
        /// <returns></returns>
        public static float GetRandomPitch(float min = .8f, float max = 1.2f)
        {
            float pitch = Random.Range(min, max);

            pitch = Mathf.Clamp(pitch, -3f, 3f);

            return pitch;
        }
    }
}
