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
        print("bat");
    }
}