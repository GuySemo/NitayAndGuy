using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BananaOnClick : MonoBehaviour
{
    [SerializeField] GameObject ball;
    public bool canThrow = false;
    bool canthrowCD;
    public Vector3 savemouse;
    static public float cooldown = 1f;
    float lastthrow;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }
    GameObject boomerang;
    // Update is called once per frame
    void Update()
    {
        if ((!canThrow) && (Time.time - timer > 4) && (Time.time > lastthrow + cooldown))
        {
            canThrow = true;
        }
        //if (!canthrowCD&&(Time.time>lastthrow+cooldown))
        //{
        //    canthrowCD = true;
        //}

    }
    private void OnMouseUp()
    {
        if (canThrow)
        {
            lastthrow = Time.time;
            canThrow = false;
        }
    }
    private void OnMouseDown()
    {
        boomerang=Instantiate(ball, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, -transform.position.z + ball.transform.position.z), Quaternion.identity) as GameObject;
        savemouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDrag()
    {
         boomerang.GetComponent<Rigidbody2D>().velocity=(Camera.main.ScreenToWorldPoint(Input.mousePosition) - FindObjectOfType<BananaOnClick>().savemouse);

    }
    public void upgradeSpeed()
    {

    }
}
