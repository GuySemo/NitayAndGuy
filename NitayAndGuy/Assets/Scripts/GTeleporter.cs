using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTeleporter : MonoBehaviour
{

    [SerializeField] Vector3 teleportPos;
    [SerializeField] Vector3 teleportPos2 = new Vector3(0,0,0);
    [SerializeField] float moveX = 0;
    [SerializeField] float moveY = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Random.Range(0,2) == 0)
            {
                other.transform.position = teleportPos + new Vector3(Random.Range(-moveX,moveX), Random.Range(-moveY, moveY), 0);
            }
            else
            {
                other.transform.position = teleportPos2 + new Vector3(Random.Range(-moveX, moveX), Random.Range(-moveY, moveY), 0);
            }
        }
    }
}
