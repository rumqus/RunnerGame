using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLocationTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private Player component;
    private Vector3 shift;
    private int randomIndex;
    private GameObject[] locations;

    private void Start()
    {
        locations = gameManager.GetComponent<Locations>().levelLocations;
        shift = new Vector3(40,0,0);
        randomIndex = Random.Range(0, locations.Length);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out component))
        {
            Debug.Log("Generate Level Location");
            GenerateLocation();
        }
    }

    private void GenerateLocation() 
    {
       Instantiate(locations[randomIndex], transform.position + shift, Quaternion.identity);

    }
}
