using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenBoss : MonoBehaviour
{
    public float life = 100;
    public float startinglife = 100;

    float hitCloseness;
    public int speed = 5;

    float timer = 0;

    bool canHit = true;
    bool hitMode = true;
    bool canSpawnChickens = true;
    [SerializeField] GameObject[] chickens;

    float hitTimer = 0;

    GameObject instance1 = null;
    GameObject instance2 = null;
    GameObject instance3 = null;
    GameObject instance4 = null;

    public static bool spawned = false;

    [SerializeField] GameObject BoomEffect;

    bool canTurn = true;
    float turnTime = 0;

    [SerializeField] AudioClip[] PakasAudio;
    //Get Hit
    float hitAnimTimer = 0;
    bool hit = false;
    Vector3 originalScale;
    [SerializeField] AudioClip[] HitAudio;

    // Start is called before the first frame update
    void Start()
    {
        spawned = true;
        startinglife = life;
        hitCloseness = gameObject.transform.localScale.x / 10f;
        timer = Time.time;
        hitTimer = Time.time;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTurn && Time.time - turnTime > 1)
        {
            canTurn = true;
        }
        if (Time.time - timer > 3)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
        }
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (hitMode)
        {
            HitMode();
        }
        else
        {
            HardMode();
        }
        if (hit)
        {
            if (Time.time - hitAnimTimer > 0.02f)
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
    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Wall")
    //    {
    //        speed = -1 * speed;
    //        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
    //        GetComponent<Rigidbody2D>().velocity = new Vector3(-speed * other.transform.position.x / Mathf.Abs(other.transform.position.x), 0, 0);
    //    }
    //}
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ball" && canHit)
        {
            //If the right size
            if (other.gameObject.transform.localScale.x < hitCloseness &&
                other.gameObject.transform.localScale.x > (hitCloseness / 2))
            {
                Destroy(other.gameObject);
                HitChicken(1);

            }
        }
    }
    public void HardMode()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        canHit = false;
        GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);

        if (canSpawnChickens)
        {
            canSpawnChickens = false;
            instance1 = Instantiate(chickens[Random.Range(0, chickens.Length)], transform.position + new Vector3(Random.Range(-2,2),0,0), Quaternion.identity) as GameObject;
            instance2 = Instantiate(chickens[Random.Range(0, chickens.Length)], transform.position +new Vector3(Random.Range(-2, 2), 0, 0),Quaternion.identity) as GameObject;
             instance3 = Instantiate(chickens[Random.Range(0, chickens.Length)], transform.position + new Vector3(Random.Range(-2, 2), 0, 0), Quaternion.identity) as GameObject;
            instance4 = Instantiate(chickens[Random.Range(0, chickens.Length)], transform.position + new Vector3(Random.Range(-2, 2), 0, 0), Quaternion.identity) as GameObject;
            GameObject[] instances = { instance1, instance2, instance3, instance4 };
            for (int i = 0; i < instances.Length; i++)
            {
                int rnd = 1;
                if (Random.Range(0, 2) == 0)
                {
                    rnd = 1;
                }
                else
                {
                    rnd = -1;
                }
                instances[i].GetComponent<NnormalEnemy>().speed = instances[i].GetComponent<NnormalEnemy>().speed * (Random.Range(1f, 2f) * rnd);
            }
        }
        if (instance1 == null && instance2 == null && instance3 == null && instance4 == null)
        {
            hitMode = true;
            hitTimer = Time.time;
        }

    }
    public void HitMode()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        canHit = true;
        canSpawnChickens = true;
        GetComponent<SpriteRenderer>().color = new Color(1,1, 1, 1);
        if (Time.time - hitTimer > 10)
        {
            hitMode = false;
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
            transform.parent.localScale = transform.parent.localScale * 0.99f;
            hit = true;
            hitAnimTimer = Time.time;
            transform.localScale = transform.localScale * 0.95f;
            AudioSource.PlayClipAtPoint(HitAudio[Random.Range(0, HitAudio.Length)], new Vector3(0, 0, -7));
        }
    }
    public void ChickenDie()
    {
        AudioSource.PlayClipAtPoint(PakasAudio[Random.Range(0, PakasAudio.Length)], new Vector3(0, 0, -7));
        spawned = false;
        Destroy(gameObject);
        GameObject oBoom = Instantiate(BoomEffect, transform.position, Quaternion.identity) as GameObject;
        oBoom.GetComponent<Transform>().localScale = oBoom.GetComponent<Transform>().localScale * 3f;

        float timeTook = FindObjectOfType<Timer>().seconds;
        //Win
        if (timeTook > 30)
        {
            FindObjectOfType<ScoreCounter>().score = FindObjectOfType<ScoreCounter>().threeStarPoints + 1;
        }
        else if (timeTook > 15)
        {
            FindObjectOfType<ScoreCounter>().score = FindObjectOfType<ScoreCounter>().twoStarPoints + 1;
        }
        else if (timeTook >= 0)
        {
            FindObjectOfType<ScoreCounter>().score = FindObjectOfType<ScoreCounter>().scoreNeeded + 1;
        }
        FindObjectOfType<ScoreCounter>().Win();
    }
}
