using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ������ npc
    public List<GameObject> followingNPC = new List<GameObject>();// ���� � ������� ����� ��������� ��������� �� ������� npc
    [SerializeField] private float minDistance; // ����������� ��������� ����� npc
    [SerializeField] private float npcSpeed; // �������� npc
    [SerializeField] private float distanceNPC;
    private Transform currentNPC; // ��������� � �������� ���������
    private Transform previousNPC; // ��������� � �������� npc �������� ��������

    // ������ ������
    private Rigidbody2D playerRB; // rigidbody ������
    [SerializeField] private float speed; // �������� ������
    private float currentSpeed;
    [SerializeField] private float forceOfJump; // ���� ������
    [SerializeField] private Transform groundTriger;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded; // ����� �� �� �����
    private int extraJump = 1; // ���������� ��� �������
    private int currentJump; // ������� ���������� ����������� �������
    public static bool alive; // ������ ������ ��� ��� �����
    [SerializeField] private Animator playerAnimator;

    //������
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
    /// ����� ���������� npc ������� ������� �� �������.
    /// </summary>
    private void AddNPC()
    {
        GameObject npc = Instantiate(followingNPC[followingNPC.Count - 1], followingNPC[followingNPC.Count - 1].transform.position, followingNPC[followingNPC.Count - 1].transform.rotation);
        Destroy(npc);
    }

    /// <summary>
    /// ����� ���������� �� �������
    /// </summary>
    private void NPCMOve()
    {
        if (followingNPC.Count > 1) // �������� ������ ��� - ��� �� ��� ������ 1 ���������� ������� �������
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
    /// ����� ��������: ����� �� ����� �� �����
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
    /// ����� ������ � �������� ������
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
    /// ����������� ��������� ����� � ����� �������� ��������� ���������� �������
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
    /// ����� �������� ������ � �������
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
    /// ����� �������� ������ ��������
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
