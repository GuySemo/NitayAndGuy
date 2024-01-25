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
        Instantiate(Boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
