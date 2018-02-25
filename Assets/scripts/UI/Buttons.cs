using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public AudioClip ambient;

    void Start()
    {
        AudioMananger.instance.PlayAmbient(ambient);
    } 

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    } 

    public void Exit() {
        print("QUIT!");
        Application.Quit();
    }

    //Borrar esto luegoh
    public void QuePaso()
    {
        SceneManager.LoadScene("QuePaso");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Creditos");
    }
}
