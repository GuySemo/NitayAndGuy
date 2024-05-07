using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelScript : MonoBehaviour
{
    [SerializeField] GameObject mCamera;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject ufoCover;
    float coverTimer;
    bool coverOff = false;
    [SerializeField] GameObject MenashFake;
    [SerializeField] GameObject MenashReal;
    [SerializeField] GameObject DamageEffect;
    [SerializeField] GameObject FinalCutscene;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<MilkGun>().canShoot = false;
        mCamera.GetComponent<AudioSource>().Pause();
        MenashReal.SetActive(false);
        coverOff = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (coverOff && Time.time - coverTimer > 3)
        {
            mCamera.GetComponent<AudioSource>().UnPause();
            FindObjectOfType<MilkGun>().canShoot = true;
            canvas.transform.GetChild(1).GetComponent<Timer>().started = true;
            Destroy(MenashFake);
            MenashReal.SetActive(true);
            coverOff = false;
        }
    }
    public void RemoveCover()
    {
        coverTimer = Time.time;
        ufoCover.GetComponent<Animator>().SetBool("fade", true);
        Destroy(ufoCover, 5);
        coverOff = true;
    }
    public void GetHit()
    {
        Instantiate(DamageEffect, new Vector3(0, 0, 0), Quaternion.identity);
        FindObjectOfType<HealthFinalLevel>().LoseHeart();
    }
    public void Win()
    {
        FindObjectOfType<MilkGun>().canShoot = false;
        DialogText.dialogsActive[11] = true;
        FinalCutscene.SetActive(true);
        mCamera.GetComponent<AudioSource>().Pause();
        FindObjectOfType<Timer>().started = false;
    }
}
