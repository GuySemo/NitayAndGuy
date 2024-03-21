using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportAlien : MonoBehaviour
{
    [SerializeField] float tpCd=3;
    float thistime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thistime+tpCd<Time.time)
        {
            transform.position = new Vector3(Random.Range(-9, 9), Random.Range(-5, 5), 0);
            thistime = Time.time;
        }
    }
}
