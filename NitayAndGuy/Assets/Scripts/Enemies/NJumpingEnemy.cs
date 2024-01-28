using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NJumpingEnemy : MonoBehaviour
{
    [SerializeField] float jump = 5;
    float lasttime = 0;
    int ChangeDirection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lasttime)
        {
            if (Random.Range(3, 4) == 3)
            {
                jump = Random.Range(10, 20) / 2f;
                ChangeDirection = Random.Range(0, 2);
                if (ChangeDirection == 0)
                {
                    ChangeDirection = -1;
                }
                //GetComponent<Rigidbody2D>().velocity = new Vector3(ChangeDirection * GetComponent<NnormalEnemy>().speed, 0, 0);
                GetComponent<Rigidbody2D>().velocity += new Vector2(0, jump);
            }
            lasttime = Time.time + 2.5f;

        }
    }
}
