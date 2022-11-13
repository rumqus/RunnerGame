using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public static bool isMuted;
    private AudioSource[] runAudio;


    private void Awake()
    {
        isMuted = false;

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
            s.audioSource.playOnAwake = s.playOnAwake;            
        }
    }

    private void Start()
    {
        Debug.Log("Start__" + isMuted);
        SoundPlay("music");
        runAudio = GetComponents<AudioSource>();
        
    }

    /// <summary>
    /// запуск звукового эффекта
    /// </summary>
    /// <param name="soundName"></param>
    public void SoundPlay(string soundName)
    {        
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        s.audioSource.Play();
    }
    // to use\play use FindObjectOfType<AudioManager>().SoundPlay("name of sound");

    public void CheckMute()
    {        
        if (isMuted)
        {            
            foreach (AudioSource s in runAudio)
            {
                s.mute = true;
            }
        }
        else 
        {
            foreach (AudioSource s in runAudio)
            {
                s.mute = false;
            }
        }
    }

}
