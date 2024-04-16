using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class sinAlien : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float frequency=5;
    [SerializeField] float amplitood=5;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(3, 7);
        frequency = Random.Range(3, 7);
        amplitood = Random.Range(3, 6);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, amplitood*Mathf.Cos(Time.time * frequency));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Wall")
        {
            speed = speed * (-1);
        }
    }
}
