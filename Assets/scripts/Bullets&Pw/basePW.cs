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
            print("HEY");
            PwBehaviour();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            Destroy(this.gameObject);
=======
            Destroy(this);
>>>>>>> parent of 22971b0... Revert "Revert "PW BALA""
=======
          //  Destroy(this.gameObject);
>>>>>>> parent of 1891342... Revert "Revert "Ps listo los powerups y comentado los scripts""
=======
            Destroy(this);
>>>>>>> parent of 22971b0... Revert "Revert "PW BALA""
=======
            Destroy(this);
>>>>>>> parent of 22971b0... Revert "Revert "PW BALA""
        }
    }
    public virtual void PwBehaviour() {

    }
}