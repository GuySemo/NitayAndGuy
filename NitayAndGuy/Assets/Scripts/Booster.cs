using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public int pos = 1;
    public int jump = 2;
    [SerializeField] GameObject WalkingMonkey;
    bool isPurple = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && Random.Range(0, 11) > 6)
        {

            isPurple = other.GetComponent<NormalMonkey>().isPurple;
            Destroy(other.gameObject);
            GameObject wMonkey = Instantiate(WalkingMonkey, transform.position, Quaternion.identity) as GameObject;
            wMonkey.GetComponent<WalkingMonkey>().isPurple = isPurple;
            wMonkey.GetComponent<WalkingMonkey>().speed *= pos;
            wMonkey.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
        }
    }
}
