using UnityEngine;

public class NpcTeammate : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private Transform currentObject;
    private bool activated = false;
    private float step;
    private Vector3 distanceToPlayer;


    private void Start()
    {
        
        speed = 8f;
        currentObject = GetComponent<Transform>();
    }

    private void Update()
    {
        distanceToPlayer = new Vector3(1, 0, 0);
        step = Time.deltaTime * speed;

        if (activated)
        {
            NpcMovement();
            
        }
    }

    private void NpcMovement()
    {
        currentObject.position = Vector2.MoveTowards(transform.position, target.position - distanceToPlayer , step);
        Debug.Log("NPC - I am Moving");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        activated = true;

    }


}
