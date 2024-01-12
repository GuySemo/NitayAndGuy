using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.VFX;

public class spawno : MonoBehaviour
{
    Coroutine spawner;
    [SerializeField] int  mySortingLayer = 3;
    [SerializeField] float sizeMultiplier = 1;
    [SerializeField] float speedMultiplier = 1;
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
            //Create New Chicken
            GameObject instance = Instantiate(chickens[Random.Range(0,chickens.Length)],transform.position,Quaternion.identity)
                as GameObject;
            instance.GetComponent<NnormalEnemy>().speed = instance.GetComponent<NnormalEnemy>().speed * speedMultiplier;
            instance.transform.localScale = instance.transform.localScale * sizeMultiplier;
            instance.GetComponent<SpriteRenderer>().sortingOrder = mySortingLayer;
            instance.layer = gameObject.layer;
            //
            yield return new WaitForSeconds(delay);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
