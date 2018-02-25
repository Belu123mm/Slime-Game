using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosScript : MonoBehaviour {
    public Scene currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void IrAMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void reiniciarNivel()
    {
        SceneManager.LoadScene(currentScene.name);
    }
}
