using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class spawno : MonoBehaviour
{
    Coroutine spawner;
    [SerializeField] float delay;
    [SerializeField] GameObject[] chickens;

    // Start is called before the first frame update
    void Start()
    {
        spawner = StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject instance = Instantiate(chickens[Random.Range(0,chickens.Length)],transform.position,Quaternion.identity)
                as GameObject;
            //instance.GetComponent<NnormalEnemy>().speed = 5;
            yield return new WaitForSeconds(delay);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
