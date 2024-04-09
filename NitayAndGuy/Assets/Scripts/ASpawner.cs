using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASpawner : MonoBehaviour
{
    Coroutine spawner;
    [SerializeField] float StartDelay = 4f;
    bool spawned = false;

    [SerializeField] float offsetXPos = 0;
    [SerializeField] float offsetXNeg = 0;
    [SerializeField] int mySortingLayer = 3;
    [SerializeField] float sizeMultiplier = 1;
    [SerializeField] float delay;
    [SerializeField] bool toFlipX = false;
    [SerializeField] GameObject[] aliens;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (!spawned && Time.timeSinceLevelLoad > StartDelay)
        {
            spawner = StartCoroutine(Spawn());
            spawned = true;
        }
    }
    IEnumerator Spawn()
    {
        while (AlienScript.limit>AlienScript.AliensInScene)
        {
            //Create New Chicken
            GameObject instance = Instantiate(aliens[Random.Range(0, aliens.Length)], transform.position, Quaternion.identity)
                as GameObject;
            instance.transform.position = instance.transform.position + new Vector3(Random.Range(offsetXNeg, offsetXPos), 0, 0);
            instance.GetComponent<SpriteRenderer>().flipX = toFlipX;
            instance.transform.localScale = instance.transform.localScale * sizeMultiplier;
            instance.GetComponent<SpriteRenderer>().sortingOrder = mySortingLayer;
            instance.layer = gameObject.layer;
            //
            yield return new WaitForSeconds(delay);
        }

    }

}

