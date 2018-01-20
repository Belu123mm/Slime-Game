using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishCrystal : MonoBehaviour {
    public bool crystalTouched;
    public crystalScript crystal;
    public catScript cat;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision c)
    {
        print("check");
        if (c.gameObject.tag == "Slime" && crystal.catchSlime == true && cat.catchSlime == true)
        {
            crystalTouched = true;
        }
    }
}
