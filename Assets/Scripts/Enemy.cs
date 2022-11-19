using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player component;
    [SerializeField]private float barkTimer;
    private float currentBarkTimer;

    private void Start()
    {
        currentBarkTimer = barkTimer;
    }

    private void Update()
    {
        Bark();
    }

    private void Bark() 
    {
        if (currentBarkTimer > 0)
        {
            currentBarkTimer -= Time.deltaTime;
        }
        else 
        {
            currentBarkTimer = barkTimer;
            FindObjectOfType<AudioManager>().SoundPlay("bark");
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.TryGetComponent<Player>(out component))
        {
            
            if (Player.alive != null)
            {
                Player.alive = false;
                Actions.startDeathAnimaion();
                StartCoroutine(DelayDeath());

            }           
            
        }
    }

    IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(0.433f);
        Actions.endGame();
        if (Player.alive != false)
        {
            component.gameObject.GetComponent<Player>().enabled = false;
        }
             
    }
}
