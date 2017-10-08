using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleBulletScript : baseBulletScript {

    public GameObject circle;
    public float speedOscilation;
    public Vector3 center;
    public float degrees;
    public float radians;
    public float radiusX;
    public float radiusY;
    public int bulletsCount;

    // Use this for initialization
    void Start () {
        center = this.transform.position;        
    }
	
	// Update is called once per frame
	void Update ()
    {
        degrees += 1;

        center += this.transform.forward * speed * Time.deltaTime;

        degrees += speedOscilation * Time.deltaTime;
        radians = degrees * Mathf.Deg2Rad;

        Vector3 realPosition;
        realPosition.x = Mathf.Cos(radians) * radiusX;
        realPosition.y = 0;
        realPosition.z = Mathf.Sin(radians) * radiusY;

        this.transform.position = center + realPosition;

        this.transform.position += this.transform.forward * Time.deltaTime * speed;
        slimeScript s = GameObject.Find("slime").GetComponent<slimeScript>();
        distance = Vector3.Distance(s.transform.position, this.transform.position);
        if (distance > 20)
        {
            Destroy(this.gameObject);
        }
    }
    public void Shoot()
    {
        PJ = GameObject.FindGameObjectWithTag("Slime");
        for (int i = 0; i < 360; i += 360 / bulletsCount)
        {
            Vector3 direction;
            direction.x = Mathf.Cos((i + degrees) * Mathf.Deg2Rad);
            direction.y = 0;
            direction.z = Mathf.Sin((i + degrees) * Mathf.Deg2Rad);

            this.transform.position = PJ.transform.position;
            GameObject bullets = GameObject.Instantiate(circle);
            bullets.transform.forward = direction;
            Stadistics.totalBullets += bulletsCount;
        //Debug
            Debug.DrawRay(PJ.transform.position, bullets.transform.forward , Color.green, 100, false);
        }
    }
}
