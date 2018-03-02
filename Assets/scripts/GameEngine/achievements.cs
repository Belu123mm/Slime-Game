using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class achievements : MonoBehaviour
{   //Agregar paneles y bools aqui
    public GameObject bulletsPanel;
    public GameObject enemiesPanel;
    public GameObject totalImpactsPanel;
    public GameObject coinsPanel;
    public GameObject totalDeathPanel;
    public bool totalDeath;
    public bool coins;
    public bool totalImpacts;
    public bool enemiesKilled;
    public bool balas;
    public float timer;
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
        if (Stadistics.totalBullets >= 100  && !balas)
        {
            timer += Time.deltaTime;
            bulletsPanel.SetActive(true);
            if(timer > 2)
            {
                balas = true;
                bulletsPanel.SetActive(false);
                timer = 0;
            }
        }
        if (Stadistics.enemiesKilled >= 50 && !enemiesKilled )
        {
            timer += Time.deltaTime;
            enemiesPanel.SetActive(true);
            if(timer > 2)
            {
                enemiesKilled = true;
                enemiesPanel.SetActive(false);
                timer = 0;
            }
        }
        if (Stadistics.totalImpacts >= 70 && !totalImpacts)
        {
            timer += Time.deltaTime;
            totalImpactsPanel.SetActive(true);
            if(timer > 2)
            {
                totalImpacts = true;
                totalImpactsPanel.SetActive(false);
                timer = 0;
            }
        }
        if (Stadistics.totalDeath >= 15 && !totalDeath)
        {
            timer += Time.deltaTime;
            coinsPanel.SetActive(true);
            if(timer > 2)
            {
                totalDeath = true;
                totalDeathPanel.SetActive(false);
                timer = 0;
            }
        }
        if (Stadistics.level1Timer >= 200 && !coins)
        {
            timer += Time.deltaTime;
            coinsPanel.SetActive(true);
            if(timer > 2)
            {
                coins = true;
                coinsPanel.SetActive(false);
                timer = 0;
            }
        }
    }

}
