using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bat : Enemy
{
    //Esta es la clase que maneja al murcielago. El movimiento del mismo se guia por NavMeshAgent.
    //Segun un objeto con puntos, el murcielago sigue su camino segun su orden.
    //Solo behaviour

    public GameObject pointsGroup;
    public List<Transform> point;
    NavMeshAgent navEnemy;
    int poitI;

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
        if (Vision() < visionRange)
        {
            if (point != null && point.Count > 1)
            {         //Chequeo de puntos
                if (navEnemy.remainingDistance < .5f)
                {
                    poitI++;
                    if (poitI >= point.Count)
                        poitI = 0;
                }
                navEnemy.SetDestination(point[poitI].position);
            }
        }
    }
    public override void SetEasy()
    {
        base.SetEasy();
        StartLife(30);
        dmg = 10;
        speed = 3;
    }
    public override void SetMedium()
    {
        base.SetMedium();
        hp = 40;
        dmg = 15;
        speed = 5;
    }
    public override void SetHard()
    {
        base.SetHard();
        hp = 55;
        dmg = 20;
        speed = 7;
    }
}