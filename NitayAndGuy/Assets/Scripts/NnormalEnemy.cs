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
    // Start is called before the first frame update
    void Start()
    {
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
            if (other.gameObject.transform.localScale.x < hitCloseness &&
                other.gameObject.transform.localScale.x > (hitCloseness - hitCloseness / 2))
            {
                Destroy(other.gameObject);
                HitChicken();
                
            }
        }
    }
    public void HitChicken()
    {
        life = life - 1;
        if (life == 0)
        {
            ChickenDie();
        }
        else
        {
            Debug.Log(1 - (1 / life));
            GetComponent<SpriteRenderer>().color = new Color(1, 1 - (1 / life), 1- ( 1 / life),1);
        }
    }
    public void ChickenDie()
    {
        if (isMother)
        {
            Instantiate(boomEffect, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            Instantiate(boom2Effect, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            GetComponent<ChickenMother>().ChickenDie();
        }
        else
        {
            Instantiate(boomEffect, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            Instantiate(boom2Effect, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(gameObject);
        }
    }

}
