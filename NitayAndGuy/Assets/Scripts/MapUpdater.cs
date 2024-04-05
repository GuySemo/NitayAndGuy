using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MapUpdater : MonoBehaviour
{
    public static bool level1 = false;
    public static bool level2 = false;
    public static bool level3 = false;
    public static bool level4 = false;
    public static bool level5 = false;
    public static bool level6 = false;
    public static bool level7 = false;
    public static bool level8 = false;
    public static bool level9 = false;
    public static bool level10 = false;
    public static bool level11 = false;
    public static bool level12 = false;

    public static bool[] levelsCleared = { level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11
    };

    [SerializeField] GameObject levels;
    int levelCount;
    Transform[] levelButtons;

    //Cutscene shi
     Camera oCamera;
    [SerializeField] Transform Fog;
    static bool destoryFog = false;
    static bool w2cutActive = false;
    float cutsceneTimer;
    [SerializeField] GameObject world2Cutscene;
    //Kodan
    int kodan=0;
    //FreePlay
    public static bool freePlay = false;
    void Start()
    {
        if (destoryFog)
        {
            Destroy(Fog.gameObject);
        }
        //
        oCamera = Camera.main;

        levelCount = levels.transform.childCount;
        levelButtons = new Transform[levelCount];

        //Fill level Buttons array
        for (int j = 0; j < levelButtons.Length; j++)
        {
            levelButtons[j] = levels.gameObject.transform.GetChild(j);
        }
        //Set Active Flags 
        for (int i = 0; i < levelsCleared.Length; i++)
        {
            //Flags
            levelButtons[i].transform.GetChild(0).gameObject.SetActive(levelsCleared[i]);
            //Button Clickable
            levelButtons[i + 1].GetComponent<Clickables>().canClick = levelsCleared[i];
            if (freePlay)
            {
                levelButtons[i + 1].GetComponent<Clickables>().canClick = true;
            }
            levelButtons[i + 1].GetComponent<Clickables>().ReColor();
        }
    }
    private void Update()
    {
        switch (kodan)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    kodan++;
                }
                else
                {
                    if (Input.anyKeyDown)
                    {
                        kodan = 0;
                    }
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.K))
                {
                    kodan++;
                }
                else
                {
                    if (Input.anyKeyDown)
                    {
                        kodan=0;
                    }
                }

                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.I))
                {
                    kodan++;
                }
                else
                {
                    if (Input.anyKeyDown)
                    {
                       kodan = 0;
                    }
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    UnlockAll();
                }
                else
                {
                    if (Input.anyKeyDown)
                    {
                        kodan = 0;
                    }
                    
                }
                break;

            default:
                break;
        }

        //World 1 to 2 Cutscene
        if (w2cutActive)
        {
            if (Time.time - cutsceneTimer > 6)
            {
                oCamera.GetComponent<Camera>().orthographicSize = 7;
                FindObjectOfType<MCameraMove>().canMove = true;
            }
            if (Time.time - cutsceneTimer > 8)
            {
                Debug.Log("Hi there");
                w2cutActive = false;
                Destroy(Fog.gameObject);
                destoryFog = true;
                //Activate 2nd Menash
                DialogText.dialogsActive[5] = true;
                world2Cutscene.SetActive(true);
                oCamera.transform.localPosition = new Vector3(oCamera.transform.localPosition.x,
     oCamera.transform.localPosition.y, -10);
            }
        }
    }
    public void UnlockAll()
    {
        //Button Clickable
        for (int i = 0; i < levelsCleared.Length; i++)
        {
            //Button Clickable
            levelButtons[i + 1].GetComponent<Clickables>().canClick = true;
            levelButtons[i + 1].GetComponent<Clickables>().ReColor();
        }
        Coins.coins = 1000000;
    } //DEV MODE

    public void W2Cutscene()
    {
        w2cutActive = true;
        cutsceneTimer = Time.time;

        //Camera Can't move
        FindObjectOfType<MCameraMove>().canMove = false;

        //Change Camera
        oCamera = Camera.main;
        oCamera.transform.position = new Vector3(37, 30, -10);
        oCamera.GetComponent<Camera>().orthographicSize = 15;
        
        //activate Fog Fade
        for (int i = 0; i < Fog.childCount; i++)
        {
            Fog.GetChild(i).GetComponent<Animator>().SetBool("fade", true);
        }
    }
 
}
