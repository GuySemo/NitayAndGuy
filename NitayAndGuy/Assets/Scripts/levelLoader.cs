using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    private void Start()
    {
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
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
