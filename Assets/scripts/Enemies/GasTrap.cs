using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTrap : MonoBehaviour
{
    public float timeToEnable;
    public float timeToDesable;
    public bool enable;
    public ParticleSystem ps;
    public GameObject cube;
    public bool challenge;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Stop();

    }
    void Update()
    {
        timeToEnable += 1 * Time.deltaTime;

        if (timeToEnable >= 5 && !enable)
        {
            ps.Play();
            timeToEnable = 0;
            enable = true;
            cube.SetActive(true);
        }
        if (enable)
        {
            timeToDesable += 1 * Time.deltaTime;

            if (timeToDesable > 2)
            {
                ps.Stop();
                timeToDesable = 0;
                timeToEnable = 0;
                enable = false;
                cube.SetActive(false);
            }
        }
    }
}
