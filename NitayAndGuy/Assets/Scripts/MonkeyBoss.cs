using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyBoss : MonoBehaviour
{
    float phaseTimer = 0;
    [SerializeField] GameObject[] kingMonkeys;
    bool allNull = false;
    GameObject monkeyTemp;
    bool canBeForm = false;
    bool lilKingAlive = false;

    bool onScreen = true;
    [SerializeField] float hittableTime = 7;
    bool hitEnough = false;
    int i = 0;

    float kingMaxHealth;
    float prec;
    [SerializeField] GameObject Smoke;
    // Start is called before the first frame update
    void Start()
    {
        kingMaxHealth = GetComponent<WalkingMonkey>().life;
        prec = (float)((float)(kingMonkeys.Length) / (float)(kingMonkeys.Length + 1f));

        monkeyTemp = kingMonkeys[0];
        phaseTimer = Time.time;
        for (int i = 0; i < kingMonkeys.Length; i++)
        {
            kingMonkeys[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Monkey Forming To Lil One
        if (canBeForm)
        {
            Debug.Log("Forming");

            allNull = IsNull(kingMonkeys);
            i = Random.Range(0, kingMonkeys.Length);
            while (kingMonkeys[i] == null && !allNull)
            {
                i = Random.Range(0, kingMonkeys.Length);
            }
            if (!allNull)
            {
                kingMonkeys[i].SetActive(true);
                monkeyTemp = kingMonkeys[i];
                lilKingAlive = true;
                canBeForm = false;

                phaseTimer = Time.time;
            }

        }
        //Lil One Dies
        if (monkeyTemp == null && lilKingAlive)
        {
            if (!onScreen)
            {
                //Put monkeyOn screen
                transform.position = new Vector3(0, 0, 0);
                Instantiate(Smoke, transform.position, Quaternion.identity);
            }
            lilKingAlive = false;
            onScreen = true;
            phaseTimer = Time.time;

        }
        if (onScreen)
        {
            if (kingMaxHealth * prec >= GetComponent<WalkingMonkey>().life)
            {
                hitEnough = true;
                prec = prec - (1f / (float)kingMonkeys.Length);
            }
            //Debug.Log("ON SCREEN");
        }
        //Time on screen ends
        if ((onScreen && Time.time - phaseTimer > hittableTime) || hitEnough)
        {
            //Create smoke
            Instantiate(Smoke, transform.position, Quaternion.identity);
            phaseTimer = Time.time;
            onScreen = false;
            canBeForm = true;
            hitEnough = false;
            //Put monkey Off screen
            transform.position = new Vector3(50, 0, 0);
        }
    }
    public bool IsNull(GameObject[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null)
            {
                return false;
            }
        }
        return true;
    }
}
