using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public slimeScript slimeHero;
    public GameObject panel;

    private void Start()
    {
        slimeHero = FindObjectOfType<slimeScript>();
    }
    public void Update()
    {       
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Slime")
        {
            if (!slimeHero.cat)
                panel.SetActive(true);
        }
       // else panel.SetActive(false);

    }
    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Slime")
            panel.SetActive(false);


    }
}
