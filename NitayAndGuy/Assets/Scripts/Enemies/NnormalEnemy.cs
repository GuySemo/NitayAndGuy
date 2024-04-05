using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NnormalEnemy : MonoBehaviour
{
    //Attributes
    public float life = 3;
    float startinglife;
    [SerializeField] public float speed = 5;
    float hitCloseness = 0.2f;

    //Effects
    [SerializeField] GameObject boomEffect;
    [SerializeField] GameObject boom2Effect;

    //ChickenTypes
    public bool isMother = false;
    public bool isBoom = false;
    [SerializeField] bool isBoss=false;

    //Points
    [SerializeField] int pointsGive = 6;

    public static bool started = false;


    public static int chickens;
    public static int chickensAlive;
    public int chickenLimit = 20;

    [SerializeField] AudioClip[] PakasAudio;

    bool canTurn = true;
    float turnTime = 0;

    //Get Hit
    float hitTimer = 0;
    bool hit = false;
    Vector3 originalScale;
    [SerializeField] AudioClip[] HitAudio;

    // Start is called before the first frame update
    void Start()
    {
        startinglife = life;
        chickens++;
        chickensAlive++;
        if (chickensAlive > chickenLimit )
        {
            chickensAlive--;
            Destroy(gameObject);
        }
        started = false;
        hitCloseness = gameObject.transform.localScale.x / 5;
        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTurn && Time.time - turnTime > 1)
        {
            canTurn = true;
        }

        if (GetComponent<Rigidbody2D>().velocity.x >0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (hit)
        {
            if (Time.time - hitTimer > 0.02f)
            {
                transform.localScale = originalScale;
                hit = false;
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" && canTurn)
        {
            canTurn = false;
            turnTime = Time.time;

            speed = -1 * speed;
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
            //GetComponent<Rigidbody2D>().velocity = new Vector3(-speed*other.transform.position.x/Mathf.Abs(other.transform.position.x),0,0);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            //If the right size
            if (other.gameObject.transform.localScale.x < hitCloseness &&
                other.gameObject.transform.localScale.x > (hitCloseness / 2))
            {
                Destroy(other.gameObject);
                HitChicken(1);
                
            }
        }
        if (other.tag == "Death")
        {
            ChickenDie();
        }
    }

    public void HitChicken(float damage)
    {
        life = life - damage;
        if (life <= 0)
        {
            ChickenDie();
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, life/startinglife ,life/startinglife,1);
            hit = true;
            hitTimer = Time.time;
            transform.localScale = transform.localScale * 0.95f;
            AudioSource.PlayClipAtPoint(HitAudio[Random.Range(0, HitAudio.Length)], new Vector3(0, 0, -7));

        }
    }
    public void ChickenDie()
    {
        AudioSource.PlayClipAtPoint(PakasAudio[Random.Range(0, PakasAudio.Length)], new Vector3(0,0,-7));
        chickensAlive--;
        //Give Points (Based On Size)
        FindObjectOfType<ScoreCounter>().AddScore(Mathf.RoundToInt((Random.Range(pointsGive, pointsGive + 2)) / transform.localScale.x) );
        //Debug.Log(Mathf.RoundToInt((Random.Range(6, 8)) / transform.localScale.x));

        //Effects
        GameObject boom1 = Instantiate(boomEffect, gameObject.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
        boom1.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale;
        GameObject boom2 = Instantiate(boom2Effect, gameObject.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
        boom2.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale;
        //Kill Chicken
        if (isMother)
        {
            GetComponent<ChickenMother>().ChickenDie();
        }
        else if (isBoom)
        {
            GetComponent<Exploding>().ChickenDie();
        }
        else if (isBoss)
        {
            GetComponent<ChickenBoss>().ChickenDie();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //hi guy this is for future enemies, ok Nitay!!!!
    public void EnemyRegen()
    {
        life = life + 1;
    }

}
