using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRB;

    [SerializeField] private float speed;
    [SerializeField] private float forceOfJump;
    [SerializeField] private Transform groundTriger;
    [SerializeField] private LayerMask groundLayer;
    
    
    private bool isGrounded;
    
    private int extraJump = 1;
    private int currentJump;
    

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        speed = 8f;
        forceOfJump = 35f;
        currentJump = 0;
        isGrounded = true;

    }

    private void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        CheckGrounded();
        Debug.Log(isGrounded);
        Debug.Log(currentJump);
        
    }




    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(speed, playerRB.velocity.y);
        

    }

    

   

    /// <summary>
    /// метод проверки стоит ли игрок на земле
    /// </summary>
    private void CheckGrounded() 
    {
        if (Physics2D.OverlapCircle(groundTriger.position, 0.01f, groundLayer))
        {
            isGrounded = true;
            currentJump = 0;
        }
        else 
        {
            isGrounded = false;
        }

    }

    public void Jump() 
    {
        if (isGrounded = true && currentJump < extraJump)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, forceOfJump);
            currentJump++;
            Debug.Log("JUMP METHOD DONE");
        }
         
    
    }

    private bool DetectJump() 
    {
        if (Input.GetButtonDown("Jump"))
        {
            return true;
        }
        else 
        {
            return false;
        }
    
    }

}
