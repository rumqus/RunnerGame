using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    // данные npc
    public List<GameObject> followingNPC = new List<GameObject>();// лист в который будем добавлять следующих за игроком npc
    [SerializeField] private float minDistance; // минимальная дистанция между npc
    [SerializeField] private float npcSpeed; // скорость npc
    [SerializeField] private float distanceNPC;
    private Transform currentNPC; // положение к которому двиэенмся
    private Transform previousNPC; // положение с которого npc начинате движение

    // данные игрока
    private Rigidbody2D playerRB; // rigidbody игрока
    [SerializeField] private float speed; // скорость игрока
    private float currentSpeed;
    [SerializeField] private float forceOfJump; // сила прыжка
    [SerializeField] private Transform groundTriger;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded; // стоит ли на змеле
    private int extraJump = 1; // количество доп прыжков
    private int currentJump; // текущее количество совершенных прыжков
    public static bool alive; // статус игрока жив или мертв
    [SerializeField] private Animator playerAnimator;

    //камера
    [SerializeField] private CinemachineVirtualCamera camera;
    private CinemachineFramingTransposer transposer;
    private float maxCameraDamping = 20f;
    private float minCameraDamping = 1f;



    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        forceOfJump = 35f;
        currentJump = 0;
        isGrounded = true;
        followingNPC.Add(gameObject);
        alive = true;
        transposer = camera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }



    private void Update()
    {
        npcSpeed = 5f;
        transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(1, 0, 0), speed * Time.deltaTime); ;
        if (Input.GetButtonDown("Jump"))
        {

            Jump();

        }
        CheckGrounded();
        NPCMOve();
        CalculateDistance();
        ChangeCameraDamping();
    }


    private void OnEnable()
    {
        Actions.addNPC += AddNPC;
        Actions.startAnimation += StartAnimationRun;
        Actions.startDeathAnimaion += StartDeathAnim;
        Actions.trimChainNPC += TrimFolloowingNPCList;
    }

    private void OnDisable()
    {
        Actions.addNPC -= AddNPC;
        Actions.startAnimation -= StartAnimationRun;
        Actions.startDeathAnimaion -= StartDeathAnim;
        Actions.trimChainNPC -= TrimFolloowingNPCList;

    }

    /// <summary>
    /// метод добавления npc который следует за игроком.
    /// </summary>
    private void AddNPC()
    {
        GameObject npc = Instantiate(followingNPC[followingNPC.Count - 1], followingNPC[followingNPC.Count - 1].transform.position, followingNPC[followingNPC.Count - 1].transform.rotation);
        Destroy(npc);
    }

    /// <summary>
    /// метод следования за игроком
    /// </summary>
    private void NPCMOve()
    {
        if (followingNPC.Count > 1) // проверем список нпс - что бы был больше 1 начального объекта игррока
        {
            for (int i = 1; i < followingNPC.Count; i++)
            {
                currentNPC = followingNPC[i].transform;
                previousNPC = followingNPC[i - 1].transform;
                distanceNPC = Vector3.Distance(previousNPC.position, currentNPC.position);
                float npcTime = Time.deltaTime * distanceNPC / minDistance * npcSpeed;
                Vector3 newPositionNPC = previousNPC.position - new Vector3(2f, 0, 0);
                currentNPC.position = Vector3.Slerp(currentNPC.position, newPositionNPC, npcTime);
            }
        }
    }

    /// <summary>
    /// метод проверки: стоит ли игрок на земле
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
        ChangeBoolAnimation();
    }

    /// <summary>
    /// метод прыжка и двойного прыжка
    /// </summary>
    public void Jump()
    {
        if (isGrounded = true && currentJump < extraJump)
        {

            playerRB.velocity = new Vector2(playerRB.velocity.x, forceOfJump);
            currentJump++;
        }
    }

    /// <summary>
    /// оборачиваем статичный метод в метод подсчета дистанции пройденной игроком
    /// </summary>
    private void CalculateDistance()
    {
        if (alive == true)
        {
            GameScores.maxDistance = (int)Mathf.Round(transform.position.x / 3);
        }
    }


    private void ChangeCameraDamping()
    {
        if (isGrounded == true)
        {
            transposer.m_YDamping = minCameraDamping;
        }
        else
        {
            transposer.m_YDamping = maxCameraDamping;
        }
    }

    /// <summary>
    /// Смена анимации прыжка и обратно
    /// </summary>
    private void ChangeBoolAnimation()
    {
        if (isGrounded == false)
        {
            playerAnimator.SetBool("jumped", true);

        }
        else
        {
            playerAnimator.SetBool("jumped", false);
        }
    }
    
    /// <summary>
    /// метод удаления лишних объектов
    /// </summary>
    private void TrimFolloowingNPCList()
    {      
        if (followingNPC.Count > 10)
        {            
            for (int i = 10; i < followingNPC.Count; i++)
            {              
                Destroy(followingNPC[i]);
                followingNPC.RemoveAt(followingNPC.Count - 1);                
            }
        }
    }

    private void StartAnimationRun()
    {
        playerAnimator.SetBool("run", true);
    }

    private void StartDeathAnim()
    {
        playerAnimator.SetBool("death", true);
    }
}
