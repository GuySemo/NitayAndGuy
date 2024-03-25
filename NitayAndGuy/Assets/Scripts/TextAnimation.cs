using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    string originalInput;
    char[] arr;
    int i = 0;
    float timer;
    [SerializeField] float delay = 1;
    float delayTimer;
    bool canTalk = false;
    bool finished = false;

    [SerializeField] AudioClip typing;
    // Start is called before the first frame update
    void Start()
    {
        originalInput = GetComponent<TMP_Text>().text;
        GetComponent<TMP_Text>().text = "".ToString();
        timer = Time.time;
        delayTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - delayTimer > delay && !canTalk )
        {
            canTalk = true;
        }
        if (Time.time - timer > 0.05f && i < originalInput.Length && canTalk && !finished)
        {
            //AudioSource.PlayClipAtPoint(typing, Camera.main.transform.position);
            GetComponent<TMP_Text>().text = (GetComponent<TMP_Text>().text + originalInput[i]).ToString();
            timer = Time.time;
            i++;
        }

    }
    private void OnMouseUp()
    {
        finished = true;
        GetComponent<TMP_Text>().text = originalInput.ToString();
    }
}
