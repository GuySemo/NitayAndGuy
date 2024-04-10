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

    public static bool level13 = false;
    public static bool level14 = false;
    public static bool level15 = false;
    public static bool level16 = false;


    public static bool[] levelsCleared = { level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11, level12,
        level13, level14, level15, level16
    };

    [SerializeField] GameObject levels;
    int levelCount;
    Transform[] levelButtons;

    //Cutscene shi
     Camera oCamera;
    [SerializeField] Transform FogW2;
    public static bool destoryFogW2 = false;
    static bool w2cutActive = false;
    float cutsceneTimer;
    [SerializeField] GameObject world2Cutscene;

    //Cutscene W3  shi
    [SerializeField] Transform FogW3;
    public static bool destoryFogW3 = false;
    static bool w3cutActive = false;
    float cutsceneW3Timer;
    //Kodan
    int kodan=0;
    //FreePlay
    public static bool freePlay = false;

    void Start()
    {
        if (destoryFogW2)
        {
            Destroy(FogW2.gameObject);
        }
        if (destoryFogW3)
        {
            Destroy(FogW3.gameObject);
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
            if (i < levelsCleared.Length -1 )
            {
                levelButtons[i + 1].GetComponent<Clickables>().canClick = levelsCleared[i];
                levelButtons[i + 1].GetComponent<Clickables>().ReColor();
            }
            if (freePlay)
            {
                levelButtons[i].GetComponent<Clickables>().canClick = true;
                levelButtons[i].GetComponent<Clickables>().ReColor();
            }
        }
        //FreePlay
        
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
                Clickables.cantClickMode = false;
                w2cutActive = false;
                Destroy(FogW2.gameObject);
                destoryFogW2 = true;
                //Activate 2nd Menash
                DialogText.dialogsActive[5] = true;
                world2Cutscene.SetActive(true);
                oCamera.transform.localPosition = new Vector3(oCamera.transform.localPosition.x,
     oCamera.transform.localPosition.y, -10);
            }
        }
        //World 2 to 3 cutscene
        if (w3cutActive)
        {
            if (Time.time - cutsceneW3Timer > 6)
            {
                oCamera.GetComponent<Camera>().orthographicSize = 7;
                FindObjectOfType<MCameraMove>().canMove = true;
                Clickables.cantClickMode = false;
                w3cutActive = false;
                Destroy(FogW3.gameObject);
                destoryFogW3 = true;
            }
        }
    }
    public void UnlockAll()
    {
        //Button Clickable
        for (int i = 0; i < levelsCleared.Length -1; i++)
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
        Clickables.cantClickMode = true;
        //Camera Can't move
        FindObjectOfType<MCameraMove>().canMove = false;

        //Change Camera
        oCamera = Camera.main;
        oCamera.transform.position = new Vector3(37, 30, -10);
        oCamera.GetComponent<Camera>().orthographicSize = 15;
        
        //activate Fog Fade
        for (int i = 0; i < FogW2.childCount; i++)
        {
            FogW2.GetChild(i).GetComponent<Animator>().SetBool("fade", true);
        }
    }

    public void W3Cutscene()
    {
        w3cutActive = true;
        cutsceneW3Timer = Time.time;

        //Camera Can't move
        FindObjectOfType<MCameraMove>().canMove = false;

        //Change Camera
        oCamera = Camera.main;
        oCamera.transform.position = new Vector3(80, 85, -10);
        oCamera.GetComponent<Camera>().orthographicSize = 15;

        //activate Fog Fade
        for (int i = 0; i < FogW3.childCount; i++)
        {
            FogW3.GetChild(i).GetComponent<Animator>().SetBool("fade", true);
        }
    }


}
