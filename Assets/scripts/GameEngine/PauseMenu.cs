using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pausePanel;

    void Update()
    {
        if (Input.GetKey(KeyCode.P)) {
            OpenPause();
        }
    }
    void OpenPause() {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void closePause() {
        pausePanel.SetActive(false);
        Time.timeScale = 0;
    }
}
