using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static bool SoundOn;
    


    private void Start()
    {
        SoundOn = true;       
    }

    public void CheckSound(AudioSource buttons) 
    {
        if (SoundOn == true)
        {
            buttons.Play();
        }
    
    }
}
