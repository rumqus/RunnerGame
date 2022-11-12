using UnityEngine;

public class UIScripts : MonoBehaviour
{    
    [SerializeField] private GameObject uipanel;
    public void SetInfromationActive() 
    {
        uipanel.SetActive(true);
        FindObjectOfType<AudioManager>().SoundPlay("button");
    }

    public void SetInformationDeactivate() 
    {
        uipanel.SetActive(false);
        FindObjectOfType<AudioManager>().SoundPlay("button");

    }
}
