using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    public GameObject[] levelLocations; // ������ � ���������
    public static List<GameObject> runtimeLocations = new List<GameObject>();
        
    
    /// <summary>
    /// ����� �������� ���������� ������� � ��������
    /// </summary>
    public static void DelRuntimeLocation() 
    {
        if (runtimeLocations.Count >=2 )
        {
            Destroy(runtimeLocations[runtimeLocations.Count - 2]);
            runtimeLocations.RemoveAt(runtimeLocations.Count - 2);
                        
        }    
    }   
}
