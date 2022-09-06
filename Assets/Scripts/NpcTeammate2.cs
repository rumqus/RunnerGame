using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTeammate2 : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private List<GameObject> listNPC;
    private Player component;
    bool harvested;
    private float lifeTimer;
   
    private void Start()
    {
        lifeTimer = 10f;
        player = GameObject.FindGameObjectWithTag("Player");
        listNPC = player.GetComponent<Player>().followingNPC;
        
    }

    private void Update()
    {
        DestryOverTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out component))
        {
            GetComponent<Collider2D>().enabled = false;
            harvested = true;
            listNPC.Add(gameObject);
            Actions.countNPC();
            
            
        }
    }


    /// <summary>
    /// удаление дружественных нпс по таймеру
    /// </summary>
    private void DestryOverTime() 
    {
        lifeTimer -= Time.deltaTime;
        if (harvested == false && lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    
    }

}
