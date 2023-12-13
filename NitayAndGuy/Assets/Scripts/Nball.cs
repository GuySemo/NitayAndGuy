using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nball : MonoBehaviour
{
    [SerializeField] float sizeSpeed=100;
    bool isTouching = false;
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
        if (gameObject.transform.root.localScale.x < 1 && isTouching)
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouching = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouching = false;
    }

}
