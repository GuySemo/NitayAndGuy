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
    [SerializeField] public float myDamage = 20;
    //RandomSpin
    float spinDir;

    public static bool firstEgg = true;
    static bool started = false;
    static double seconds = 0;

    bool startBig = false;
    bool startBig2 = false;
    float bananaTimer = 99999999;

    public static float vel;
    void Start()
    {
        speedBan = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - FindObjectOfType<BananaOnClick>().savemouse);
        Nonclick.cooldown = 10f;
        seconds = 0;
        if (firstEgg)
        {
            firstEgg = false;
            seconds = Time.time;
        }
        FindObjectOfType<Timer>().started = true;
        spinDir = Random.Range(600, 1000);
        Destroy(gameObject, 5);
        GetComponent<Rigidbody2D>().velocity += new Vector2(speedBan.x,speedBan.y)/2;
    }

    // Update is called once per frame
    void Update()
    {
        vel = GetComponent<Rigidbody2D>().velocity.magnitude;
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
            Destroy(gameObject);
        }
      //      transform.localScale =
      //  new Vector3((gameObject.transform.localScale.x * (sizeSpeed - 1) / sizeSpeed)
      //, (gameObject.transform.localScale.y * (sizeSpeed - 1) / sizeSpeed)
      //  , 1);

    }
    private void OnTriggerStay2D(Collider2D other)
    {

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            isTouching = false;
        }
    }

}
