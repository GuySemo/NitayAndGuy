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
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Nball.firstEgg = true;
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
    public  void WinLevel()
    {
        MapUpdater.levelsCleared[SceneManager.GetActiveScene().buildIndex-1] = true;
    }
    public void ActiveDialog(int index)
    {
        DialogText.dialogsActive[index] = true;
    }
}
