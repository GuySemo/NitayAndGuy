using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickables : MonoBehaviour
{
    [SerializeField] GameObject levelPanel;
    public bool canClick = true;
    public static bool cantClickMode = false;
    [SerializeField] AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        levelPanel.SetActive(false);

        if (!canClick)
        {
            GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (canClick && !cantClickMode)
        {
            GetComponent<SpriteRenderer>().color = new Color(.75f, .75f, .75f, 1);
        }
    }
    private void OnMouseExit()
    {
        if (canClick && !cantClickMode)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1);
        }

    }
    private void OnMouseDown()
    {
    }
    private void OnMouseUp()
    {
        if (canClick && !cantClickMode)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            levelPanel.SetActive(true);
            if (sound != null)
            {
                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position - new Vector3(0, 0, 3));
            }
        }
    }
    public void ReColor()
    {
        if (!canClick)
        {
            GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f, 1);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
}
