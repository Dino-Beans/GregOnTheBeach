using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextLevel")
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
}
    