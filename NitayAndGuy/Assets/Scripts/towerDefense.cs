using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerDefense : MonoBehaviour
{
    int life;
    Vector2 startingSize;
    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        startingSize = gameObject.transform.GetChild(0).gameObject.transform.localScale;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Enemy")
        {
            Destroy(other.gameObject.transform.parent);
            life = life - 1;
        }
        gameObject.transform.GetChild(0).gameObject.transform.localScale =
        gameObject.transform.GetChild(0).gameObject.transform.localScale + new Vector3(-startingSize.x / 100,0,0);
        Debug.Log("hi");
    }
}
