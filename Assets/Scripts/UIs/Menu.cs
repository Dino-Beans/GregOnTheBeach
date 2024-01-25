using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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


}
