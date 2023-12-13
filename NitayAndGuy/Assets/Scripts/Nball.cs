using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nball : MonoBehaviour
{
    [SerializeField] float sizeSpeed=100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.root.localScale = new Vector3(gameObject.transform.localScale.x *(sizeSpeed-1)/sizeSpeed,gameObject.transform.localScale.y*(sizeSpeed - 1) / sizeSpeed, 1);
        if (gameObject.transform.root.localScale.x<0.02)
        {
            Destroy(gameObject);
        }
    }

}
