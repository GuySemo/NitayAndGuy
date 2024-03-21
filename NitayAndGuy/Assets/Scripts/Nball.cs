using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nball : MonoBehaviour
{
    public static float sizeSpeed= 4;
    public bool isTouching = false;
    GameObject objectHit;
    [SerializeField] GameObject boomEffect;
    [SerializeField] GameObject boom2Effect;

    //hit closeness
    [SerializeField] float hitCloseness = 0.5f;

    [SerializeField] GameObject crackedEgg;
    [SerializeField] public float myDamage = 1;
    //RandomSpin
    float spinDir;

    public static bool firstEgg = true;
    static bool started = false;
    static double seconds = 0;
    void Start()
    {
        seconds = 0;
        if (firstEgg)
        {
            firstEgg = false;
            seconds = Time.time;
            if (true)
            {
                FindObjectOfType<SleepingChick>().Awaken();
            }
            FindObjectOfType<Timer>().started = true;

        }
        spinDir = Random.Range(-720, 720);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //Spinning
        transform.Rotate(0, 0, spinDir * Time.deltaTime);

        //Destroy When Too Small
        if (gameObject.transform.root.localScale.x< hitCloseness / 2 && GetComponent<SpriteRenderer>().sortingOrder != -1)
        {
            GetComponent<SpriteRenderer>().sortingOrder = -1;
        }

        //Smallning
        if (transform.localScale.x > 0.0001f)
        {
            transform.localScale -= new Vector3((sizeSpeed *  transform.localScale.x * Time.deltaTime)
                , (sizeSpeed* transform.localScale.x * Time.deltaTime), 0);

        }
      //      transform.localScale =
      //  new Vector3((gameObject.transform.localScale.x * (sizeSpeed - 1) / sizeSpeed)
      //, (gameObject.transform.localScale.y * (sizeSpeed - 1) / sizeSpeed)
      //  , 1);

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "BreakEgg")
        {
            if (gameObject.transform.root.localScale.x < other.GetComponent<WallsBreakEgg>().eggSize &&
                gameObject.transform.root.localScale.x > other.GetComponent<WallsBreakEgg>().eggSize /2)
            {
                float crackedSize = other.GetComponent<WallsBreakEgg>().crackedSize;
                GameObject oCracked = Instantiate(crackedEgg, transform.position, Quaternion.identity) as GameObject;
                oCracked.transform.localScale = new Vector3(crackedSize, crackedSize, crackedSize);
                oCracked.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = other.GetComponent<WallsBreakEgg>().sortingLayer;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            isTouching = false;
        }
    }

}
