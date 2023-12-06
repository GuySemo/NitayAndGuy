using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nonclick : MonoBehaviour
{
    [SerializeField] GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnMouseDown()
    {
        Instantiate(ball,Camera.main.ScreenToWorldPoint(Input.mousePosition)+new Vector3(0,0,11),Quaternion.identity);
    }
}
