using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDalien : MonoBehaviour
{
    [SerializeField] int BallSpeed = 7;
    [SerializeField] float startingspeed=5;
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    public bool startofgame;
    float launchx;
    float launchy;
    // Start is called before the first frame update
    void Start()
    {
        startofgame = true;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(startingspeed * (-1), startingspeed * (-1), 0);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, coll.GetContact(0).normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

}   
