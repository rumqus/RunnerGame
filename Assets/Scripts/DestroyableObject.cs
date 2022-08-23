using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    private GameObject destroybaleObject;
    private Rigidbody2D objectRB;
    private Collider2D objectCol;
    [SerializeField] private float force;
    [SerializeField] private GameObject coin;
    

    
    
    private void Start()
    {
        destroybaleObject = GetComponent<GameObject>();
        objectRB = GetComponent<Rigidbody2D>();
        objectCol = GetComponent<Collider2D>();
        
    }

    Player component;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.TryGetComponent<Player>(out component))
        {
            SmashObject();
            CreateCoin(3);
            
        }
    }

    private void SmashObject() 
    {
        Debug.Log("smash");
        objectRB.AddForce(transform.up * force, ForceMode2D.Impulse);
        objectRB.gravityScale = 2f;
        GetComponent<Animator>().enabled = true;
    }

    private void CreateCoin(int amount) 
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject smallCoin = Instantiate(coin, transform.position, Quaternion.identity);
        }
    
    }

}
