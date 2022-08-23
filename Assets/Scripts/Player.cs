using System.Collections;
using System.Collections.Generic;
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
    private Rigidbody2D playerRB; // rigid body ������
    [SerializeField] private float speed; // �������� ������
    private float currentSpeed;
    [SerializeField] private float forceOfJump; // ���� ������
    [SerializeField] private Transform groundTriger;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded; // ����� �� �� �����
    private int extraJump = 1; // ���������� ��� �������
    private int currentJump; // ������� ���������� ����������� �������

   
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        forceOfJump = 35f;
        currentJump = 0;
        isGrounded = true;
        followingNPC.Add(gameObject);
        
    }



    private void Update()
    {
        
        npcSpeed = speed - 0.1f;
        transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(1, 0, 0), speed * Time.deltaTime); ;
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        CheckGrounded();
        NPCMOve();        
    }


    private void OnEnable()
    {
        Actions.addNPC += AddNPC;
    }

    private void OnDisable()
    {
        Actions.addNPC -= AddNPC;
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
                Vector3 newPositionNPC = previousNPC.position;
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

}
