using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTeleporter : MonoBehaviour
{
    float delay = -1;
    public bool canTp = true;
    [SerializeField]  GameObject teleportPos;
    // Start is called before the first frame update
    void Start()
    {
        delay = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!canTp)
        //{
        //    if (Time.time - delay > 0.4f)
        //    {
        //        delay = Time.time;
        //        canTp = true;
        //    }
        //}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log( canTp);
        if (other.gameObject.layer == gameObject.layer - 3)
        {
            other.transform.position = teleportPos.transform.position;
            //canTp = false;
            //delay = Time.time;
        }
    }
}
