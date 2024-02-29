using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public static bool canThrow = true;

    private void Start()
    {
        canThrow = true;
        Time.timeScale = 1;
        Nball.firstEgg = true;
        NnormalEnemy.chickens = 0;
        NnormalEnemy.chickensAlive = 0;

    }
    public void GoToLevel(int goToLevel)
    {
        SceneManager.LoadScene(goToLevel);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        Camera.main.GetComponent<AudioSource>().pitch = 0.5f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Camera.main.GetComponent<AudioSource>().pitch = 1f;
    }
    public  void WinLevel(int num)
    {
        MapUpdater.levelsCleared[num - 1] = true;
    }
}
