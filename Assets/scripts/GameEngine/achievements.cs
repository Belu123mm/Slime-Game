using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class achievements : MonoBehaviour
{
    public bool enemiesKilled;
    public bool balas;
    public bool panelActive;
    public GameObject currentAchievementPanel;
    public GameObject bulletsPanel;
    public GameObject enemiesPanel;
    public float timer;
    
    void Update()
    {
        if (Stadistics.totalBullets >= 3 && !balas)
        {            
            currentAchievementPanel = bulletsPanel;
            timer += Time.deltaTime;
            EnablePanel();
            if (timer >= 3)
            {
                balas = true;
                DisablePanel();
            }
        }
        if (Stadistics.enemiesKilled >= 1 && !enemiesKilled && !panelActive)
        {
            timer += Time.deltaTime;
            currentAchievementPanel = enemiesPanel;
            EnablePanel();
            if (timer >= 3)
            {
                enemiesKilled = true;
                DisablePanel();
            }
        }
    }

    void EnablePanel()
    {
        currentAchievementPanel.SetActive(true);
    } 
     void DisablePanel()
    {        
        currentAchievementPanel.SetActive(false);
        timer = 0;
    }    
}
