using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineTraps : MonoBehaviour
{
    public float timeToUp;
    public float timeToDown;
    public bool isUp;
	// Use this for initialization
	void Start ()
    {
	}
		

	
	// Update is called once per frame
	void Update ()
    {
        timeToUp += 1 * Time.deltaTime;

        if (timeToUp >= 3 && !isUp)
        {
            this.transform.position = new Vector3(this.transform.position.x, 3, this.transform.position.z);
            timeToUp = 0;
            isUp = true;    
        }

        if (isUp)
        {
            timeToDown += 1 * Time.deltaTime;

         if (timeToDown > 2)
            {
                this.transform.position = new Vector3(this.transform.position.x, 1.6f, this.transform.position.z);

                timeToDown = 0;
                timeToUp = 0;
                isUp = false;
            }
        }
    }
}
