using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void IrAJuego()
    {
        SceneManager.LoadScene("1rstLevel");
    }

    public void IrACreditos()
    {
        SceneManager.LoadScene("Credits");
    }
    public void IrATutorial()
    {
        SceneManager.LoadScene("Que paso");
    }
}
