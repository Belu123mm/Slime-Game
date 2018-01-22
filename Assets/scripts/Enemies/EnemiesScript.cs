using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesScript : MonoBehaviour
{   
    //Variables
    public int vida = 75;
    public float distance;
    public Material[] enemyMaterial;
    public GameObject enemy;
    public GameObject pointsGroup;
    public GameObject enemyRenderer;
    //DropCoin
    public GameObject coin;
    public int probability;
    //Puntos
    public List<Transform> point;    
    int poitI;
    NavMeshAgent navEnemy;
    //Timer
    public float timer;
    public int timerChange;
    //Sounds
    public AudioClip sEnemy;
    public AudioClip enemyHurt;


    public enum ENEMYTYPE {
        Easy,
        Medium,
        Hard,
    }

    public ENEMYTYPE eType;

    public virtual void Start()
    {
        timerChange = Random.Range(1, 5);//Timer
        if (pointsGroup.transform.childCount > 0)//Points
        {
            for (int i = 0; i < pointsGroup.transform.childCount; i++)            
                point.Add(pointsGroup.transform.GetChild(i));            
        }        
        enemyRenderer.GetComponent<Renderer>().material = enemyMaterial[Random.Range(0, enemyMaterial.Length)];//Random skins
        navEnemy = GetComponent<NavMeshAgent>();//Navmesh

        Invoke("Set" + eType, 1);
    }
    void Update()
    {       
        timer = Time.deltaTime;//Timer sonidos
        if (point != null && point.Count > 1)//Chequeo de puntos
        {
            if (navEnemy.remainingDistance < .5f)
            {
                poitI++;
                if (poitI >= point.Count)
                    poitI = 0;
            }
            navEnemy.SetDestination(point[poitI].position);
        }         
        slimeScript a = GameObject.Find("slime").GetComponent<slimeScript>();//Slime     
        distance = Vector3.Distance(a.transform.position, this.transform.position);//Distancia       
        if (distance < 9)//Check Distance
            navEnemy.destination = a.transform.position;
        else
            navEnemy.SetDestination(point[poitI].position);
        if (vida <= 0)
        {
            probability = Random.Range(0, 100);
            if (probability > 65)
            {
                GameObject go = Instantiate(coin);
                go.transform.position = this.transform.position;
            }     
            Destroy(this.gameObject);
            Stadistics.enemiesKilled++;
        }
    }
    void OnCollisionEnter(Collision c) //Colision
    {
        navEnemy.SetDestination(point[poitI].position);

        if (c.gameObject.tag == "BulletNormal")
            vida = vida - 10;
        if (c.gameObject.tag == "BulletRapida")
            vida = vida - 5;
        if (c.gameObject.tag == "BulletBig")
            vida = vida - 25;
        if (c.gameObject.tag == "BulletCircular")
            vida = vida - 15;
        AudioMananger.instance.PlayEnemyHurt(enemyHurt);
    }

    void SetEasy() { //Velocidad, puntos, vida
        print("easy");
    }
    void SetMedium() {
        print("medium");
    }
    void SetHard() {
        print("hard");
    }
}

