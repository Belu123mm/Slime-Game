using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost2 : Enemy {

    public GameObject pointsGroup;
    public List<Transform> point;
    NavMeshAgent navEnemy;
    int pointI;
    public static bool cMurio;

    public float distance;

    public override void Awake()
    {
        base.Awake();
        navEnemy = GetComponent<NavMeshAgent>();        //Navmesh
    }

    public override void Start()
    {
        base.Start();
        if (pointsGroup.transform.childCount > 0)
        {   //Points
            for (int i = 0; i < pointsGroup.transform.childCount; i++)
                point.Add(pointsGroup.transform.GetChild(i));
        }
        navEnemy.speed = speed;                         //Set de velocidad
    }

    public override void Update()
    {
        base.Update();
        if (this.gameObject != null && !cMurio)
        {
            if (Vision() < visionRange)
            {
                if (point != null && point.Count > 1)
                {         //Chequeo de puntos
                    if (navEnemy.remainingDistance < .5f)
                    {
                        pointI++;
                        if (pointI >= point.Count)
                            pointI = 0;
                    }
                    navEnemy.SetDestination(point[pointI].position);
                }
                distance = Vector3.Distance(slimeHero.transform.position, this.transform.position);//Distancia       
                if (distance < 5)//Check Distance
                    navEnemy.destination = slimeHero.transform.position;
                else
                    navEnemy.SetDestination(point[pointI].position);
            }
        }
    }
    public override void SetEasy()
    {
        base.SetEasy();
        hp = 30;
        speed = 5;
    }
    public override void SetMedium()
    {
        base.SetMedium();
        hp = 40;
        speed = 3;
    }
    public override void SetHard()
    {
        base.SetHard();
        hp = 55;
        speed = 4;
    }
}
