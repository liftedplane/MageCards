using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public string mainMenuScene, playGameLevel;
    public SceneManager scene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Replay()
    {
        Debug.Log("Restarting Game");
        SceneManager.LoadScene(playGameLevel);
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene(mainMenuScene);
    }
}
