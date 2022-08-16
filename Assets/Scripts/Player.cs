using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRB;

    [SerializeField] private float speed;
    [SerializeField] private float forceOfJump;
    private bool isJumped;
    public static bool isGrounded;
    private int extraJump;
    private int currnetJump;
    private bool doubleJump;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        speed = 8f;
        forceOfJump = 70f;
        isJumped = false;
        isGrounded = true;
        doubleJump = true;
        extraJump = 2;
        currnetJump = extraJump;
    }

    private void Update()
    {
        DetectJump();
        ResetJumpCount();
    }




    private void FixedUpdate()
    {
        playerRB.velocity = transform.right * speed;
        PlayerJump();


    }

    void PlayerJump()
    {
        if (isGrounded == false && currnetJump > 0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, forceOfJump);
            //playerRB.AddForce(transform.up * forceOfJump, ForceMode2D.Impulse);
            Debug.Log("space");

        }
        else if (currnetJump == 0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y);
        }

    }

    private void DetectJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;

        }

    }

    private void ResetJumpCount()
    {
        if (isGrounded == true)
        {
            currnetJump = extraJump;
        }

    }
}
