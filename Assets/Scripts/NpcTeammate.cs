using UnityEngine;

public class NpcTeammate : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private Transform currentObject;
    private bool activated = false;
    private float step;
    private Vector3 distance;



    private void Start()
    {
        speed = 4.1f;
        currentObject = GetComponent<Transform>();

    }

    private void Update()
    {

        step = Time.deltaTime * speed;

        if (activated)
        {
            NpcMovement();

        }
    }

    private void NpcMovement()
    {
        currentObject.position = Vector2.MoveTowards(transform.position, target.position - distance , step);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activated = true;
            distance = new Vector3(NPCList.sizeDistance,0,0);
            NPCList.sizeDistance++;
            GetComponent<Collider2D>().enabled = false;


        }

    }


}
