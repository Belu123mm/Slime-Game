using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
public class slimeScript : Mob {
    public Dictionary<BULLETTYPES,GameObject> bullets = new Dictionary<BULLETTYPES,GameObject>();
    public BULLETTYPES bulletName;
    GameObject tempBullet;
    Bullets currentBulletScript;
    public GameObject normalPf;
    public GameObject bigPf;
    public GameObject quickPf;
    public GameObject spinePf;
    //Vectores
    public Vector3 currentDirection;
    public Vector3 forward;
    //Scripts
    public crystalScript crystal;
    public catScript cat;
    public finishCrystal finish;
    //Bullets
    public float timerBullets;
    public float bulletsDelay;
    //Coin
    public Text Textcoin;
    public static int coins;

    public Scene currentScene;

    public GameObject door;

    void Awake() {
        currentScene = SceneManager.GetActiveScene();
        bullets.Add(BULLETTYPES.normal, normalPf);
        bullets.Add(BULLETTYPES.big, bigPf);
        bullets.Add(BULLETTYPES.quick, quickPf);
        bullets.Add(BULLETTYPES.spine, spinePf);
    }
    void Start() {
        StartLife(100);
        currentDirection = Vector3.zero;
        ChangeBullet(bulletName);

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

      //  Stadistics.lastPw = currentBulletName;
        Stadistics.finalLife = hp;
    }

    public void Move( Vector3 direction ) {
        currentDirection += direction;
        this.GetComponent<Rigidbody>().velocity = currentDirection * speed;
    }

    public void Shoot() {
        if (bulletsDelay < timerBullets ) {
        currentBulletScript.DispenseBullets();
            timerBullets = 0;
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
    public void ChangeBullet(BULLETTYPES bulletName) {
        tempBullet = bullets [ bulletName ];

        switch ( bulletName ) {
            case BULLETTYPES.normal:
            currentBulletScript = tempBullet.GetComponent<Normal>();
            break;
            case BULLETTYPES.quick:
            currentBulletScript = tempBullet.GetComponent<Normal>();
            break;
            case BULLETTYPES.big:
            currentBulletScript = tempBullet.GetComponent<Normal>();
            break;
            case BULLETTYPES.spine:
            currentBulletScript = tempBullet.GetComponent<Circle>();
            break;
        }
        currentBulletScript.discharger = this.gameObject;
        bulletsDelay = currentBulletScript.delay;
        print(tempBullet);
    }


}

public enum BULLETTYPES {
    normal,
    quick,
    spine,
    big
}