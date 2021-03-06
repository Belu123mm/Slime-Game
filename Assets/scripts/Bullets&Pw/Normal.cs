﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : Bullets {
    //La bala rapida funciona desde este script, pero en Slimehero se cambia la velocidad :V
    //Al igual que la big bullet :VVV
    public Vector3 mouseRay;
    Camera cam;

    public void Start() {

    }

    public void Update() {
        this.transform.position += this.transform.forward * Time.deltaTime * speed;

    }
    public override void DispenseBullets() {
        base.DispenseBullets();
        mouseRay = GetRay();
        Vector3 dir = new Vector3(mouseRay.x, discharger.transform.position.y, mouseRay.z) - discharger.transform.position;
        this.transform.forward = dir;
        this.transform.position = discharger.transform.position;
        GameObject normalBullet = Instantiate(this.gameObject); // BAM
        Stadistics.totalBullets++;

        //Debug
        Debug.DrawRay(discharger.transform.position, dir, Color.white, 10, false);//BLANCO

    }

    public Vector3 GetRay() {
        cam = FindObjectOfType<Main>().GetComponent<Camera>();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if ( Physics.Raycast(ray, out hit) ) {

        print(hit.point );
            return hit.point;
        }
        else
            return Vector3.zero;
    }

}
