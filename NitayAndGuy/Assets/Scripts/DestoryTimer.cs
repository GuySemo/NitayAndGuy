using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTimer : MonoBehaviour
{
    public float destroyTime = 1.8f;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
