using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class WalkingMonkey : MonoBehaviour
{
    //Attributes
    public float life = 3;
    [SerializeField] public float speed = 5;
    [SerializeField] public float jump = 2;
    float hitCloseness = 0.2f;
    Animator anim;

    //Effects
    [SerializeField] GameObject boomEffect;
    [SerializeField] GameObject boom2Effect;

    //ChickenTypes
    public bool isPurple = false;

    float lasttime = 0;
    int ChangeDirection;

    //Points
    [SerializeField] int pointsGive = 6;

    public static bool started = false;


    public static int chickens;
    public static int chickensAlive;
    public int chickenLimit = 20;

    public float sizeMod = 1;
    [SerializeField] public AudioClip[] PakasAudio;

    public static int maxPoints = 23;
    [SerializeField] GameObject RedEffect;

    public float bananaClose = 4;
    public bool isHung = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isPurple", isPurple);
        chickens++;
        chickensAlive++;
        Debug.Log(chickensAlive);
        if (chickensAlive > chickenLimit)
        {
            chickensAlive--;
            Debug.Log("KILLED ONE");
            Destroy(gameObject);
        }
        started = false;
        hitCloseness = gameObject.transform.localScale.x / bananaClose;
        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, jump, 0);
        lasttime = Time.time + 3f;

        if (isHung)
        {
            chickensAlive--;
            Destroy(gameObject, 4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lasttime)
        {
            if (Random.Range(3, 4) == 3)
            {
                jump = Random.Range(5, 9);
                ChangeDirection = Random.Range(0, 2);
                if (ChangeDirection == 0)
                {
                    ChangeDirection = -1;
                }
                GetComponent<Rigidbody2D>().velocity += new Vector2(0, jump);
            }
            lasttime = Time.time + 2.5f;

        }
        if (GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed, jump, 0);
        }

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
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
                HitChicken(1);
            }
        }
        if (other.tag == "Death")
        {
            ChickenDie();
        }
        if (other.tag == "Finish")
        {
            Destroy(gameObject);
            chickensAlive--;
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
            GetComponent<SpriteRenderer>().color = new Color(1, 1 - (1 / life * 10), 1 - (1 / life * 10), 1);
        }
    }
    public void ChickenDie()
    {
        AudioSource.PlayClipAtPoint(PakasAudio[Random.Range(0, PakasAudio.Length)], new Vector3(0, 0, -7));
        chickensAlive--;
        //Give Points (Based On Size)
        if (!isPurple)
        {
            int pointsAdd = Mathf.RoundToInt((Random.Range(pointsGive, pointsGive + 2)) * (Mathf.Abs(Gbanana.vel) + 1));
            if (pointsAdd > maxPoints)
            {
                pointsAdd = maxPoints;
            }
            FindObjectOfType<ScoreCounter>().AddScore(pointsAdd);
        }
        else
        {
            FindObjectOfType<ScoreCounter>().RemoveScore(FindObjectOfType<ScoreCounter>().score / 4);
            Instantiate(RedEffect, new Vector3(0,0,0), Quaternion.identity);
        }        //Debug.Log(Mathf.RoundToInt((Random.Range(6, 8)) / transform.localScale.x));

        //Effects
        GameObject boom1 = Instantiate(boomEffect, gameObject.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
        boom1.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale * sizeMod;
        GameObject boom2 = Instantiate(boom2Effect, gameObject.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
        boom2.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale * sizeMod;
        //Kill Chicken
        Destroy(gameObject);

    }

    //hi guy this is for future enemies, ok Nitay!!!!
    public void EnemyRegen()
    {
        life = life + 1;
    }

}
