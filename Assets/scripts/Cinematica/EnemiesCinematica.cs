using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesCinematica : MonoBehaviour
{
    public int speed;
    public float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SlimeCinematica.scream)
        {
            timer += Time.deltaTime;
            if (timer > 2)
                transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Change")
            SceneManager.LoadScene("Menu");

    }
}
