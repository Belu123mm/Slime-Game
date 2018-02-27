using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
using TMPro;
public class slimeScript : Mob
{
    //BALAS 
    //bullets es un diccionario en donde se guardan todos los tipos de balas que hay
    //los GameObject con el sufijo pf son los prefabs de las balas y deben agregarse a este diccionario
    //Bulletname es de donde se selecciona la bala inicial
    //temp bullet es una bala temporal para de esa sacar el componente bullet y trabajar desde el mismo
    //Cuadno inicia la escena en Awake se agregan todos los tipos de balas al diccionario y se inicializan.
    //Al iniciar se cambia la bala con changebullet. ESta funcion esta hecha para cambiar la bala tomando el valor introducido
    //Y buscando en el diccionario una key con ese valor, se busca el componente de temp, se setea el discharguer 
    //Y se actualiza la bala con refrestBullet, tomando los valores agregados al prefab de la bala
    //Los valores addeddmg, addedspeed y restdelay son valores para argegar daño, velocidad y restar delay a la bala
    //Al quitar la aplicacion o cambiar de escena se resetea la bala de nuevo
    //SHoot lo que hace es que si el delay de las balas es menor que el timer, y se llama a esta funcion, dispare.

    // En start se inicia la vida desde startlife con mob

    public Dictionary<BULLETTYPES, GameObject> bullets = new Dictionary<BULLETTYPES, GameObject>();
    public BULLETTYPES bulletName;
    GameObject tempBullet;
    public Bullets currentBulletScript;
    public GameObject normalPf;
    public GameObject bigPf;
    public GameObject quickPf;
    public GameObject spinePf;
    public int addedDmg, addedSpeed;
    public float restDelay;
    public float timerBullets;
    public float bulletsDelay;
    public Slider hpBar;
    //Vectores
    public int coins;
    public Vector3 currentDirection;
    public Vector3 forward;
    //Scripts
    public crystalScript crystal;
    public bool cat;
    public finishCrystal finish;
    //Bullets
    //Coin
    public TextMeshProUGUI Textcoin;
    public Scene currentScene;

    public GameObject door;

    //Pw 
    public bool pwActive;
    public float timerPw;
    public bool bomb;
    public GameObject bombPF;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        bullets.Add(BULLETTYPES.normal, normalPf);
        bullets[BULLETTYPES.normal].GetComponent<Normal>().Initialize();
        bullets.Add(BULLETTYPES.big, bigPf);
        bullets[BULLETTYPES.big].GetComponent<Normal>().Initialize();
        bullets.Add(BULLETTYPES.quick, quickPf);
        bullets[BULLETTYPES.quick].GetComponent<Normal>().Initialize();
        bullets.Add(BULLETTYPES.spine, spinePf);
        bullets[BULLETTYPES.spine].GetComponent<Circle>().Initialize();
    }

    void Start()
    {
        StartLife(100);
        if ( hpBar ) {
        ReziseHpBar(100);
        RefreshHpBar();
        }
        currentDirection = Vector3.zero;
        ChangeBullet(bulletName);
    }

    public override void Update()
    {
        base.Update();
        //Timer bullets
        timerBullets += Time.deltaTime;

        if (Textcoin != null)
            Textcoin.text =  coins + "";

        string sceneName = currentScene.name;

        if (hp <= 0)
        {
            print("Che moriste");
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

        //Movimiento
        if (currentDirection != Vector3.zero)
            this.transform.forward = currentDirection;
        currentDirection = Vector3.zero;

        //  Stadistics.lastPw = currentBulletName;
        Stadistics.finalLife = hp;

        if (pwActive)
        {
            timerPw += Time.deltaTime;
            if (timerPw >5)
            {
                pwActive = false;
                timerPw = 0;
                speed -= addedSpeed;
                dmg -= addedDmg;
            }
        }
    }

    public void OnApplicationQuit()
    {
        currentBulletScript.ResetBulets();
    }

    public void Move(Vector3 direction)
    {
        currentDirection += direction;
        this.GetComponent<Rigidbody>().velocity = currentDirection * speed;
    }

    public void Shoot()
    {
        if (bulletsDelay < timerBullets)
        {
            currentBulletScript.DispenseBullets();
            timerBullets = 0;
        }
    }
    public void Bomb()
    {
        if (bomb) {
            if (bulletsDelay < timerBullets) {
                GameObject go = Instantiate(bombPF);
                go.transform.position = transform.position;
            }
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

        //Verifiqued
        if ( timer > timeToHurt ) {
            if ( c.gameObject.layer == LayerMask.NameToLayer("Bat") ) {
                {
                    Bat temp = c.gameObject.GetComponent<Bat>();
                    MeleeDamage(temp, this);
                }
            }
            if ( c.gameObject.layer == LayerMask.NameToLayer("Ghost") ) {
                {                    Ghost temp = c.gameObject.GetComponent<Ghost>();
                    MeleeDamage(temp, this);
                }
            }
            if ( c.gameObject.layer == LayerMask.NameToLayer("SlimeEvil") ) {
                {
                    Slime temp = c.gameObject.GetComponent<Slime>();
                    MeleeDamage(temp, this);
                }
            }
            if ( c.gameObject.layer == LayerMask.NameToLayer("Rabbit") ) {
                {
                    Rabbit temp = c.gameObject.GetComponent<Rabbit>();
                    MeleeDamage(temp, this);
                }
            }
        }
        if ( c.gameObject.layer == LayerMask.NameToLayer("Winning") ) {
            SceneManager.LoadScene("Victory");
        }
        
    }
    public override void OnTriggerEnter( Collider c ) {
        base.OnTriggerEnter(c);

        if ( c.gameObject.tag == "Lvl2" && cat) {
            string sceneName = currentScene.name;
            if ( sceneName == "Level1") {
                print("Change scene");
              //  Stadistics.result = "Continue";
               // Stadistics.Level1();
                SceneManager.LoadScene("Level2");
            }
            if ( sceneName == "Lvl2" ) {
                Stadistics.result = "Continue";
                Stadistics.Level1();
                SceneManager.LoadScene("Final");
            }
        }

        //Verifiqued
        if ( c.gameObject.tag == "Coin" ) {
            coins++;
            Textcoin.text = "Coins: " + coins;
        }
        if (c.gameObject.layer == LayerMask.NameToLayer("SlimeEvil"))
        {
            {
                Slime temp = c.gameObject.GetComponent<Slime>();
                MeleeDamage(temp, this);
            }
        }
    }
public void ChangeBullet(BULLETTYPES bulletName)
    {
        tempBullet = bullets[bulletName];
        print(tempBullet);
        switch (bulletName)
        {
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
        RefreshBullet();
    }

    public void RefreshBullet()
    {
        currentBulletScript.delay -= restDelay;
        currentBulletScript.dmg += addedDmg;
        currentBulletScript.speed += addedSpeed;
        bulletsDelay = currentBulletScript.delay;
    }
    public override void Death() {
        base.Death();
        //Cambio de escena
    }
    public override void MeleeDamage( Mob atac, Mob vict ) {
        base.MeleeDamage(atac, vict);
        RefreshHpBar();
    }
    public override void RangeDamage( Bullets atac, Mob vict ) {
        base.RangeDamage(atac, vict);
        RefreshHpBar();
    }
    public void RefreshHpBar() {
        hpBar.value = hp;
    }
    public void ReziseHpBar(int value) {
        hpBar.maxValue = value;
    }
}

public enum BULLETTYPES
{
    normal,
    quick,
    spine,
    big
}