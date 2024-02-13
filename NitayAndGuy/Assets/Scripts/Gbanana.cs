using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gbanana : MonoBehaviour
{
    public float sizeSpeed= 4;
    public bool isTouching = false;
    Vector3 speedBan;// speed of banana
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

    bool startBig = false;
    bool startBig2 = false;
    float bananaTimer = 99999999;

    
    void Start()
    {
        speedBan = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - FindObjectOfType<BananaOnClick>().savemouse);
        Nonclick.cooldown = 10f;
        seconds = 0;
        Debug.Log(sizeSpeed);
        if (firstEgg)
        {
            firstEgg = false;
            seconds = Time.time;
            if (SceneManager.GetActiveScene().buildIndex == 1 
                || SceneManager.GetActiveScene().buildIndex == 2
                || SceneManager.GetActiveScene().buildIndex == 3)
            {
                FindObjectOfType<SleepingChick>().Awaken();
            }
            FindObjectOfType<Timer>().started = true;

        }
        spinDir = Random.Range(600, 1000);
        Destroy(gameObject, 5);
        GetComponent<Rigidbody2D>().velocity += new Vector2(speedBan.x,speedBan.y)/2;
    }

    // Update is called once per frame
    void Update()
    {
        //Spinning
        transform.Rotate(0, 0, spinDir * Time.deltaTime);

        //Destroy When Too Small
        //if (gameObject.transform.root.localScale.x< hitCloseness / 2 && GetComponent<SpriteRenderer>().sortingOrder != -1)
        //{
        //    GetComponent<SpriteRenderer>().sortingOrder = -1;
        //}

        //Smallning
        if (transform.localScale.x > 0.2f && !startBig)
        {
            transform.localScale -= new Vector3((sizeSpeed * transform.localScale.x * Time.deltaTime)
                , (sizeSpeed* transform.localScale.x * Time.deltaTime), 0);
        }
        else
        {
            if (!startBig)
            {
                bananaTimer = Time.time;
                GetComponent<Rigidbody2D>().gravityScale = -0.35f;
                startBig = true;
            }
            if (Time.time - bananaTimer >1)
            {
                if (!startBig2)
                {
                    GetComponent<Rigidbody2D>().gravityScale = GetComponent<Rigidbody2D>().gravityScale * (-1);
                    startBig2 = true;
                }
               transform.localScale += new Vector3((2* sizeSpeed * Time.deltaTime)
                , (2 * sizeSpeed * Time.deltaTime), 0);
                GetComponent<Rigidbody2D>().velocity -= new Vector2(speedBan.x, speedBan.y);

            }

        }
        if (startBig && transform.localScale.x > 5f)
        {
            Nonclick.cooldown = 0f;
            Destroy(gameObject);
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
