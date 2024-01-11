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
        Debug.Log(MousePos);
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lazer = Instantiate(beam, (Camera.main.ScreenToWorldPoint(Input.mousePosition) + startingPoint.transform.position) / 2 + new Vector3(0, 0, -transform.position.z + beam.transform.position.z), Quaternion.identity) as GameObject;
    }
    private void OnMouseDrag()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dist= Camera.main.ScreenToWorldPoint(Input.mousePosition) - startingPoint.transform.position;
        lazer.transform.localScale = new Vector3(1, dist.magnitude,1);
        lazer.transform.position = (Camera.main.ScreenToWorldPoint(Input.mousePosition) + startingPoint.transform.position)/2;
        lazer.transform.eulerAngles = new Vector3(0, 0, 90+(180 / Mathf.PI) * Mathf.Atan2((Camera.main.ScreenToWorldPoint(Input.mousePosition).y - startingPoint.transform.position.y) , (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - startingPoint.transform.position.x)));
    }
    private void OnMouseUp()
    {
        Destroy(lazer);
    }
}

