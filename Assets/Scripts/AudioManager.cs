using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public static bool OnOffSound;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;
            s.audioSource.clip = s.clip;
        }
    }

    private void Start()
    {
        SoundPlay("music");
    }

    public void SoundPlay(string soundName)
    {

        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        s.audioSource.Play();



    }
    // to use\play use FindObjectOfType<AudioManager>().SoundPlay("name of sound");
}
