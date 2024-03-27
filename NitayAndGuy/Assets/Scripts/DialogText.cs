using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogText : MonoBehaviour, IPointerClickHandler // 2
    , IDragHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{
    GameObject[] children = { null, null, null, null, null , null, null, null, null, null };
    int index = 0;
    float timer;

    [SerializeField] int dialogIndex = 0;
    float endTimer;
    public static bool[] dialogsActive = { true, false, false, false, false, false , false, false, false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        if (!dialogsActive[dialogIndex])
        {
            Debug.Log(dialogIndex);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<MCameraMove>().canMove = false;
            FindObjectOfType<Clickables>().cantClickMode = true;
        }
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject thisChild = gameObject.transform.GetChild(i).gameObject;
            children[i] = thisChild;
            children[i].SetActive(false);
        }
        children[index].gameObject.SetActive(true);

        timer = Time.time +2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogsActive[dialogIndex] && Time.time - endTimer > 1)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        //Delay
        if ((Time.time - timer > 3))
        {
            timer = Time.time;
            //If there is text
            if (children[index + 1] != null)
            {
                //show it
                index++;
                children[index - 1].gameObject.SetActive(false);
                children[index].gameObject.SetActive(true);
            }
            else
            {
                ////Set this dialog false
                //dialogsActive[dialogIndex] = false;
                //endTimer = Time.time;
                //children[index].gameObject.SetActive(false);
                ////Activate ending animation in menash and text
                //gameObject.transform.parent.GetChild(1).GetChild(0).GetComponent<Animator>().SetBool("finished", true);
                //gameObject.transform.parent.GetChild(0).GetComponent<Animator>().SetBool("finished", true);

                //FindObjectOfType<MCameraMove>().canMove = true;
                SkipDialog();
            }
        }
    }
    public void SkipDialog()
    {
        //Set this dialog false
        dialogsActive[dialogIndex] = false;

        endTimer = Time.time;

        children[index].gameObject.SetActive(false);

        //Activate ending animation in menash and text
        gameObject.transform.parent.GetChild(1).GetChild(0).GetComponent<Animator>().SetBool("finished", true);
        gameObject.transform.parent.GetChild(0).GetComponent<Animator>().SetBool("finished", true);

        FindObjectOfType<MCameraMove>().canMove = true;
        FindObjectOfType<Clickables>().cantClickMode = false;
        //Activate world 2 cutscene after 4th dialog
        if (dialogIndex == 4)
        {
            FindObjectOfType<MapUpdater>().W2Cutscene();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
