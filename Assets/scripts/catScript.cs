using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class catScript : MonoBehaviour {
    public bool catchSlime;
    public float distanceForMinSpeed;
    public float distanceForMaxSpeed;
    public float distance;
    public float variable;
    public float speed;
    public float maxSpeed;
    public Collider c;
    public GameObject pinkSlime;
    public Vector3 dir;
    public Animator cat;

    public AudioClip meow;
	// Use this for initialization
	void Start () {
        cat = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (catchSlime) {
            c = this.GetComponent<Collider>();
            c.isTrigger = true;
            cat.SetBool("catch", true);
            variable = Mathf.Lerp(distanceForMinSpeed, distanceForMaxSpeed, distance - distanceForMinSpeed);
            distance = Vector3.Distance(this.transform.position, pinkSlime.transform.position);
            dir = pinkSlime.transform.position - this.transform.position;
            //print(variable);

            this.transform.forward = dir;
            this.transform.position += this.transform.forward * speed * Time.deltaTime;

            if (distance <= distanceForMinSpeed)
                speed = 0;
            else if (distance < distanceForMaxSpeed) {
                speed = maxSpeed * (variable / (distanceForMaxSpeed));
            } else {
                speed = maxSpeed;

            }
        } else 
        {
            cat.SetBool("catch", false);
            c.isTrigger = false;
        }


    }
    void OnCollisionEnter(Collision c)
    {
        //print("check");
        if (c.gameObject.tag == "Slime")
        {
            AudioMananger.instance.PlayCrystalSlime(meow);
            catchSlime = true;
        }
    }
}
