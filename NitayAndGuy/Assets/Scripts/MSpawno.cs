using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.VFX;

public class MSpawno : MonoBehaviour
{
    Coroutine spawner;
    [SerializeField] int  mySortingLayer = 3;
    [SerializeField] float sizeMultiplier = 1;
    [SerializeField] float speedMultiplier = 1;
    [SerializeField] float delay;
    [SerializeField] bool toFlipX = false;
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
            instance.GetComponent<NormalMonkey>().speed = instance.GetComponent<NormalMonkey>().speed * speedMultiplier;
            instance.GetComponent<SpriteRenderer>().flipX = toFlipX;
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
    public void reduceDelay(float precent)
    {
        delay = delay / precent;
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.GetComponent<MSpawno>().delay = child.GetComponent<MSpawno>().delay / precent;
        }
    }
}
