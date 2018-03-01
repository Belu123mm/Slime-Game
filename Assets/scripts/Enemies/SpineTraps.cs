using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineTraps : MonoBehaviour
{
    public float timeToUp;
    public float timeToDown;
    public bool isUp;
    public AudioClip metalSound;
    public AudioSource metal;
    private void Start()
    {
        metal = GetComponent<AudioSource>();
    }
    void Update ()
    {
        timeToUp += 1 * Time.deltaTime;

        if (timeToUp >= 3 && !isUp)
        {
            transform.position = new Vector3(this.transform.position.x, .7f, this.transform.position.z);
            timeToUp = 0;
            metal.PlayOneShot(metalSound, 0.7f);
            isUp = true;    
        }

        if (isUp)
        {
            timeToDown += 1 * Time.deltaTime;

         if (timeToDown > 2)
            {
                transform.position = new Vector3(this.transform.position.x, -.8f, this.transform.position.z);
                timeToDown = 0;
                timeToUp = 0;
                isUp = false;
            }
        }
    }
}
