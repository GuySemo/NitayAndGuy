using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public int pos = 1;
    public int jump = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector3(0, pos * jump, 0);
        }
    }
}
