using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCrystal : MonoBehaviour {
    public float speed;
    public bool crystal;
	void Update () {
		if(SlimeCinematica.yay)
        {
            if(crystal)
                transform.position -= transform.up * Time.deltaTime * speed;
            else
                transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Yay")
            speed = 0;
    }
}
