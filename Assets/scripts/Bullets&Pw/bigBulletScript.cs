using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBulletScript : baseBulletScript
{
    public GameObject bigBulletPrefab;

	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position += this.transform.forward * Time.deltaTime * speed;
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
        //Raycast        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            mouseRay = hit.point;

        //Bullet
        PJ = GameObject.FindGameObjectWithTag("Slime");
        Vector3 dir = new Vector3(mouseRay.x, PJ.transform.position.y, mouseRay.z) - PJ.transform.position;
        this.transform.forward = dir;
        this.transform.position = PJ.transform.position;
       // GameObject bullets = GameObject.Instantiate(bigBulletPrefab);
        Stadistics.totalBullets++;
        //Debug
        Debug.DrawRay(PJ.transform.position, dir, Color.red, 100, false);//ROJO

    }
}
