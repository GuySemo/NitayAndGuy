using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopOpen : MonoBehaviour
{
    [SerializeField] GameObject ShopCanvas;
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
        ShopCanvas.SetActive(true);
    }
}
