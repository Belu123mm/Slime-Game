using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


    public static bool pause = false;
    public GameObject pausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if ( pause  ) {
                Resume();
            } else {
                Paused();
            }
        }
    }
    void Paused() {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        pause = true;
    }
    public void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pause = false;
    }
}
