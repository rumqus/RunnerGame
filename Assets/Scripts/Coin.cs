using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player component;
    private Rigidbody2D coinRB;
    [SerializeField] private float force;
    private int randomForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out component))
        {
           Destroy(gameObject);
        }
    }

    private void Start()
    {
        randomForce = Random.Range(12, 19);
        coinRB = GetComponent<Rigidbody2D>();
        MoveCoin();
        
    }

    
    private void MoveCoin() 
    {
        coinRB.AddForceAtPosition(new Vector2(1,1) * randomForce, transform.position + new Vector3(5,5,0),ForceMode2D.Impulse);
        coinRB.gravityScale = 3f;
    }
}
