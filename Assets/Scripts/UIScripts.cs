using UnityEngine;

public class UIScripts : MonoBehaviour
{
    [SerializeField] private AudioSource buttons;   
    [SerializeField] private GameObject uipanel;
    public void SetInfromationActive() 
    {
        uipanel.SetActive(true);
        
        
    }

    public void SetInformationDeactivate() 
    {
        uipanel.SetActive(false);
        if (Sound.SoundOn)
        {
            buttons.Play();
        }
        
    }
}
