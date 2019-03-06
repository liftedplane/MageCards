using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string currentLevel, menuLevel;
    public GameObject pauseMenu;
    public bool isPaused;

    private void Awake()
    {
        currentLevel = SceneManager.GetActiveScene().name;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //handling if cancel is pressed or not
        PauseGame();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene("currentLevel");
        Debug.Log("Restarting the game click click");
        SceneManager.LoadScene(currentLevel);
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(menuLevel);
    }
}
