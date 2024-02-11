using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : MonoBehaviour
{
    [SerializeField] GameObject Boom;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChickenDie()
    {
        GameObject oBoom = Instantiate(Boom, transform.position, Quaternion.identity) as GameObject;
        oBoom.transform.localScale = new Vector3(6,6,1) + transform.localScale ;
        Destroy(gameObject);
    }
    
}
