using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cofreScript : MonoBehaviour
{
    public bool isOpen;
    public bool si;
    public bool no;
    public bool interaction;
    public GameObject _merch;
    public Renderer rendMerch;
    public GameObject _moldeSi;
    public GameObject _moldeNoTiene;
    public GameObject _moldeAdios;
    public GameObject gAdios;
    public GameObject gSi;
    public GameObject gNo;
    public slimeScript slimeHero;

	// Use this for initialization
	void Start ()
    {
        si = false;
        no = false;
        isOpen = false;
        interaction = true;
        rendMerch = _merch.GetComponent<Renderer>();
        rendMerch.enabled = false;
        slimeHero = FindObjectOfType<slimeScript>();

    }

    // Update is called once per frame
    void Update ()
    {
        if (isOpen)
        {
            if (isOpen && interaction)
            {
                rendMerch.enabled = true;
                _merch.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 10, Camera.main.transform.position.z - 4);
            }
            else
                rendMerch.enabled = false;

            if (Input.GetKeyDown(KeyCode.Y) && !si)
            {
                if (slimeHero.coins >= 3)
                {
                    interaction = false;
                    si = true;
                    rendMerch.enabled = false;
                    gSi = Instantiate(_moldeSi);
                }
                else if (slimeHero.coins <= 3)
                {
                    interaction = false;
                    no = true;
                    rendMerch.enabled = false;
                    gNo = Instantiate(_moldeNoTiene);
                }

            }
            if (Input.GetKeyDown(KeyCode.N) && !no)
            {
                interaction = false;
                no = true;
                rendMerch.enabled = false;
                gAdios = Instantiate(_moldeAdios);
            }

        }
        else
        {
            rendMerch.enabled = false;
            Destroy(gNo.gameObject);
            Destroy(gSi.gameObject);
            Destroy(gAdios.gameObject);
            interaction = true;
        }


    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Slime")
        {
            isOpen = true;
        }
    }
    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Slime")
        {
            isOpen = false;
        }
    }
}
