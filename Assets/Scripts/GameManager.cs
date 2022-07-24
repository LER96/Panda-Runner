using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Menu;
    public bool GamePaused = false;
    public bool inMainMenu;
    Movement playa;
    GameObject p;
    private void Awake()
    {
        //check if your in main menu
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            inMainMenu = true;
        }
        else
        {
            inMainMenu = false;
        }
    
    }

    public void Start()
    {
    }

    void Update()
    {
        //if not main menu you can press the ESC button
        if (inMainMenu == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && GamePaused == false)
            {
                PauseMode(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && GamePaused == true)
            {
                PauseMode(false);
            }
        }
    }

    //god mode scene
    public void GodMode()
    {
        SceneManager.LoadScene(2);
        GamePaused = false;
        Time.timeScale = 1;
    }

    //pause canvas 
    public void PauseMode(bool pause)
    {
        GamePaused = pause;
        Pause(pause);
    }

    //set active the canvas
    public void Pause(bool pause)
    {
        if (pause == true)
        {
            Menu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Menu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    } 

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
        GamePaused = false;
        Time.timeScale = 1;
    }
}
