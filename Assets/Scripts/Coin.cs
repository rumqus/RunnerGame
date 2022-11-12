using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player component;
    private Rigidbody2D coinRB; // Рригидбоди монетки
    private int randomForce; // случайная сила с которой монетка улетает при появлении
    [SerializeField] private float lifeTime; // время жизни монетки
    private float maxRandom;
    private float minRandom;
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out component))
        {
           Destroy(gameObject);
           Actions.countCoins();
           FindObjectOfType<AudioManager>().SoundPlay("coin");

        }
    }

    private void Start()
    {
        
        SetCoinPushSpeed();
        maxRandom = Random.Range(0.5f,1f);
        minRandom = Random.Range(0.5f, 0.7f); 
        coinRB = GetComponent<Rigidbody2D>();
        MoveCoin();
    }

    private void Update()
    {
        DestoyCoin();
    }

    private void SetCoinPushSpeed() 
    {
        if (Locations.locationSpeed > 20)
        {
            randomForce = Random.Range(25,35);
        }
        else
        {
            randomForce = Random.Range(20, 25);
        }
    }

    /// <summary>
    /// метод движения моентки при появлении
    /// </summary>
    private void MoveCoin() 
    {
        if (Locations.locationSpeed > 20)
        {
            coinRB.AddForceAtPosition(new Vector2(1f, minRandom) * randomForce, transform.position + new Vector3(10, 5, 0), ForceMode2D.Impulse);
            
        }
        else if (Locations.locationSpeed < 20)
        {
            coinRB.AddForceAtPosition(new Vector2(1, maxRandom) * randomForce, transform.position + new Vector3(5, 5, 0), ForceMode2D.Impulse);
        }
        coinRB.gravityScale = 3f;
    }

    /// <summary>
    /// метод удаления монетки
    /// </summary>
    private void DestoyCoin() 
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <=0)
        {
            Destroy(gameObject);
        }    
    
    }
}
