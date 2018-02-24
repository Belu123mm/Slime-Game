using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossScript : MonoBehaviour {
    public float speed;
    public float timer;
    public float maxSpeed;
    public float minSpeed;
    public float normalSpeed;

    void Update() {
        speed = normalSpeed;
        // timer += 1 * Time.deltaTime;
        this.transform.position += Vector3.right * Time.deltaTime * speed;

    }

    private void OnTriggerEnter( Collider c ) {
        if ( c.gameObject.tag == "Doblar" ) {
            print("ASDASDASD");
            this.transform.Rotate(Vector3.left * Time.deltaTime);
        }
        if ( c.gameObject.tag == "Slime" )
            SceneManager.LoadScene("GameOver");

    }


}
