using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy {
    public Rigidbody rb;

    public override void Awake() {
        base.Awake();
        rb = this.GetComponent<Rigidbody>();
        print(Vision());
    }
    public override void Update() {
        base.Update();
        if(Vision() < visionRange ) {
            Follow();
        }
    }
    public void Follow() {
        this.transform.forward = -(transform.position + slimeHero.transform.position).normalized;
        this.transform.position += this.transform.forward * speed / 100;    }
    public override void SetEasy() {
        base.SetEasy();
        speed = 1;
    }
    public override void SetMedium() {
        base.SetMedium();
        speed = 2;
    }
    public override void SetHard() {
        base.SetHard();
        speed = 3;
    }

}
