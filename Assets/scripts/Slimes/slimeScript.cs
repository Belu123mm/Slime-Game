using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
public class slimeScript : Mob {
    //Vectores
    public Vector3 currentDirection;
    public Vector3 forward;
    //Scripts
    public GameObject normalPf;
    public GameObject bigPf;
    public GameObject quickPf;
    public GameObject spinePf;
    Normal nb;
    Normal bb;
    Normal qb;
    Circle sp;
    public crystalScript crystal;
    public catScript cat;
    public finishCrystal finish;
    //Bullets
    public float timerBullets;
    public float bulletsDelay;
    public string bulletPW;
    //Coin
    public Text Textcoin;
    public static int coins;

    public Scene currentScene;

    public GameObject door;

    void Awake() {
        currentScene = SceneManager.GetActiveScene();
        nb = normalPf.GetComponent<Normal>();
        bb = bigPf.GetComponent<Normal>();
        qb = quickPf.GetComponent<Normal>();
        sp = spinePf.GetComponent<Circle>();
    }

    void Start() {
        StartLife(100);
        currentDirection = Vector3.zero;
        bulletPW = "normal";
        nb.discharger = this.gameObject;
        nb.speed = 10;
        nb.dmg = 10;
        nb.delay = 1;

    }

    public override void Update() {
        //Timer bullets
        timerBullets += 1 * Time.deltaTime;

        if ( Textcoin != null )
            Textcoin.text = "Coins: " + coins;

        string sceneName = currentScene.name;

        if ( hp <= 0 ) {
            Stadistics.result = "Game Over";
            if ( sceneName == "1rstLevel" )//Analytics
                Stadistics.Level1();
            else if ( sceneName == "Lvl2" )
                Stadistics.Level2();
            else if ( sceneName == "Challange" )
                Stadistics.Challange();
        }

        //Camara en distintas escenas
        if ( sceneName == "1rstLevel" || sceneName == "Lvl2" )
            Camera.main.transform.position = this.transform.position + new Vector3(0, 25, 0);
        else if ( sceneName == "Challange" )
            Camera.main.transform.position = new Vector3(this.transform.position.x, 100, -77.25f);


        //Movimiento
        if ( currentDirection != Vector3.zero )
            this.transform.forward = currentDirection;
        currentDirection = Vector3.zero;

        Stadistics.lastPw = bulletPW;
        Stadistics.finalLife = hp;
    }

    public void Move( Vector3 direction ) {
        currentDirection += direction;
        this.GetComponent<Rigidbody>().velocity = currentDirection * speed;
    }

    public void Shoot() {
        switch ( bulletPW ) {
            case "normal":
            if ( timerBullets > nb.delay ) {
                nb.DispenseBullets();
                timerBullets = 0;
            }
            break;
            case "big":
            if ( timerBullets > bb.delay ) {
                bb.DispenseBullets();
                timerBullets = 0;
            }
            break;
            case "quick":
            if ( timerBullets > qb.delay ) {
                qb.DispenseBullets();
                timerBullets = 0;
            }
            break;
            case "triple":
            //tb.DispenseBullets();
            break;
            case "circle":
            if ( timerBullets > sp.delay ) {
                sp.DispenseBullets();
                timerBullets = 0;
            }
            break;
        }
    }

    public override void OnCollisionEnter( Collision c ) {
        base.OnCollisionEnter(c);
        if ( c.gameObject.tag == "Cat" )//Chequea esto
        {
            GameObject go = Instantiate(door);
            go.transform.position = new Vector3(135, 2.28f, 62);
        }
        if ( c.gameObject.tag == "Crystal" ) {
            GameObject go = Instantiate(door);
            go.transform.position = new Vector3(270, 2.28f, -338);
        }
        if ( c.gameObject.tag == "Finish" )
            SceneManager.LoadScene("GameOver");


    }

    public override void OnTriggerEnter( Collider c ) {
        if ( c.gameObject.tag == "Lvl2" ) {
            string sceneName = currentScene.name;
            if ( sceneName == "1rstLevel" ) {
                Stadistics.result = "Continue";
                Stadistics.Level1();
                SceneManager.LoadScene("Lvl2");
            }
            if ( sceneName == "Lvl2" ) {
                Stadistics.result = "Continue";
                Stadistics.Level1();
                SceneManager.LoadScene("Challange");
            }
        }
        if ( c.gameObject.tag == "Win" ) {
            Stadistics.result = "Win";
            Stadistics.Challange(); ;
            SceneManager.LoadScene("victoria");
        }
        if ( c.gameObject.tag == "Coin" ) {
            coins++;
            Textcoin.text = "Coins: " + coins;
        }
    }
}

