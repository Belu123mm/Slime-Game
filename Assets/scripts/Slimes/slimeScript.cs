using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
public class slimeScript : Mob
{   
    //Vectores
    public Vector3 currentDirection;
    public Vector3 forward;
    //Scripts
    public normalBulletScript nb;    
    public bigBulletScript bb;
    public quickBulletScript qb;
    public tripleBulletScript tb;
    public circleBulletScript cb;
    public crystalScript crystal;
    public catScript cat;
    public finishCrystal finish;
    //Vida
    //Bullets
    public float timerBullets;
    public float bulletsDelay;
    public static string bulletPW;
    //Sonidos
    public AudioClip slimeWalk;
    public AudioClip slimeHurt;
    public AudioClip normalBullet;
    public AudioClip bigBullet;
    public AudioClip circleBullet;
    public AudioClip quickBullet;
    //Vida
    //Coin
    public Text Textcoin;
    public static int coins;
 
    public Scene currentScene;

    public GameObject door;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void Start()
    {
        StartLife(100);
        currentDirection = Vector3.zero;
        bulletPW = "normal";
    }

   public override void Update()
    {
        if (Textcoin != null)
            Textcoin.text = "Coins: " + coins;

        string sceneName = currentScene.name;

        if (hp <= 0)
        {
            Stadistics.result = "Game Over";
            if (sceneName == "1rstLevel")//Analytics
                Stadistics.Level1();
            else if (sceneName == "Lvl2")
                Stadistics.Level2();
            else if (sceneName == "Challange")
                Stadistics.Challange();
        }

        //Camara en distintas escenas
        if (sceneName == "1rstLevel" || sceneName == "Lvl2")
            Camera.main.transform.position = this.transform.position + new Vector3(0, 25, 0);
        else if (sceneName == "Challange")
            Camera.main.transform.position = new Vector3(this.transform.position.x, 100, -77.25f);

        //Timer bullets
        timerBullets += 1 * Time.deltaTime;

        //Movimiento
        if (currentDirection != Vector3.zero)
            this.transform.forward = currentDirection;
        currentDirection = Vector3.zero;

        Stadistics.lastPw = bulletPW;
        Stadistics.finalLife = hp;
    }

    #region movement
    public void Move(Vector3 direction) //Movimiento slime
    {
        currentDirection += direction;
        this.GetComponent<Rigidbody>().velocity = currentDirection * speed;
    }
    #endregion

    #region shoot
    public void Shoot() //Disparos
    {
        switch (bulletPW)
        {
            case "normal":
            if (timerBullets > nb.bulletsDelay)
                {
                    nb.Shoot();
                    timerBullets = 0;
                    AudioMananger.instance.PlayNormalBullet(normalBullet);
                }
            break;
            case "big":
            if (timerBullets > bb.bulletsDelay)
            {
                bb.Shoot();
                timerBullets = 0;
                AudioMananger.instance.PlayBigBullet(bigBullet);
            }
            break;
            case "quick":
            if (timerBullets > qb.bulletsDelay)
            {
                qb.Shoot();
                timerBullets = 0;
                AudioMananger.instance.PlayQuickBullet(quickBullet);
            }
            break;
            case "triple":
            tb.Shoot();
            break;
            case "circle":
            if (timerBullets > cb.bulletsDelay)
            {
                cb.Shoot();
                timerBullets = 0;
                AudioMananger.instance.PlayCircleBullet(circleBullet);
            }
            break;
        }
    }
    #endregion

    #region Colisiones
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

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Lvl2")
        {
            string sceneName = currentScene.name;
            if (sceneName == "1rstLevel")
            {
                Stadistics.result = "Continue";
                Stadistics.Level1();
                SceneManager.LoadScene("Lvl2");
            }
            if (sceneName == "Lvl2")
            {
                Stadistics.result = "Continue";
                Stadistics.Level1();
                SceneManager.LoadScene("Challange");
            }
        }
        if (c.gameObject.tag == "Win")
        {
            Stadistics.result = "Win";
            Stadistics.Challange(); ;
            SceneManager.LoadScene("victoria");
        }
        if (c.gameObject.tag == "Coin")
        {
            coins++;
            Textcoin.text = "Coins: " + coins;
        }
    }

    }
    #endregion
}