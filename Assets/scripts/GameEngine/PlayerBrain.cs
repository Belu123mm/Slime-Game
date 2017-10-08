using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
        if (Input.GetAxis("Horizontal") > 0)
            this.GetComponent<slimeScript>().Move(Vector3.right * Input.GetAxis("Horizontal"));
        else if (Input.GetAxis("Horizontal") < 0)
            this.GetComponent<slimeScript>().Move(Vector3.left * -Input.GetAxis("Horizontal"));

        if (Input.GetAxis("Vertical") > 0)
            this.GetComponent<slimeScript>().Move(Vector3.forward * Input.GetAxis("Vertical"));
        else if (Input.GetAxis("Vertical") < 0)
            this.GetComponent<slimeScript>().Move(Vector3.back * -Input.GetAxis("Vertical"));//Bysebs

        if (Input.GetKey(KeyCode.Mouse0))
        {
            this.GetComponent<slimeScript>().Shoot();
        }  
    }
}
