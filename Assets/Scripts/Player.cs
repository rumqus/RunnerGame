using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRB;

    [SerializeField] private float speed;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        speed = 2f;
    }


    private void FixedUpdate()
    {
        playerRB.AddForce(transform.right * speed);

    }

}
