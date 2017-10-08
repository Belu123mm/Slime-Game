using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public enum state {Inactive, Active, Used};

    public state status;

    public CheckPointMananger cp;

    public static bool check;

	void Start ()
    {
        check = false;
    }

    void Update ()
    {
        ChangeColor();
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Slime")
        {
            check = true;
            cp.Check(this.gameObject);
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        if (status == state.Inactive)
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        else if (status == state.Active)
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        else if (status == state.Used)
            gameObject.GetComponent<Renderer>().material.color = Color.grey;
    } 
}
