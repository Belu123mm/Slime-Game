using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bat : baseEnemy {
    public GameObject pointsGroup;
    public List<Transform> point;
    NavMeshAgent navEnemy;
    int poitI;


    public override void Start() {
        base.Start();
        if ( pointsGroup.transform.childCount > 0 )//Points
        {
            for ( int i = 0; i < pointsGroup.transform.childCount; i++ )
                point.Add(pointsGroup.transform.GetChild(i));
        }
        navEnemy = GetComponent<NavMeshAgent>();//Navmesh

    }

    public override void Update() {
        base.Update();
        if ( point != null && point.Count > 1 )//Chequeo de puntos
{
            if ( navEnemy.remainingDistance < .5f ) {
                poitI++;
                if ( poitI >= point.Count )
                    poitI = 0;
            }
            navEnemy.SetDestination(point [ poitI ].position);
        }

    }

    public override void SetEasy() {//no hace falta rellamarlo aqui, aunque este el override
        base.SetEasy();
        vida = 30;                  //Como cambiar la velocidad del bicho?
        enemyDamage = 10;
    }
    public override void SetMedium() {
        base.SetMedium();
        vida = 40;
        enemyDamage = 15;
    }
    public override void SetHard() {
        base.SetHard();
        vida = 55;
        enemyDamage = 20;
    }
}