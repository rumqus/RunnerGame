using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    public GameObject[] LevelLocations; // массив с локациями
    private Vector3 shift; // сдвиг для генерации новой локации
    private int randomIndex; // случайный индекс


    private void OnEnable()
    {
        Actions.generateLocation += GenerateLocation;
        
    }

    private void OnDisable()
    {
        Actions.generateLocation -= GenerateLocation;
    }

    private void Start()
    {
        shift = new Vector3(40,0,0);
        randomIndex = Random.Range(0,LevelLocations.Length); // без последнего индекса норм

    }

    private void GenerateLocation() 
    {
        Instantiate(LevelLocations[randomIndex], transform.position + shift, Quaternion.identity);
    
    }

}
