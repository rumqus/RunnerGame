using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationsV2 : MonoBehaviour
{
    private float speed;

    private void OnEnable()
    {
        Actions.IncreaseSpeed += IncreaseSpeeds;
    }
    private void OnDisable()
    {
        Actions.IncreaseSpeed -= IncreaseSpeeds;
    }

    private void Update()
    {
        speed = Locations.locationSpeed;
        transform.position = Vector2.MoveTowards(transform.position, transform.right * -80, speed * Time.deltaTime);
        
    }

    /// <summary>
    /// метод увеличивающий скорость движения локации
    /// </summary>
    private void IncreaseSpeeds()
    {
        Locations.index++;
        if (Locations.index % 3 == 0 && Locations.locationSpeed < 25)
        {
            Locations.locationSpeed += 0.25f;
            Debug.Log(@$"скорость {Locations.index}");
            Debug.Log(@$"index {Locations.locationSpeed}");
        }
       
        
       
    }

}
