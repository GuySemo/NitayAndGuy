using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationConst : MonoBehaviour
{
    float spinDir = 0;
    [SerializeField] int minR;
    [SerializeField] int maxR;
    // Start is called before the first frame update
    void Start()
    {
        while (spinDir == 0)
        {
            spinDir = Random.Range(minR, maxR);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinDir * Time.deltaTime);
    }
}
