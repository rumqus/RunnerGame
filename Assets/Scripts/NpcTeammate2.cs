using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcTeammate2 : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Scene scene;
    [SerializeField] private List<GameObject> listNPC;
    private Player component;
    bool harvested;
    private float lifeTimer;
    private Animator npcAnimator;

    private void Start()
    {
        lifeTimer = 10f;
        player = GameObject.FindGameObjectWithTag("Player");
        listNPC = player.GetComponent<Player>().followingNPC;
        npcAnimator = GetComponentInChildren<Animator>();

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
            gameObject.transform.parent = null;
            Actions.trimChainNPC();
            npcAnimator.SetBool("run", true);

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
