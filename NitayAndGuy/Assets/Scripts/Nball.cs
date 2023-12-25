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

    //RandomSpin
    float spinDir;

    void Start()
    {
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
        if (gameObject.transform.root.localScale.x>=  hitCloseness / 2)
        {
            //Smallning
        }
        gameObject.transform.root.localScale =
    new Vector3((gameObject.transform.localScale.x * (sizeSpeed - 1) / sizeSpeed) /** Time.deltaTime*/
    , (gameObject.transform.localScale.y * (sizeSpeed - 1) / sizeSpeed) /** Time.deltaTime*/
    , 1);

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
        //Debug.Log("TOUCH");
        //if (other.tag == "Enemy")
        //{
        //    isTouching = true;
        //    objectHit = other.gameObject;
        //}
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.transform.root.localScale.x < hitCloseness &&
            gameObject.transform.root.localScale.x > (hitCloseness - hitCloseness / 2) && other.tag == "Enemy")
        {
            other.GetComponent<NnormalEnemy>().ChickenDie();
            Destroy(gameObject);
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
