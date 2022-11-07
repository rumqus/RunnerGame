using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    Player component; // необходим в тригере для определения с чем столкнулся разрушаемый объект
    private GameObject destroybaleObject;
    private Rigidbody2D objectRB;
    private Collider2D objectCol;
    [SerializeField] private float force; // сила с которой улетает подьитый обхект
    [SerializeField] private GameObject coin; // префаб монеты
    private int randomCoins; // случайное количество монет выпадающих в подбитом объекте
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
    /// метод столкновения с объектом
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
    /// метод генерации монет из подбитого объекта, принимает инт и генерирует по его значению количество монет
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
