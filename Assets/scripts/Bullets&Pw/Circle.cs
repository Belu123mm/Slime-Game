using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Bullets {
    //Aqui se declaran las balas del enemigo. 
    //Se instantean y siguen en linea recta. 
    //Al estar muy lejos, impactan 
    //Al chocar con el escenario, impactan. 
    public float degrees;
    public int bulletsCount;

    void Update() {

        transform.position += transform.forward * Time.deltaTime * speed;
        if ( discharger ) {
        distance = Vector3.Distance(discharger.transform.position, this.transform.position);
        }else {
            Destroy(this.gameObject);
        }
    }
    public override void DispenseBullets() {
        for ( int i = 0; i < 360; i += 360 / bulletsCount ) {
            Vector3 direction;
            direction.x = Mathf.Cos((i + degrees) * Mathf.Deg2Rad);
            direction.y = 0;
            direction.z = Mathf.Sin((i + degrees) * Mathf.Deg2Rad);

            this.transform.position = discharger.transform.position + new Vector3(0, 0.5f, 0);
            GameObject bullets = Instantiate(gameObject);
            bullets.transform.forward = direction;
            Stadistics.totalBullets += bulletsCount;
            //Debug
            Debug.DrawRay(discharger.transform.position, bullets.transform.forward, Color.green, 100, false);
        }
    }
}
