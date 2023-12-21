using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nball : MonoBehaviour
{
    [SerializeField] float sizeSpeed= 100;
    public bool isTouching = false;
    GameObject objectHit;
    [SerializeField] GameObject boomEffect;

    //hit closeness
    [SerializeField] float hitCloseness = 0.5f;

    //RandomSpin
    float spinDir;
    // Start is called before the first frame update
    void Start()
    {
        spinDir = Random.Range(-720, 720);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinDir * Time.deltaTime);
        //Destroy When Too Small
        if (gameObject.transform.root.localScale.x<0.10)
        {
            GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
        else
        {
            //Smallning
            gameObject.transform.root.localScale =
                new Vector3(gameObject.transform.localScale.x * (sizeSpeed - 1) / sizeSpeed
                , gameObject.transform.localScale.y * (sizeSpeed - 1) / sizeSpeed, 1);

        }

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
        Debug.Log("TOUCH");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided");
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
            Instantiate(boomEffect,  other.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(other.gameObject);
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
