using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Slime")
        {
            print("YAY slime encontrado");
        }
    }
}
