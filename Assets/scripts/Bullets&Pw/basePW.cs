using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basePW : MonoBehaviour {
    public string typeOfBullet;
    public AudioClip pw;
    public slimeScript slimeHero;

    private void Start() {
        slimeHero = FindObjectOfType<slimeScript>();
        print(slimeHero);
    }
    public virtual void OnTriggerEnter( Collider c ) {

        if ( c.gameObject.tag == "Slime" ) {
            print("HEY");
            OverPower();
        }
}

    public virtual void OverPower() {
        AudioMananger.instance.PlayPw(pw);
        Destroy(this.gameObject);
    }
}