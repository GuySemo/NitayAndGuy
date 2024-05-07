using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class AlienBoss : MonoBehaviour
{
    float changeMovementCD=2;
    [SerializeField] float lastTime = 0;
    teleportAlien tp;
    [SerializeField] float speed = 5;
    [SerializeField] float frequency = 5;
    [SerializeField] float amplitood = 5;
    [SerializeField] float Radius = 50f;
    [SerializeField] float startingspeed = 5;
    [SerializeField] float xyRatio = 1;
    [SerializeField] GameObject endSlider;
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    [SerializeField] GameObject[] sliders;
    [SerializeField] int lastmode;
    float lifegoal;
    float startinglife;
    static public  bool maybeinvincible = false;
    GameObject slide;
    static public bool EndOfGame=false;
    public float colorTimer = -1;
    public bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        teleportAlien tp= GetComponent<teleportAlien>();
        startinglife = GetComponent<AlienScript>().life;
        lifegoal=startinglife;
        lifegoal = startinglife * 6 / 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            if (Time.time - colorTimer > 0.1)
            {
                hit = false;
                GetComponent<SpriteRenderer>().color = new Color(1, 1,1, 1);
            }
        }
        if (GetComponent<AlienScript>().life<lifegoal)
        {

            lifegoal = lifegoal - startinglife / 7;
            if (lifegoal <= startinglife / 7)
            {
                EndOfGame = true;
            }
            else
            {
                SummonSlider();
                maybeinvincible = true;
            }
            GetComponent<CapsuleCollider2D>().enabled = false;

        }
        if (EndOfGame&& !endSlider.activeSelf)
        {
            endSlider.SetActive(true);
            GetComponent<CapsuleCollider2D>().enabled = false;

        }
        if (Followline.counter==3)
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
            EndOfGame = false;
        }
        if (!maybeinvincible&& !GetComponent<CapsuleCollider2D>().enabled&& !EndOfGame)
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
        }
        rb = GetComponent<Rigidbody2D>();
        if (!maybeinvincible&& !EndOfGame)
        {
            switch (lastmode)
            {
                case 1:
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, amplitood * Mathf.Cos(Time.time * frequency));
                    break;
                case 2:
                    GetComponent<Rigidbody2D>().velocity = new Vector3((-Radius * Mathf.Sin(frequency * Time.time)) * frequency - speed, (Radius * Mathf.Cos(frequency * Time.time)) * frequency, 0);
                    break;
                default:
                    break;
            }
            if (changeMovementCD + lastTime < Time.time)
            {
                lastTime = Time.time;
                speed = Random.Range(4, 7);
                frequency = Random.Range(4, 7);
                amplitood = Random.Range(4, 6);
                lastmode = Random.Range(1, 3);
                Radius = Random.Range(2, 5);
                switch (Random.Range(1, 3))
                {
                    case 1:
                        GetComponent<teleportAlien>().enabled = true;
                        break;
                    case 2:
                        GetComponent<teleportAlien>().enabled = false;
                        break;

                    default:
                        break;
                }
            }
        }
        else
        {
            transform.position = new Vector3(6, 2.6f,0);
        }

    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            speed = speed * (-1);
        }
    }
    private void SummonSlider()
    {
        GameObject slide= Instantiate(sliders[Random.Range(0, sliders.Length)],new Vector3(0.5f,-3.8f,0), Quaternion.identity) as GameObject;
    
    }
    public void GetHit()
    {
        hit = true;
        colorTimer = Time.time;
        GetComponent<SpriteRenderer>().color = new Color(1, 0.4f, 0.4f, 1);
    }
}
