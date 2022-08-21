using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTeammate2 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private List<GameObject> listNPC;

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


    //[SerializeField] private Transform target;
    //[SerializeField] private float speed;
    //private float currentSpeed;
    //private Transform currentObject;
    //private bool activated = false;
    //private bool stop;
    //private float step;
    //private Vector3 distance;
    //private float minDistance;
    //private float maxDistance;



    //private void Start()
    //{
    //    speed = 4.5f;
    //    currentObject = GetComponent<Transform>();
    //    minDistance = 1.5f;
    //    maxDistance = 8f;
    //    distance = new Vector3(Random.Range(1, 4), 0, 0);
    //    Debug.Log($@"Дистанция до игрока {distance}");
    //    currentSpeed = speed;
    //}

    //private void Update()
    //{
    //    step = Time.deltaTime * currentSpeed;

    //    if (activated)
    //    {
    //        NpcMovement();

    //    }
    //}

    //private void NpcMovement()
    //{


    //}



    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        activated = true;

    //        // distance = new Vector3(NPCList.sizeDistance,0,0);
    //        // NPCList.sizeDistance++;
    //        GetComponent<Collider2D>().enabled = false;


    //    }

    //}


}
