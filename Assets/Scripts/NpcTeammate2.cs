using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTeammate2 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> listNPC;
   
    private void Start()
    {
        listNPC = player.GetComponent<Player>().followingNPC;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Collider2D>().enabled = false;
            listNPC.Add(gameObject);
            Actions.addNPC();
        }



    }

}
