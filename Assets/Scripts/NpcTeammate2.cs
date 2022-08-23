using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTeammate2 : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private List<GameObject> listNPC;
    private Player component;
   
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        listNPC = player.GetComponent<Player>().followingNPC;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out component))
        {
            GetComponent<Collider2D>().enabled = false;
            listNPC.Add(gameObject);
            Actions.addNPC();
            Actions.countNPC();
        }



    }

}
