using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
   
    //Fixes character movement being bugged when going menu back to game
    private void Start()
    {
        ResumeLevelBtn();
    }

    //Main Menu Buttons
    public void playBtnPressed()
    {
        SceneManager.LoadScene("BeachLevelBlockout");
    }
    public void ControlssbtnPressed()
    {
        SceneManager.LoadScene("ControlScreen");
    }

    public void QuitbtnPressed()
    {
        Application.Quit();
    }

    public void MenubtnPressed()
    {
        SceneManager.LoadScene("TitleScreen");
    }


    //Next Level Buttons
    public void NextLevelBtn()
    {
        SceneManager.LoadScene("CityLevelBlockout");
    }


    //PAUSE GAME    
    public void ResumeLevelBtn()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
}   
