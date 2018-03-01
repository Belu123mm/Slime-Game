using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {

    public enum state {Inactive, Active, Used};

    public state status;

    public CheckPointMananger cp;
    public AudioClip cpSound;
    public bool active;
    public static bool check;
    public float degreesPerSecond = 15;
    public ParticleSystem ps;

    void Start () {
        check = false;
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
    }
    void Update () {
        transform.Rotate(new Vector3(0, Time.deltaTime * degreesPerSecond, 0), Space.World);
    }

    public void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "Slime")
        {
            if(!active)
                AudioMananger.instance.PlayPw(cpSound);
            active = true;
            check = true;
            cp.Check(this.gameObject);
            ps.Play();
        }
    }
}
