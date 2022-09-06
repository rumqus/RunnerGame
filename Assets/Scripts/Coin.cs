using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player component;
    private Rigidbody2D coinRB; // Рригидбоди монетки
    private int randomForce; // случайная сила с которой монетка улетает при появлении
    [SerializeField] private float lifeTime; // время жизни монетки

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out component))
        {
           Destroy(gameObject);
           Actions.countCoins();
        }
    }

    private void Start()
    {
        randomForce = Random.Range(12, 18) + (int)Locations.locationSpeed/2;
        coinRB = GetComponent<Rigidbody2D>();
        MoveCoin();
        
    }

    private void Update()
    {
        DestoyCoin();
    }

    /// <summary>
    /// метод движения моентки при появлении
    /// </summary>
    private void MoveCoin() 
    {
        coinRB.AddForceAtPosition(new Vector2(1,1) * randomForce, transform.position + new Vector3(5,5,0),ForceMode2D.Impulse);
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
