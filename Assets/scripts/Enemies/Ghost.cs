using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy {
    public Rigidbody rb;

    public override void Awake()
    {
        base.Awake();
        rb = this.GetComponent<Rigidbody>();
    }
    public override void Update()
    {
        base.Update();
        if (Vision() < visionRange)
        {
            Follow();
        }
    }
    public void Follow()
    {
        transform.forward = -(transform.position + slimeHero.transform.position).normalized;
        transform.position += this.transform.forward * speed / 100;
    }
    public override void SetEasy()
    {
        base.SetEasy();
        hp = 30;
        speed = 1;
    }
    public override void SetMedium()
    {
        base.SetMedium();
        hp = 40;
        speed = 2;
    }
    public override void SetHard()
    {
        base.SetHard();
        hp = 55;
        speed = 3;
    }

}
