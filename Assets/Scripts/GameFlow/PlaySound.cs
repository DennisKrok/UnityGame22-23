using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    //Credits: https://www.youtube.com/watch?v=sNqtbH3qTBU

    public AudioSource source;
    public List<AudioClip> audioClips = new List<AudioClip>();

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        source.Play();
    }

    public void PlayFromList(int sound)
    {
        source.clip = audioClips[sound];
        source.Play();
    }
}
