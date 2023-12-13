using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NnormalEnemy : MonoBehaviour
{
    [SerializeField] float speed = 5;
    bool starter = true;
    float lasttime=0;
    int ChangeDirection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (starter)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
            starter = false;
        }
        if (Time.time>lasttime)
        {
            if (Random.Range(1,4)==3)
            {
                speed = Random.Range(5, 30) / 2.5f;
                ChangeDirection = Random.Range(0,2);
                if (ChangeDirection==0)
                {
                    ChangeDirection = -1;
                }
                GetComponent<Rigidbody2D>().velocity = new Vector3(ChangeDirection*speed,0,0);
            }
            lasttime = Time.time + 0.5f;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {

        }
        if (other.gameObject.tag == "Wall")
        {
           GetComponent<Rigidbody2D>().velocity = new Vector3(-speed*other.transform.position.x/Mathf.Abs(other.transform.position.x),0,0);
        }
    }

}
