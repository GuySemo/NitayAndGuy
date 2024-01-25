using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equip : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    static public GameObject equipped;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void weapon(int index)
    {
        equipped= weapons[index];
    }

}
