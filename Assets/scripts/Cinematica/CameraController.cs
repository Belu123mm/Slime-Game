using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public float timer;
    public float timer2;
    public float offSet;
    public float upOffset;
    public float positionSpeed;
    public float rotationSpeed;
    void Update()
    {
        if (!SlimeCinematica.scream)
        {
            transform.position = Vector3.Lerp(transform.position, target1.up * upOffset + target1.position - target1.forward * offSet, positionSpeed * Time.deltaTime);
            transform.forward = Vector3.Slerp(transform.forward, target1.position - transform.position, rotationSpeed * Time.deltaTime);

        } else
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer2 += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, target2.up * upOffset + target2.position - target2.forward * offSet, positionSpeed * Time.deltaTime);
                transform.forward = Vector3.Slerp(transform.forward, target2.position - transform.position, rotationSpeed * Time.deltaTime);
                if(timer2 > 2)
                {
                    positionSpeed = 0;
                    rotationSpeed = 0;
                }
            }

        }

    }
}
