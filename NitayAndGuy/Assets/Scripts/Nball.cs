using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nball : MonoBehaviour
{
    [SerializeField] float sizeSpeed=100;
    public bool isTouching = false;
    GameObject temp;
    [SerializeField] GameObject boomEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Smallning
        gameObject.transform.root.localScale = 
            new Vector3( gameObject.transform.localScale.x *(sizeSpeed-1)/sizeSpeed
            ,  gameObject.transform.localScale.y*(sizeSpeed - 1) / sizeSpeed, 1);

        //Destroy When Too Small
        if (gameObject.transform.root.localScale.x<0.02)
        {
            Destroy(gameObject);
        }

        //Hit Enemy
        if (gameObject.transform.root.localScale.x <0.5f && isTouching)
        {
            Debug.Log("Hit");
            Instantiate(boomEffect, temp.transform.position, Quaternion.Euler(90,0,0));
            Destroy(temp);
            Destroy(gameObject);
        }
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
        if (other.tag == "Enemy")
        {
            isTouching = true;
            temp = other.gameObject;
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
