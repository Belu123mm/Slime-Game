using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsPW : basePW
{
    public AudioClip pw;
    void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.tag == "Slime")
        {
            slimeScript.bulletPW = typeOfBullet;
            AudioMananger.instance.PlayPw(pw);
            Destroy(thisPW);
            totalPW++;
        }
    }
}
