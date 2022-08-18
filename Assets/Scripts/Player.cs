using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRB;

    [SerializeField] private float speed; // скорость игрока
    [SerializeField] private float forceOfJump; // сила прыжка
    [SerializeField] private Transform groundTriger;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded; // стоит ли на змеле
     

    private int extraJump = 1; // количество доп прыжков
    private int currentJump; // текущее количество совершенных прыжков


    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        speed = 0f;
        forceOfJump = 35f;
        currentJump = 0;
        isGrounded = true;
        

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(5, 0, 0), speed * Time.deltaTime); ;
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        CheckGrounded();
        
    }

    /// <summary>
    /// движение игрока
    /// </summary>
    private void FixedUpdate()
    {
       // playerRB.velocity = new Vector2(speed, playerRB.velocity.y);
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
            
        }
    }

}
