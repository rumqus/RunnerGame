using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    
    public GameObject[] levelLocations; // ������ � ���������
    public static List<GameObject> runtimeLocations = new List<GameObject>();
    public static float locationSpeed;
    public static float index;

    private void Start()
    {
        locationSpeed = 0;
    }


    /// <summary>
    /// ����� �������� ���������� ������� � ��������
    /// </summary>
    public static void DelRuntimeLocation() 
    {
        if (runtimeLocations.Count >=3 )
        {
            Destroy(runtimeLocations[runtimeLocations.Count - 3]);
            runtimeLocations.RemoveAt(runtimeLocations.Count - 3);                        
        }    
    }   
}
