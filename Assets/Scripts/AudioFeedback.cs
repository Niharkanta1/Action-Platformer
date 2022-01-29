using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Udemy 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       28-01-2022 22:19:40
================================================================*/

public class AudioFeedback : MonoBehaviour {

    public AudioClip clip;
    public AudioSource targetAudioSource;
    [Range(0, 1)] public float volume = 1f;

    public void PlayClip() {
        if(clip == null) return;
        targetAudioSource.volume = volume;
        targetAudioSource.PlayOneShot(clip);
    }

    public void PlaySpecificClip(AudioClip clipToPlay = null) {
        if (clipToPlay == null) clipToPlay = clip;
        if (clipToPlay == null) return;
        targetAudioSource.volume = volume;
        targetAudioSource.PlayOneShot(clipToPlay);
    }
}
