using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float shake= 0;
    float shakeAmount= 0.7f;
    float decreaseFactor = 1.0f;
 
     private void Update()
    {
        if (shake > 0)
        {
            transform.localPosition = (Random.insideUnitSphere + new Vector3(0,0,-10)) * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;

        }
        else
        {
            shake = 1.0f;
        }
    }
}
