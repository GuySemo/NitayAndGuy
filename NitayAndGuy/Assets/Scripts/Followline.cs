using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Followline : MonoBehaviour
{
    [SerializeField] GameObject[] corners;
    Vector3 direction= new Vector3(-0.5f,0,0);
    [SerializeField] float movespeed;
    int cornerIndex=0;
    public static int counter=0;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        direction = corners[cornerIndex].transform.position - transform.position;

        if (Mathf.Abs(direction.magnitude)<movespeed)
        {
            transform.position = corners[cornerIndex].transform.position;
            cornerIndex++;
            if (cornerIndex>=corners.Length)
            {
                cornerIndex = 0;
                AlienBoss.maybeinvincible=false;
                if (AlienBoss.EndOfGame)
                {
                    counter++;
                }
                Destroy(gameObject.transform.parent.gameObject);
                
            }

        }

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Laser")
    //    {
    //        transform.position = transform.position + direction.normalized*(movespeed);
    //    }
    //    if (collision.gameObject.tag == "LowEnergyLazer")
    //    {
    //        transform.position = transform.position + direction.normalized*movespeed/2.5f;
    //    }
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Laser")
        {
            transform.position = transform.position + direction.normalized*(movespeed);
        }
        if (collision.gameObject.tag == "LowEnergyLazer")
        {
            transform.position = transform.position + direction.normalized*movespeed / 2.5f;
        }
    }

}