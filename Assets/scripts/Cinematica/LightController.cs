using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    public float timer ;
    public float inten;
    public Light lt;   

    void Start () {
        lt = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= 9)
        {
            inten -= Time.deltaTime;
            lt.intensity = inten;
        }


    }
}
