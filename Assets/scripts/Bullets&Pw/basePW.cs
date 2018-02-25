using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basePW : MonoBehaviour {
    public AudioClip pickSound;
    public slimeScript slimeHero;

    private void Start() {
        slimeHero = FindObjectOfType<slimeScript>();
        print(slimeHero);
    }
    public virtual void OnTriggerEnter( Collider c ) {

        if ( c.gameObject.tag == "Slime" ) {
            PwBehaviour();
          //  Destroy(this.gameObject);
        }
    }
    public virtual void PwBehaviour() {

    }
}