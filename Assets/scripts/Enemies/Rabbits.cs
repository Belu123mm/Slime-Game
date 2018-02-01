using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbits : Enemy {
    public GameObject slimeHero;
    public float timeToJump;
    private float timer;

    public override void Start() {
        base.Start();
        slimeHero = FindObjectOfType<slimeScript>().gameObject;
        timer = 0;
    }
    public override void Update() {
        base.Update();
        timer += Time.deltaTime;


        //Ver como hacer para saltar hacia el pj :3
    }

}
