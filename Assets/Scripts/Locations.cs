using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    public GameObject[] levelLocations; // массив с локациями

    public static List<GameObject> runtimeLocations = new List<GameObject>();

    private void Update()
    {
        Debug.Log(runtimeLocations.Count);
    }

    public static void DelRuntimeLocation() 
    {
        if (runtimeLocations.Count >=2 )
        {
            Debug.Log(@$"объект удален {runtimeLocations[runtimeLocations.Count - 2].name}");
            Destroy(runtimeLocations[runtimeLocations.Count - 2]);
            
        }
    
    }
   
}
