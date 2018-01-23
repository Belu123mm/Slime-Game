using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripleBulletScript : baseBulletScript {
    public GameObject triple;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Shoot()
    {
        slimeEnemy = GameObject.FindGameObjectWithTag("Slime");
        GameObject bullets = GameObject.Instantiate(triple);
        this.transform.position = slimeEnemy.transform.position;

    }
}
