using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseBulletScript : MonoBehaviour {
    //Esta es la clase en la que parten todas las bullets
    public float speed; //Debe ser declarada en el prefab
    public float bulletsDelay; //Debe ser declarada en el prefab
    public float distance;
    public GameObject PJ;
    public Vector3 mouseRay;
    public static int totalImpact;

    public void OnCollisionEnter(Collision c) {
        if (c.gameObject.tag == "Level") {
            Destroy(this.gameObject);

        }
        if (c.gameObject.tag == "Enemigo") {
            Destroy(this.gameObject);
            Stadistics.totalImpacts++;
        }
    }
}
