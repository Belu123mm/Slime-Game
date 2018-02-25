using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPw : basePW {
    public BULLETTYPES newBullet;
    public override void PwBehaviour() {
        slimeHero.ChangeBullet(newBullet);
        base.PwBehaviour();
    }
}
