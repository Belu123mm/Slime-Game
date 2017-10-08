using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalBulletScript : baseBulletScript {
    Camera cam;
    public GameObject normalBulletPrefab;
    // public List<GameObject> listNormalBullets = new List<GameObject>();    //Eliminar balas
    void Start() {

    }
    void Update() {
        this.transform.position += this.transform.forward * Time.deltaTime * speed;
        slimeScript s = GameObject.Find("slime").GetComponent<slimeScript>();
        distance = Vector3.Distance(s.transform.position, this.transform.position);
        if (distance > 20) {
            Destroy(this.gameObject);
        }
    }
    public void Shoot() {   //Raycast        
        cam = FindObjectOfType<Main>().GetComponent<Camera>();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            mouseRay = hit.point;
        //print(mouseRay);// test     De aca sale la posicion del mouse en el mundo

        //Bullet
        PJ = GameObject.FindGameObjectWithTag("Slime");
        Vector3 dir = new Vector3(mouseRay.x, PJ.transform.position.y, mouseRay.z) - PJ.transform.position;
        this.transform.forward = dir;
        this.transform.position = PJ.transform.position;
        GameObject normalBullet = Instantiate(normalBulletPrefab); // BAM
        Stadistics.totalBullets++;

        //Debug
        Debug.DrawRay(PJ.transform.position, dir, Color.white, 10, false);//BLANCO
        //Falta destruccion balas
    }

}
    

