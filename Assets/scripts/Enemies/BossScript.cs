using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossScript : MonoBehaviour
{
    public float speed;
    public float currentspeed;
    public float maxSpeed;
    public slimeScript slimeHero;
    public float distance;
    private void Start()
    {
        slimeHero = FindObjectOfType<slimeScript>();
    }
    void Update()
    {
        this.transform.position += Vector3.right * Time.deltaTime * currentspeed;
        distance = Vector3.Distance(slimeHero.transform.position, transform.position);
        if (distance > 25)
            currentspeed = maxSpeed;
        else currentspeed = speed;
    }

    public void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.layer == LayerMask.NameToLayer("SlimeHero"))
            SceneManager.LoadScene("GameOver");
        if (c.gameObject.layer == LayerMask.NameToLayer("Stop"))
        {
            print("aa");
            currentspeed = 0;
        }
    }
    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Stop"))
        {
            speed = 0;
            print("bb");
        }
        if (c.gameObject.layer == LayerMask.NameToLayer("SlimeHero"))
            SceneManager.LoadScene("GameOver");
    }
}
