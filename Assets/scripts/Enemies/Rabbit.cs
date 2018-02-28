using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Enemy {
    //Esta clase es la que maneja el comportamiento del conejo.
    //Time to jump: es el tiempo que tarda el saltar
    //Speed: Es la fuerza del salto
    //Jump es la funcion que genera el salto
    public int timeToJump;
    public Rigidbody rb;

    public override void Awake() {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }
    public override void Start() {
        base.Start();
    }
    public override void Update() {
        base.Update();
        if ( Vision() < visionRange ) {

            if ( timer > timeToJump ) {
                Jump();
            }
        }
    }
    public void Jump() {
        this.transform.forward = SetDirection();
        rb.AddForce((SetDirection() + this.transform.up)* speed, ForceMode.Impulse);
        ResetTime();
    }
    public Vector3 SetDirection() {
        Vector3 direc = this.transform.position -
        slimeHero.transform.position;
        return -direc.normalized;
    }
    public override void SetEasy() {
        base.SetEasy();
        StartLife(30);
        timeToJump = 5;
        speed = 2;
    }
    public override void SetMedium() {
        base.SetMedium();
        hp = 40;
        timeToJump = 4;
        speed = 3;
    }
    public override void SetHard() {
        base.SetHard();
        hp = 55;
        timeToJump = 3;
        speed = 4;
    }

}
