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
    public GameObject go;

    // Use this for initialization
    void Start ()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeToEnable += 1 * Time.deltaTime;

        if (timeToEnable >= 5 && !enable)
        {
            ps.Play();
            
            timeToEnable = 0;
            enable = true;
            go = Instantiate(cube);       
            go.transform.position = new Vector3(ps.transform.position.x, ps.transform.position.y, ps.transform.position.z + 5);
                      
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
                Destroy(go.gameObject);
            }
        }

    }
}
