using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public float power;
    public float radius;
    public float upForce;
    public float timer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 3)
            detonate();
    }

   public void detonate()
    {
        Vector3 explosion = transform.position;
        Collider[] c = Physics.OverlapSphere(explosion, radius);
        foreach (var hit in c) {
         //   hit.tag = "Bomb";// aca es el problema 
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
                rb.AddExplosionForce(power, explosion, radius, upForce, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
