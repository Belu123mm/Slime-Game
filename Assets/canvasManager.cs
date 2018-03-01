using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class canvasManager : MonoBehaviour
{
    public GameObject panelBomb;
    public slimeScript slimeHero;
    public TextMeshProUGUI ammount;
    public void Start()
    {
        slimeHero = FindObjectOfType<slimeScript>();
    }
    void Update()
    {
        if (slimeHero.cant >= 0 && slimeHero.bomb)
        {
            panelBomb.SetActive(true);
            if (ammount != null)
                ammount.text = "" + slimeHero.cant;
        }
        if(slimeHero.cant == 0) panelBomb.SetActive(false);

    }
}
