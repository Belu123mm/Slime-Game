using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalScript : MonoBehaviour {
    public bool catchSlime;
    public float distanceForMinSpeed;
    public float distanceForMaxSpeed;
    float distance;
    float variable;
    public float speed;
    public float maxSpeed;
    public GameObject pinkSlime;
    public Vector3 dir;
    public Collider c;
    public AudioClip crystal;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (catchSlime)
        {//Rotation pliz
            c = this.GetComponent<Collider>();
            c.isTrigger = true;
            variable = Mathf.Lerp(distanceForMinSpeed, distanceForMaxSpeed, distance - distanceForMinSpeed);
            distance = Vector3.Distance(this.transform.position, pinkSlime.transform.position);
            dir = pinkSlime.transform.position - this.transform.position;
           // print(variable);

            this.transform.forward = dir;
            this.transform.position += this.transform.forward * speed * Time.deltaTime;

            if (distance <= distanceForMinSpeed)
                speed = 0;
            else if (distance < distanceForMaxSpeed)
            {
                speed = maxSpeed * (variable / (distanceForMaxSpeed));
            }
            else
            {
                speed = maxSpeed;

            }
        } else {
            c.isTrigger = false;

        }
    }
    void OnCollisionEnter(Collision c)
    {
     //print("check");
        if (c.gameObject.tag == "Slime")
        {
            AudioMananger.instance.PlayCrystalSlime(crystal);
            catchSlime = true;
        }
    }
}
