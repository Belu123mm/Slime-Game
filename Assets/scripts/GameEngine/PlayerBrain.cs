using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBrain : MonoBehaviour {
    //Esta es una clase con la que se maneja el slimeHero
    //Usando las entradas de unity

    void Update() {

        if ( Input.GetAxis("Horizontal") > 0 )
            this.GetComponent<slimeScript>().Move(Vector3.right * Input.GetAxis("Horizontal"));
        else if ( Input.GetAxis("Horizontal") < 0 )
            this.GetComponent<slimeScript>().Move(Vector3.left * -Input.GetAxis("Horizontal"));

        if ( Input.GetAxis("Vertical") > 0 )
            this.GetComponent<slimeScript>().Move(Vector3.forward * Input.GetAxis("Vertical"));
        else if ( Input.GetAxis("Vertical") < 0 )
            this.GetComponent<slimeScript>().Move(Vector3.back * -Input.GetAxis("Vertical"));
        else if (Input.GetKey(KeyCode.B))
            GetComponent<slimeScript>().Bomb();

        if ( Input.GetKey(KeyCode.Mouse0) ) {
            this.GetComponent<slimeScript>().Shoot();

        
        }
    }
}
