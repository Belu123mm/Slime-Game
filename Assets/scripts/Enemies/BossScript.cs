using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossScript : MonoBehaviour
{
    public float speed;
	
	void Update ()
    {
        this.transform.position += Vector3.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision c) {
        
        if (c.gameObject.layer == LayerMask.NameToLayer("SlimeHero"))
            SceneManager.LoadScene("GameOver");
    }    
}
