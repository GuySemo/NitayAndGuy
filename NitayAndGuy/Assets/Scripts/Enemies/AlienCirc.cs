using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienExp : MonoBehaviour
{
    [SerializeField] float speed=5;
    [SerializeField] float Radius = 50f;
    [SerializeField] float frequency = 0.1f;
    [SerializeField] Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3((-Radius*Mathf.Sin(frequency*Time.time))*frequency-transform.position.x,(Radius*Mathf.Cos(frequency*Time.time))*frequency-transform.position.y,0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            speed = speed * (-1);
        }
    }
}