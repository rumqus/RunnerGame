using UnityEngine;

public class UIScripts : MonoBehaviour
{
    [SerializeField] private GameObject uipanel;
    public void SetInfromationActive() 
    {
        uipanel.SetActive(true);    
    }

    public void SetInformationDeactivate() 
    {
        uipanel.SetActive(false);
    }
}
