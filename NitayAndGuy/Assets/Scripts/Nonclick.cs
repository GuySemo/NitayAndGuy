using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Nonclick : MonoBehaviour
{
    [SerializeField] GameObject ball;
    public bool canThrow = true;
   static public float cooldown= 0.3f;
    float lastthrow;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!canThrow)&&(Time.time - timer > 4))
        {
            if ((Time.time > lastthrow + cooldown))
            {
                canThrow = true;
            }
        }
        //if (!canthrowCD&&(Time.time>lastthrow+cooldown))
        //{
        //    canthrowCD = true;
        //}
        
    }
    private void OnMouseDown()
    {
        if (canThrow && levelLoader.canThrow)
        {
            Instantiate(ball, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, -transform.position.z + ball.transform.position.z), Quaternion.identity);
            lastthrow = Time.time;
            canThrow = false;
        }
    }
    public void upgradeSpeed()
    {

    }
}
