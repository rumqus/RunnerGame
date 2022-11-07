using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player component;
    private AudioSource EnemyAudio;
    [SerializeField]private float barkTimer;
    private float currentBarkTimer;

    private void Start()
    {
        EnemyAudio = GetComponent<AudioSource>();
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
            EnemyAudio.Play();
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<Player>(out component))
        {
            Player.alive = false;
            Actions.startDeathAnimaion();
            StartCoroutine(DelayDeath());
            
        }
    }

    IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(0.433f);
        Actions.endGame();
        component.gameObject.GetComponent<Player>().enabled = false;       
    }
}
