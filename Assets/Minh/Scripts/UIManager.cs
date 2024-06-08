using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject PauseUI;
    public int playTime;
    public float decimalPlaytime = 0;
    public bool levelIsRunning = true;

    public void Play()
    {
        SceneManager.LoadScene("GamePlay 1");
        Time.timeScale = 1;
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("GamePlay 2");
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Continue()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && levelIsRunning == true)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                PauseUI.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                PauseUI.SetActive(false);
            }
        }
    }

}
