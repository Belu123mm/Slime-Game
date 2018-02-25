using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class BulletPw : basePW {
    //Aqui se llama a la funcion changebullet para cambiar la bala que tiene 
    //Segun el enum de NewBullet
    public BULLETTYPES newBullet;
    public override void PwBehaviour() {
        slimeHero.currentBulletScript.ResetBulets();
        slimeHero.ChangeBullet(newBullet);
        base.PwBehaviour();
    }
=======
public class BulletPw : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
>>>>>>> parent of 22971b0... Revert "Revert "PW BALA""
}
