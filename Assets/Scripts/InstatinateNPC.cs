using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatinateNPC : MonoBehaviour
{
    [SerializeField] private GameObject npc;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(npc,transform.position,Quaternion.identity);
    }

}
