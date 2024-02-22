using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickables : MonoBehaviour
{
    [SerializeField] GameObject levelPanel;
    // Start is called before the first frame update
    void Start()
    {
        levelPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = new Color(.75f, .75f, .75f, 1);
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1);

    }
    private void OnMouseDown()
    {
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        levelPanel.SetActive(true);
    }
}
