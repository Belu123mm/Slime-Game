using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : Bullets {
    //Aqui se declaran las balas del enemigo. 
    //Se instantean y siguen en linea recta. 
    //Al estar muy lejos, impactan 
    //Al chocar con el escenario, impactan. 
    public float degrees;
    public int bulletsCount;
    public GameObject slimeEnemy;

    void Update() {
        this.transform.position += this.transform.forward * Time.deltaTime * speed;
        
        distance = Vector3.Distance(slimeEnemy.transform.position, this.transform.position);
        if ( distance > 20 ) {
            Impact();
        }
    }
    public override void DispenseBullets() {
        for ( int i = 0; i < 360; i += 360 / bulletsCount ) {
            Vector3 direction;
            direction.x = Mathf.Cos((i + degrees) * Mathf.Deg2Rad);
            direction.y = 0;
            direction.z = Mathf.Sin((i + degrees) * Mathf.Deg2Rad);

            this.transform.position = slimeEnemy.transform.position;
            GameObject bullets = Instantiate(this.gameObject);
            bullets.transform.forward = direction;
            Stadistics.totalBullets += bulletsCount;
            //Debug
            Debug.DrawRay(slimeEnemy.transform.position, bullets.transform.forward, Color.green, 100, false);
        }
    }
}