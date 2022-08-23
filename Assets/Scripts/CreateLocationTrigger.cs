using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLocationTrigger : MonoBehaviour
{
    private Player component;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out component))
        {
            Debug.Log("Generate Level Location");
            Actions.generateLocation();
        }
    }
}
