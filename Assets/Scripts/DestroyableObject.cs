using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    Player component; // ��������� � ������� ��� ����������� � ��� ���������� ����������� ������
    private GameObject destroybaleObject;
    private Rigidbody2D objectRB;
    private Collider2D objectCol;
    [SerializeField] private float force; // ���� � ������� ������� �������� ������
    [SerializeField] private GameObject coin; // ������ ������
    private int randomCoins; // ��������� ���������� ����� ���������� � �������� �������
    private ParticleSystem partisiple;
    private SpriteRenderer spriteRender;
    [SerializeField] private Sprite destroyedSprite;
    private AudioSource desObjectAudio;
        
    
    private void Start()
    {
        destroybaleObject = GetComponent<GameObject>();
        objectRB = GetComponent<Rigidbody2D>();
        objectCol = GetComponent<Collider2D>();
        randomCoins = Random.Range(1, 3);
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        desObjectAudio = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.TryGetComponent<Player>(out component))
        {
            SmashObject();
            CreateCoin(randomCoins);
            gameObject.layer = 7;
            desObjectAudio.Play();
        }
    }

    private void ChangeSprite() 
    {
        spriteRender.sprite = destroyedSprite;    
    }


    /// <summary>
    /// ����� ������������ � ��������
    /// </summary>
    private void SmashObject() 
    {
        
        objectRB.AddForce(transform.up * force, ForceMode2D.Impulse);
        objectRB.gravityScale = 2f;
        GetComponent<Animator>().enabled = true;
        objectCol.enabled = false;
        ChangeSprite();
    }

    /// <summary>
    /// ����� ��������� ����� �� ��������� �������, ��������� ��� � ���������� �� ��� �������� ���������� �����
    /// </summary>
    /// <param name="amount"></param>
    private void CreateCoin(int amount) 
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject smallCoin = Instantiate(coin, transform.position + transform.right, Quaternion.identity);
            smallCoin.transform.SetParent(gameObject.transform, true);
        }    
    }

}
