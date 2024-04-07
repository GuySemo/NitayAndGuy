using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class AlienBoss : MonoBehaviour
{
    float changeMovementCD=2;
    [SerializeField] float lastTime = 0;
    sinAlien sin;
    DVDalien DVD;
    teleportAlien tp;
    AlienCirc slalum; 
    [SerializeField] float speed = 5;
    [SerializeField] float frequency = 5;
    [SerializeField] float amplitood = 5;
    [SerializeField] float Radius = 50f;
    [SerializeField] float startingspeed = 5;
    [SerializeField] float xyRatio = 1;
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    [SerializeField] int lastmode;
    // Start is called before the first frame update
    void Start()
    {
        sinAlien sin = GetComponent<sinAlien>();
        DVDalien DVD = GetComponent<DVDalien>();
        teleportAlien tp= GetComponent<teleportAlien>();
        AlienCirc slalum= GetComponent<AlienCirc>();


    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (changeMovementCD+lastTime<Time.time)
        {
            lastTime = Time.time;
            speed = Random.Range(4, 7);
            frequency = Random.Range(4, 7);
            amplitood = Random.Range(4, 6);
            lastmode = Random.Range(1, 3);
            Radius = Random.Range(2, 5);
            switch (Random.Range(1,3))
            {
                case 1:
                    GetComponent<teleportAlien>().enabled = true;
                    break;
                case 2:
                    GetComponent<teleportAlien>().enabled= false;
                    break;

                default:
                    break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            speed = speed * (-1);
        }
    }
}
