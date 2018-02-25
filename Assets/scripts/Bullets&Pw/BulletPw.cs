using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPw : basePW {
    //Aqui se llama a la funcion changebullet para cambiar la bala que tiene 
    //Segun el enum de NewBullet
    public BULLETTYPES newBullet;
    public override void PwBehaviour() {
        slimeHero.currentBulletScript.ResetBulets();
        slimeHero.ChangeBullet(newBullet);
        base.PwBehaviour();
    }
}
