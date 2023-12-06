using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.root.localScale = new Vector3(gameObject.transform.localScale.x *99/100,gameObject.transform.localScale.y* 99/100, 1);
        if (gameObject.transform.root.localScale.x<0.02)
        {
            Destroy(gameObject);
        }
    }

}
