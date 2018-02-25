using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basePW : MonoBehaviour {
    //Base de todos los power ups
    //ESta definido el slimehero y el sonido para pickearlo
    //tambien que al pickearlo se borre
    //PWBehaviour es el comportamiento del powerup, aqui se declara lo que hace
    public AudioClip pickSound;
    public slimeScript slimeHero;

    private void Start() {
        slimeHero = FindObjectOfType<slimeScript>();
        print(slimeHero);
    }
    public virtual void OnTriggerEnter( Collider c ) {

        if ( c.gameObject.tag == "Slime" ) {
            print("HEY");
            PwBehaviour();
<<<<<<< HEAD
            Destroy(this.gameObject);
=======
            Destroy(this);
>>>>>>> parent of 22971b0... Revert "Revert "PW BALA""
        }
    }
    public virtual void PwBehaviour() {

    }
}