using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {
    //Esta es la clase en la que parten todas las bullets
    //Tiene su propio daño, velocidad, sonido y direccion
    //Se creala funcion DispenseBullets para hacer un override luego.
    //La funcion Impact destruye el objeto y reproduce el sonido de disparo.
    //Tiene que haber SI O SI UN ROGIDBODY
    public int speed,
               delay,
               dmg;
    public float distance;
    public Vector3 direction;
    public AudioClip impactSound, shootSound;

    public virtual void DispenseBullets() {

    }
    public void Impact() {
        Destroy(this.gameObject,0.3f);
    }
    void OnTriggerEnter( Collider c ) {
        if ( c.gameObject.layer == LayerMask.NameToLayer("Level") ) {
            Impact();
        }
    }

}
