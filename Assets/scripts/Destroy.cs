using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Slime")
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Slime")
        {
            Destroy(this.gameObject);
        }
    }

}
