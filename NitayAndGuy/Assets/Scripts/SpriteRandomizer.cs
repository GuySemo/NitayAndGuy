using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteRandomizer : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    float timer;
    bool canMorph = true;
    bool isMorphed = false;
    float morphTimer;
    Sprite originalSprite;
    float sizeY;
    Vector2 originalSize;
    // Start is called before the first frame update
    void Start()
    {
        originalSprite = GetComponent<Image>().sprite;
        sizeY = GetComponent<RectTransform>().sizeDelta.y;
        originalSize = GetComponent<RectTransform>().sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMorph)
        {
            canMorph = false;
            timer = Time.time;
        }
        if (!canMorph)
        {
            if (Time.time - timer > 0.1f)
            {
                timer = Time.time;
                if (Random.Range(0,10) == 1)
                {
                    GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
                    GetComponent<RectTransform>().sizeDelta = new Vector2(sizeY, sizeY);
                    isMorphed = true;
                    morphTimer = Time.time;
                }
            }
        }
        if (isMorphed)
        {
            if (Time.time - morphTimer > 0.2f)
            {
                GetComponent<Image>().sprite = originalSprite;
                GetComponent<RectTransform>().sizeDelta = originalSize;
                isMorphed = false;
                canMorph = true;
            }
        }
    }
}
