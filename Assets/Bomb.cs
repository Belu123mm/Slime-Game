using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public float power;
    public float radius;
    public float upForce;
    public float timer;
    public Rigidbody r;

	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            detonate();
        }
    }

   public void detonate()
    {
        Vector3 explosion = transform.position;
        Collider[] c = Physics.OverlapSphere(explosion, radius);
        foreach (var hit in c) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            rb.AddExplosionForce(power, explosion, radius, upForce, ForceMode.Impulse);

            Destroy(gameObject);
        }
    }
}
