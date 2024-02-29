using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingChick : MonoBehaviour
{
    Animator anim;
    bool awake = false;
    float seconds = 0;
    [SerializeField] GameObject ChickenObject;

    [SerializeField] GameObject LevelSpawners;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (awake)
        {
            if (Time.time - seconds > 2.5f)
            {
                LevelSpawners.SetActive(true);
                GameObject Chicken1 = Instantiate(ChickenObject, transform.position, Quaternion.identity) as GameObject;
                Chicken1.layer = gameObject.layer;
                Chicken1.transform.localScale = gameObject.transform.localScale;
                Destroy(gameObject);

            }
        }
    }
    public void Awaken()
    {
        transform.position = transform.position + new Vector3(0, 0.4f, 0);
        anim.SetBool("awake", true);
        awake = true;
        seconds = Time.time;
    }
}
