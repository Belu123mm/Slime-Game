using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : baseEnemy {
    public float timerBullets;
    public GameObject bulletPf;
    public SlimeBullets sBullet;
    public AudioClip bulletSound;
    public override void Update() {
        base.Update();
        timerBullets += 1 * Time.deltaTime;

    }
    public void Shoot() {
        if ( timerBullets > sBullet.bulletsDelay ) {
            sBullet.PJ = this.gameObject;
            sBullet.Shoot();
            timerBullets = 0;
            AudioMananger.instance.PlayNormalBullet(bulletSound);
        }
    }
}