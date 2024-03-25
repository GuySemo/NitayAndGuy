using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MilkGun : MonoBehaviour
{
    [SerializeField] GameObject beam;
    [SerializeField] GameObject startingPoint;
    GameObject lazer;
    Vector3 MousePos;
    [SerializeField] public static float  timeOfUse;
    float timeOfstartUse;
    float chargetime;
    bool charge=true;
    public float chargespeed=1.8f;
    public static float maxCharge=7;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (charge && timeOfUse<maxCharge)
        {
            timeOfUse=timeOfUse+Time.deltaTime*chargespeed;
        }
    }
    private void OnMouseDown()
    {
        charge = false;
        timeOfstartUse = Time.time;
        Debug.Log(MousePos);
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lazer = Instantiate(beam, (Camera.main.ScreenToWorldPoint(Input.mousePosition) + startingPoint.transform.position) / 2 + new Vector3(0, 0,5 -transform.position.z + beam.transform.position.z), Quaternion.identity) as GameObject;
    }
    private void OnMouseDrag()
    {
        if (Time.time-timeOfstartUse<timeOfUse)
        {
            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dist = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startingPoint.transform.position;
            lazer.transform.localScale = new Vector3((timeOfstartUse + timeOfUse-Time.time)/3, dist.magnitude / 2, 1);
            lazer.transform.position = (Camera.main.ScreenToWorldPoint(Input.mousePosition) + startingPoint.transform.position) / 2 + new Vector3(0, 0, 5);
            lazer.transform.eulerAngles = new Vector3(0, 0, 90 + (180 / Mathf.PI) * Mathf.Atan2((Camera.main.ScreenToWorldPoint(Input.mousePosition).y - startingPoint.transform.position.y), (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - startingPoint.transform.position.x)));
        }
        else
        {
            timeOfUse = 0;
            Destroy(lazer);
        }

    }
    private void OnMouseUp()
    {
        charge = true;  
        chargetime = 0;
        if (lazer!=null)
        {
            timeOfUse = timeOfUse+timeOfstartUse-Time.time;
            Destroy(lazer);
        }
    }
}

