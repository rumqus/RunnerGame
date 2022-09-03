using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player component;

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
        component.gameObject.GetComponent<Player>().enabled = false;
        Debug.Log("FAIL - END GAME");
    }
}
