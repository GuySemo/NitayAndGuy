using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.VFX;

public class MSpawno : MonoBehaviour
{
    Coroutine spawner;
    [SerializeField] float StartDelay = 4f;
    bool spawned = false;

    [SerializeField] float offsetXPos = 0;
    [SerializeField] float offsetXNeg = 0;
    [SerializeField] int  mySortingLayer = 3;
    [SerializeField] float sizeMultiplier = 1;
    [SerializeField] float speedMultiplier = 1;
    [SerializeField] float delay;
    [SerializeField] bool toFlipX = false;
    [SerializeField] GameObject[] monkeys;

    public bool isWalking = false;
    public bool isHung = false;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (!spawned && Time.timeSinceLevelLoad > StartDelay )
        {
            spawner = StartCoroutine(Spawn());
            spawned = true;
        }
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            //Create New Chicken
            GameObject instance = Instantiate(monkeys[Random.Range(0,monkeys.Length)],transform.position,Quaternion.identity)
                as GameObject;
            if (isWalking == false)
            {
            instance.GetComponent<NormalMonkey>().speed = instance.GetComponent<NormalMonkey>().speed * speedMultiplier;
            }
            else
            {
                if (isHung)
                {
                    instance.transform.position = instance.transform.position + new Vector3(Random.Range(offsetXNeg, offsetXPos), 0, 0);
                    instance = (instance.transform.GetChild(0).gameObject);
                    instance .GetComponent<WalkingMonkey>().speed = instance.GetComponent<WalkingMonkey>().speed * speedMultiplier;
                }
                else
                {
                    instance.GetComponent<WalkingMonkey>().speed = instance.GetComponent<WalkingMonkey>().speed * speedMultiplier;
                }
            }
            instance.transform.position = instance.transform.position + new Vector3( Random.Range(offsetXNeg, offsetXPos),0,0);
            instance.GetComponent<SpriteRenderer>().flipX = toFlipX;
            instance.transform.localScale = instance.transform.localScale * sizeMultiplier;
            instance.GetComponent<SpriteRenderer>().sortingOrder = mySortingLayer;
            instance.layer = gameObject.layer;
            //
            yield return new WaitForSeconds(delay);
        }

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
