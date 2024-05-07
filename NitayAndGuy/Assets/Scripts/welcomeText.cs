using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class welcomeText : MonoBehaviour
{
    // Start is called before the first frame update
    bool visited=false;
    void Start()
    {
        if (visited)
        {
            GetComponent<TMP_Text>().text = "Welcome Back, "+FindObjectOfType<SaveProgress>().name ;
        }
        else
        {
            GetComponent<TMP_Text>().text = "Welcome, " + FindObjectOfType<SaveProgress>().name;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
