using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Bullets {
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
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
                rb.AddExplosionForce(power, explosion, radius, upForce, ForceMode.Impulse);
            if ( hit.gameObject.layer == LayerMask.NameToLayer("SlimeEvil") ) {
                Slime obj = hit.GetComponent<Slime>();
                obj.RangeDamage(this, obj);
            } else if ( hit.gameObject.layer == LayerMask.NameToLayer("Ghost") ) {
                Ghost2 obj = hit.GetComponent<Ghost2>();
                obj.RangeDamage(this, obj);
            } else if ( hit.gameObject.layer == LayerMask.NameToLayer("Rabbit") ) {
                Rabbit obj = hit.GetComponent<Rabbit>();
                obj.RangeDamage(this, obj);
            } else if ( hit.gameObject.layer == LayerMask.NameToLayer("Bat") ) {
                Bat obj = hit.GetComponent<Bat>();
                obj.RangeDamage(this, obj);
            }
            Destroy(gameObject);
        }
    }
}
