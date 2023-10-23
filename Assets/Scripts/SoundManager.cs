using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static void play(AudioClip clip, GameObject self, float volume = 1f, float delay = 0f)
    {
        if (clip != null)
        {
            var c = findChannel(self);
            c.clip = clip;
            c.volume = volume;
            c.PlayDelayed(delay);
        }
    }
 
    static AudioSource findChannel(GameObject target)
    {
        var audio = target.GetComponents<AudioSource>();
        for (var i = 0; i < audio.Length; i++)
        {
            if (audio[i].isPlaying == false) return audio[i];
        }
        var a = target.AddComponent<AudioSource>();
        a.volume = 0.1f;
        return a;
    }
}
