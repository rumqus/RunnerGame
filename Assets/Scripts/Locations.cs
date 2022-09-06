using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    
    public GameObject[] levelLocations; // массив с локациями
    public static List<GameObject> runtimeLocations = new List<GameObject>();
    public static float locationSpeed;
    public static float index;

    private void Start()
    {
        locationSpeed = 10;
    }


    /// <summary>
    /// метод удаления пройденной локации в рантайме
    /// </summary>
    public static void DelRuntimeLocation() 
    {
        if (runtimeLocations.Count >=3 )
        {
            Destroy(runtimeLocations[runtimeLocations.Count - 2]);
            runtimeLocations.RemoveAt(runtimeLocations.Count - 2);                        
        }    
    }   
}
