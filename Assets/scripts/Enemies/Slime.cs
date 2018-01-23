using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : baseEnemy {
    public float timerBullets;
    public GameObject bulletPf;
    public SlimeBullets sBullet;
    public AudioClip bulletSound;
    public float bulletsDelay;

    public override void Start() {
        base.Start();
        sBullet = bulletPf.GetComponent<SlimeBullets>();
    }
    public override void Update() {
        base.Update();
        Debug.Log(this.gameObject);
        timerBullets += 1 * Time.deltaTime;
        if ( timerBullets > bulletsDelay ) {
            Shoot();
        }

    }
    public void Shoot() {
        sBullet.slimeEnemy = this.gameObject;
        sBullet.Shoot();
        timerBullets = 0;
        AudioMananger.instance.PlayNormalBullet(bulletSound);
    }

    public override void SetEasy() {
        base.SetEasy();
        sBullet.bulletsCount = 4;
        sBullet.speed = 2;
        sBullet.damage = 10;
    }
}
