using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    public Text nameText;
    public Text descriptionText;
    public Text price;
    public Text ammountText;
    public string name;
    public string description;
    public int cost;
    public GameObject shopPanel;
    public GameObject noMoney;
    public void Start()
    {
        nameText.text = name;
        descriptionText.text = description;
        price.text = "Price: " + cost;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Slime")
            OpenShop();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Slime")
            CloseShop();
    }
    void OpenShop()
    {
        shopPanel.SetActive(true);
        // Time.timeScale = 0;
    }
    public void CloseShop()
    {
        shopPanel.SetActive(false);
        noMoney.SetActive(false);
        //   Time.timeScale = 1;
    }
    public void OnClick()
    {
        if (slimeScript.coins >= cost)
        {
            slimeScript.coins -= cost;
            print("yay, es tuyo");
            shopPanel.SetActive(false);
        }
        else noMoney.SetActive(true);
    }
}
