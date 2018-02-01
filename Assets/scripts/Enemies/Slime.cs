using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy {
    //Aqui es donde se maneja el comportamiento del slime. Es un enemigo tipo torreta que no se mueve pero dispara.
    //Su daño melee es de cero
    //Cada vez que el timerBullets llegue al tiempo de bulletsDelay, va a disparar. 
    //
    public GameObject bulletPf;
    public EnemyBullets sBullet;
    public AudioClip bulletSound;
    public float bulletsDelay;
    public float timerBullets;

    public override void Start() {
        base.Start();
        sBullet = bulletPf.GetComponent<EnemyBullets>();
        bulletsDelay = sBullet.delay;
    }
    public override void Update() {
        base.Update();
        timerBullets += 1 * Time.deltaTime;
        if ( timerBullets > bulletsDelay ) {
            Shooting();
        }

    }
    public void Shooting() {
        sBullet.slimeEnemy = this.gameObject;
        sBullet.DispenseBullets();
        timerBullets = 0;
    }

    public override void SetEasy() {
        base.SetEasy();
        sBullet.bulletsCount = 4;
        sBullet.speed = 2;
        sBullet.dmg = 10;
        sBullet.delay = 3;
    }
}
