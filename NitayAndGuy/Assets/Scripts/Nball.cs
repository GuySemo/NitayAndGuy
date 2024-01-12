using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nball : MonoBehaviour
{
    [SerializeField] float sizeSpeed= 100;
    public bool isTouching = false;
    GameObject objectHit;
    [SerializeField] GameObject boomEffect;
    [SerializeField] GameObject boom2Effect;

    //hit closeness
    [SerializeField] float hitCloseness = 0.5f;

    [SerializeField] GameObject crackedEgg;

    //RandomSpin
    float spinDir;

    static bool firstEgg = true;

    void Start()
    {
        if (firstEgg)
        {
            firstEgg = false;
            FindObjectOfType<SleepingChick>().Awaken();
            FindObjectOfType<Timer>().started = true;
        }
        spinDir = Random.Range(-720, 720);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //Spinning
        transform.Rotate(0, 0, spinDir * Time.deltaTime);

        //Destroy When Too Small
        if (gameObject.transform.root.localScale.x< hitCloseness / 2 && GetComponent<SpriteRenderer>().sortingOrder != -1)
        {
            GetComponent<SpriteRenderer>().sortingOrder = -1;
        }

        //Smallning
        transform.localScale =
            new Vector3((gameObject.transform.localScale.x * (sizeSpeed - 1) / sizeSpeed)
          , (gameObject.transform.localScale.y * (sizeSpeed - 1) / sizeSpeed)
            , 1);

        //gameObject.transform.localScale =new Vector3( gameObject.transform.localScale.x * sizeSpeed * Time.deltaTime, gameObject.transform.localScale.y * sizeSpeed * Time.deltaTime, 0);
        //Hit Enemy
        //if (gameObject.transform.root.localScale.x < hitCloseness &&
        //    gameObject.transform.root.localScale.x >( hitCloseness - hitCloseness /2 )&& isTouching)
        //{
        //    Instantiate(boomEffect, objectHit.transform.position, Quaternion.Euler(90,0,0));
        //    Destroy(objectHit);
        //    Destroy(gameObject);
        //}
    }
    private void OnCollisionStay2D(Collision2D other)
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "BreakEgg")
        {
            if (gameObject.transform.root.localScale.x < other.GetComponent<WallsBreakEgg>().eggSize &&
                gameObject.transform.root.localScale.x > other.GetComponent<WallsBreakEgg>().eggSize /2)
            {
                float crackedSize = other.GetComponent<WallsBreakEgg>().crackedSize;
                GameObject oCracked = Instantiate(crackedEgg, transform.position, Quaternion.identity) as GameObject;
                oCracked.transform.localScale = new Vector3(crackedSize, crackedSize, crackedSize);
                oCracked.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = other.GetComponent<WallsBreakEgg>().sortingLayer;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            isTouching = false;
        }
    }

}
