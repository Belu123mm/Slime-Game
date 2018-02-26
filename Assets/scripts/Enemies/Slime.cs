using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy {
    //Aqui es donde se maneja el comportamiento del slime. Es un enemigo tipo torreta que no se mueve pero dispara.
    //Su daño melee es de cero
    //Cada vez que el timerBullets llegue al tiempo de bulletsDelay, va a disparar. 
    //
    public GameObject bulletPf;
    public Circle sBullet;
    public AudioClip bulletSound;
    public float bulletsDelay;
    public float timerBullets;
    public float bulletDistance;
   // public float rotationSpeed;
    public override void Awake() {
        base.Awake();
        sBullet = bulletPf.GetComponent<Circle>();
    }
    public override void Start() {
        base.Start();
        bulletsDelay = sBullet.delay;
        bulletDistance = sBullet.distance;
    }
    public override void Update() {
    //    transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        bulletDistance = Vector3.Distance(bulletPf.transform.position, transform.position);
       /* if (bulletDistance > 20)
            Destroy(bulletPf.gameObject);*/
        base.Update();
        if ( Vision() < visionRange ) {
            if ( timer > bulletsDelay ) {
                Shooting();
            }
        }
    }
    public void Shooting() {
        sBullet.discharger = this.gameObject;       //Dice que el discharger es el slime :3
        sBullet.DispenseBullets();
        ResetTime();
    }

    public override void SetEasy() {
        base.SetEasy();
        hp = 30;
        sBullet.bulletsCount = 4;
        sBullet.speed = 2;
        sBullet.dmg = 10;
        sBullet.delay = 3;
    }
    public override void SetMedium() {
        base.SetMedium();
        hp = 40;
        sBullet.bulletsCount = 5;
        sBullet.speed = 3;
        sBullet.dmg = 12;
        sBullet.delay = 2;
    }
    public override void SetHard() {
        base.SetHard();
        hp = 55 ;
        sBullet.bulletsCount = 6;
        sBullet.speed = 4;
        sBullet.dmg = 15;
        sBullet.delay = 1;
    }

}
