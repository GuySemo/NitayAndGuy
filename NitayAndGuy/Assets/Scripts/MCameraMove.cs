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

        //if (drag && Mathf.Abs((Origin - Difference).x - (Origin - Difference).y) < 20
        //    && (Origin - Difference).x > -10 && ((Origin - Difference).y > -10) &&
        //    ((Origin - Difference).x < distance && ((Origin - Difference).y < distance)))
        if(drag)
        {
            Camera.main.transform.position = Origin - Difference;
            currentPos = Camera.main.transform.position;
        }

        if (Input.GetMouseButton(1))
            Camera.main.transform.position = ResetCamera;

    }
}