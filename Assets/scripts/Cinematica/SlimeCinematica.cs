using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCinematica : MonoBehaviour
{
    public int speed;
    public float timer;
    public float otherTimer;
    public static bool scream;
    public bool move;
    public Vector3 dir;
    public GameObject target;
    public AudioClip cristal;
    public AudioClip cat;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        if (scream)
        {
            timer += Time.deltaTime;

            if (timer > 0.5f)
            {
                timer = -5;
                AudioMananger.instance.PlayCrystalSlime(cristal);
                AudioMananger.instance.PlayHurt(cat);
                move = true;
            }
            if (move)
            {
                otherTimer += Time.deltaTime;
                if (otherTimer > 0.5)
                {
                    speed = 3;
                    dir = target.transform.position - transform.position;
                    transform.forward = dir;
                    transform.position += transform.forward * Time.deltaTime * speed;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            speed = 0;
            scream = true;
            move = false;
        }
    }
}
