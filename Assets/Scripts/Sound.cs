using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0.0f, 1.0f)]
    public float volume;

    public bool playOnAwake = true;

    [HideInInspector]
    public AudioSource audioSource;

    public bool loop; 
    
}
