using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    public float timer ;
    public float inten;
    public Light lt;
    public float time;

    void Start () {
        lt = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= time)
        {
            inten -= Time.deltaTime;
            lt.intensity = inten;
        }


    }
}
