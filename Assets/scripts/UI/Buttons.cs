using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Buttons : MonoBehaviour {
    public AudioClip ambient;
    Resolution [] resolutions;
    public TMP_Dropdown resolutionDropdown;
    void Start()
    {
        if ( resolutionDropdown ) {
            resolutionDropdown.ClearOptions();
            resolutions = Screen.resolutions;

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;

            for ( int i = 0; i < resolutions.Length; i++ ) {

                string option = resolutions [ i ].width + "x" + resolutions [ i ].height;

                if ( !options.Contains(option) ) {
                    options.Add(option);

                }

                if ( resolutions [ i ].width == Screen.currentResolution.width && resolutions [ i ].height == Screen.currentResolution.height ) {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }
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
    public void SetVolume(float volume ) {
        print(volume);
        //manejar el volumen del master desde aca
    }
    public void SetQuality(int index ) {
        QualitySettings.SetQualityLevel(index);
    }
    public void SetFullScreen(bool toggle) {
        Screen.fullScreen = toggle;
        print("fullscreen");
    }
    public void SetResolucion(int index ) {
        Resolution resolution = resolutions [ index ];
        Screen.SetResolution(resolution.width, resolution.height,true);
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
