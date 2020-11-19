using UnityEngine;

namespace Quartzified
{
    class Sound
    {
        public static AudioClip GetRandomClip(AudioClip[] clips)
        {
            int pick = Random.Range(0, clips.Length);

            return clips[pick];
        }

        public static float GetRandomPitch(float min = .8f, float max = 1.2f)
        {
            float pitch = Random.Range(min, max);

            pitch = Mathf.Clamp(pitch, -3f, 3f);

            return pitch;
        }
    }
}
