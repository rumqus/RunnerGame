using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLocationTriggerV2 : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private Player component;
    private Vector3 shift;
    private int randomIndex;
    private GameObject[] locations;
    [SerializeField] private GameObject parent;

    private void Start()
    {
        locations = gameManager.GetComponent<Locations>().levelLocations;
        shift = new Vector3(40,0,0);
        randomIndex = Random.Range(0, locations.Length);
        Locations.runtimeLocations.Add(parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out component))
        {
            
            GenerateLocation();
            Locations.DelRuntimeLocation();
            Actions.IncreaseSpeed();

        }
    }

   


    private void GenerateLocation() 
    {
       Instantiate(locations[randomIndex], transform.position + shift, Quaternion.identity);

    }
}
