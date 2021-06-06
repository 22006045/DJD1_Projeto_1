using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    List<AudioSource>   audioSources;

    public static SoundManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            return;
        }

        instance = this;

        audioSources = new List<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        foreach (var aSource in audioSources)
        {
            if (!aSource.isPlaying)
            {
                aSource.clip = clip;
                aSource.Play();
                return;
            }
        }
        GameObject newAudio = new GameObject("AudioSource");
        newAudio.transform.SetParent(transform);

        AudioSource audioSource = newAudio.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.playOnAwake = false;


        audioSource.Play();

        audioSources.Add(audioSource);
    }
}