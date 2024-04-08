using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MilkGun : MonoBehaviour
{
    [SerializeField] GameObject beam;
    [SerializeField] GameObject lowEnergyBeam;
    [SerializeField] GameObject startingPoint;
    GameObject lazer;
    GameObject lowEnergyLazer;
    Vector3 MousePos;
    [SerializeField] public static float  timeOfUse;
    float timeOfstartUse;
    bool charge=true;
    public float chargespeed=  1.8f;
    public static float maxCharge=5;
    bool lowMode;
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
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lazer = Instantiate(beam, (Camera.main.ScreenToWorldPoint(Input.mousePosition) + startingPoint.transform.position) / 2 + new Vector3(0, 0,5 -transform.position.z + beam.transform.position.z), Quaternion.identity) as GameObject;
    }
    private void OnMouseDrag()
    {
        if (timeOfUse>0&& !lowMode)
        {
            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dist = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startingPoint.transform.position;
            lazer.transform.localScale = new Vector3((timeOfUse)/3, dist.magnitude / 2, 1);
            lazer.transform.position = (Camera.main.ScreenToWorldPoint(Input.mousePosition) + startingPoint.transform.position) / 2 + new Vector3(0, 0, 5);
            lazer.transform.eulerAngles = new Vector3(0, 0, 90 + (180 / Mathf.PI) * Mathf.Atan2((Camera.main.ScreenToWorldPoint(Input.mousePosition).y - startingPoint.transform.position.y), (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - startingPoint.transform.position.x)));

            timeOfUse = timeOfUse - Time.deltaTime;
        }
        else
        {
            if (!lowMode)
            {
                lowEnergyLazer = Instantiate(lowEnergyBeam, (Camera.main.ScreenToWorldPoint(Input.mousePosition) + startingPoint.transform.position) / 2 + new Vector3(0, 0, 5 - transform.position.z + beam.transform.position.z), Quaternion.identity) as GameObject;
                lowMode = true;
            }
            timeOfUse = 0;
            if (lazer!=null)
            {
                Destroy(lazer);
                timeOfUse = timeOfUse + Time.deltaTime * chargespeed/5;
            }
            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dist = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startingPoint.transform.position;
            lowEnergyLazer.transform.localScale = new Vector3(0.5f, dist.magnitude / 2, 1);
            lowEnergyLazer.transform.position = (Camera.main.ScreenToWorldPoint(Input.mousePosition) + startingPoint.transform.position) / 2 + new Vector3(0, 0, 5);
            lowEnergyLazer.transform.eulerAngles = new Vector3(0, 0, 90 + (180 / Mathf.PI) * Mathf.Atan2((Camera.main.ScreenToWorldPoint(Input.mousePosition).y - startingPoint.transform.position.y), (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - startingPoint.transform.position.x)));

        }

    }
    private void OnMouseUp()
    {
        charge = true;  
        if (lazer!=null)
        {
            Destroy(lazer);
        }
        if (lowEnergyLazer!=null)
        {
            Destroy(lowEnergyLazer);
        }
        lowMode=false;
    }
}

