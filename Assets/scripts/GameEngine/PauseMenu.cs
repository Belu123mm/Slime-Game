using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pausePanel;

    public static bool pause = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.P)) {
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
        Time.timeScale = 0;
        pause = false;
    }
}
