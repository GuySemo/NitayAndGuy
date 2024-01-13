using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nonclick : MonoBehaviour
{
    [SerializeField] GameObject ball;
    public bool canThrow = true;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer > 4)
        {
            canThrow = true;
        }
        
    }
    private void OnMouseDown()
    {
        if (canThrow)
        {
            Instantiate(ball, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, -transform.position.z + ball.transform.position.z), Quaternion.identity);
        }
    }
}
