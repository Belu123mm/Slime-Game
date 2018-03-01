using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class achievements : MonoBehaviour
{   //Agregar paneles y bools aqui
    public GameObject bulletsPanel;
    public bool balas;
    public GameObject enemiesPanel;
    public bool enemiesKilled;

    public static achievements instance;
    
    public void Awake() {
        if ( !instance ) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (Stadistics.totalBullets >= 3 && !balas)
        {
            bulletsPanel.SetActive(true);
        }
        if (Stadistics.enemiesKilled >= 1 && !enemiesKilled )
        {
            enemiesPanel.SetActive(true);
        }
    }

}
