using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GoToMenu()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GoToMenu1()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
