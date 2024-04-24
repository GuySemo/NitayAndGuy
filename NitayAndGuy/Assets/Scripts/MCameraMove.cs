using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCameraMove : MonoBehaviour
{
    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;

    private bool drag = false;
    [SerializeField] public int distance;

    static Vector3 currentPos = new Vector3(0,0,-10);
    public bool canMove = true;
    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
        Camera.main.transform.position = currentPos;
    }


    private void LateUpdate()
    {
        if (Input.GetMouseButton(0) && canMove)
        {
            if (true)
            {
                Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            }
            if (drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            Camera.main.transform.position = Origin - Difference  ;
            currentPos = Camera.main.transform.position;
        }
        if ( transform.position.x < -23)
        {
            transform.position = new Vector3(-23, transform.position.y, -10);
        }
        if (transform.position.x > 120)
        {
            transform.position = new Vector3(120, transform.position.y, -10);
        }
        if (transform.position.y < -18)
        {
            transform.position = new Vector3(transform.position.x, -18 , -10);
        }
        if (transform.position.y > 130)
        {
            transform.position = new Vector3(transform.position.x, 130, -10);
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            gameObject.GetComponent<Camera>().orthographicSize +=-3*Input.GetAxis("Mouse ScrollWheel");
        }   
        //if (Input.GetMouseButton(1))
        //    Camera.main.transform.position = ResetCamera;

    }
}