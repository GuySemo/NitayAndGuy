using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NnormalEnemy : MonoBehaviour
{
    public float life = 3;
    [SerializeField] GameObject boomEffect;
    [SerializeField] GameObject boom2Effect;

    [SerializeField] public float speed = 5;

    public bool isMother = false;

    public float hitCloseness = 0.2f;

    public static bool started = false;

    [SerializeField] int pointsGive = 6;

    public static int chickens;
    public static int chickensAlive;
    public int chickenLimit = 20;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        //if (starter)
        //{
        //    //GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
        //    starter = false;
        //}
        //Change Direction

        //if (Time.time>lasttime)
        //{
        //    if (Random.Range(1,4)==3)
        //    {
        //        speed = Random.Range(5, 30) / 2.5f;
        //        ChangeDirection = Random.Range(0,2);
        //        if (ChangeDirection==0)
        //        {
        //            ChangeDirection = -1;
        //        }
        //        GetComponent<Rigidbody2D>().velocity = new Vector3(ChangeDirection*speed,0,0);
        //    }
        //    lasttime = Time.time + 0.5f;
            
        //}
        if (GetComponent<Rigidbody2D>().velocity.x >0)
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
                Destroy(other.gameObject);
                HitChicken(other.GetComponent<Nball>().myDamage);
                
            }
        }
    }

    public void HitChicken(float damage)
    {
        life = life - damage;
        Debug.Log(life);
        if (life <= 0)
        {
            ChickenDie();
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1 - (1 / life), 1- ( 1 / life),1);
        }
    }
    public void ChickenDie()
    {
        chickensAlive--;
        //Give Points (Based On Size)
        FindObjectOfType<ScoreCounter>().AddScore(Mathf.RoundToInt((Random.Range(pointsGive, pointsGive + 2)) / transform.localScale.x) );
        //Debug.Log(Mathf.RoundToInt((Random.Range(6, 8)) / transform.localScale.x));

        //Kill Chicken
        if (isMother)
        {
            GameObject boom1 = Instantiate(boomEffect, gameObject.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
            boom1.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale;
            GameObject boom2 = Instantiate(boom2Effect, gameObject.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
            boom2.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale;
            GetComponent<ChickenMother>().ChickenDie();
        }
        else
        {
            GameObject boom1 = Instantiate(boomEffect, gameObject.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
            boom1.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale;
            GameObject boom2 = Instantiate(boom2Effect, gameObject.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
            boom2.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale;
            Destroy(gameObject);
        }
    }

    //hi guy this is for future enemies, ok Nitay!!!!
    public void EnemyRegen()
    {
        life = life + 1;
    }

}
