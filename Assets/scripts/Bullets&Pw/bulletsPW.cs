using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsPW : basePW {
    public override void OverPower() {
        {
            print(slimeHero.bulletPW);
            slimeHero.bulletPW = typeOfBullet;
        }
        base.OverPower();
    }
}
