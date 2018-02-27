using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public enum state {Inactive, Active, Used};

    public state status;

    public CheckPointMananger cp;
    public static bool check;
    public bool aa;
    public AudioClip cpSound;

    public float degreesPerSecond = 15;
    void Start ()
    {
        check = false;
    }
    void Update ()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * degreesPerSecond, 0), Space.World);
        ChangeColor();
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Slime")
        {
            if(!aa)
                AudioMananger.instance.PlayPw(cpSound);
            aa = true;
            check = true;
            cp.Check(this.gameObject);
            ChangeColor();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void ChangeColor()
    {
        /* if (status == state.Inactive)
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        else if (status == state.Active)
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        else if (status == state.Used)
            gameObject.GetComponent<Renderer>().material.color = Color.grey;*/
    }   
}
