using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointMananger : MonoBehaviour
{
    public slimeScript slimeHero;

    public GameObject[] checkPoints;

    public int count;

	void Start ()
    {
        //Esto busca los objetos por tag en la escena y los hago una lista. 
        checkPoints = GameObject.FindGameObjectsWithTag("checkpoint");
        slimeHero = FindObjectOfType<slimeScript>();
	}
	
 	void Update ()
    {
        //Si la vida del slime es menor o igual a 0 y no colisiono con el checkpoint va a la escena de GO.
        if (slimeHero.hp <= 0 && !CheckpointScript.check)
            SceneManager.LoadScene("GameOver");
        //Pero si colisiono con el CP revive 
        else if (slimeHero.hp <= 0 && count < 3 && CheckpointScript.check)
        {
            count++;
            slimeHero.hp = 1;
            //slimeScript.textVida = 100;

            foreach (GameObject cp in checkPoints)
            {
                if (cp.GetComponent<CheckpointScript>().status == CheckpointScript.state.Active)
                    slimeHero.transform.position = cp.transform.position;
            }
        }

        if (slimeHero.hp <= 0 && count > 3)
            SceneManager.LoadScene("GameOver");
	}
    
    public void Check(GameObject currentCp)
    {
        foreach (GameObject cp in checkPoints)
        {
            if (cp.GetComponent<CheckpointScript>().status != CheckpointScript.state.Inactive)
                cp.GetComponent<CheckpointScript>().status = CheckpointScript.state.Used;
        }

        currentCp.GetComponent<CheckpointScript>().status = CheckpointScript.state.Active;
    }
}
