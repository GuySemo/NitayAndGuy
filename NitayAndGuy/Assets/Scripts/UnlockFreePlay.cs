using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockFreePlay : MonoBehaviour
{
    //Kodan
    int kodan = 0;

    void Update()
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
                        kodan = 0;
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
                    GetComponent<Button>().interactable = true;
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
    }

}
