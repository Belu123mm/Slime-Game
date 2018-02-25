using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bebes : MonoBehaviour
{
    public float speed;
    public List<Transform> point;
    int pointI;
    public GameObject pointsGroup;
    NavMeshAgent nav;
    // Use this for initialization
    void Start()
    {
        if (pointsGroup.transform.childCount > 0)
        {
            for (int i = 0; i < pointsGroup.transform.childCount; i++)
                point.Add(pointsGroup.transform.GetChild(i));
        }
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (point != null && point.Count > 1)
        {
            if (nav.remainingDistance < .5f)
            {
                pointI++;
                if (pointI >= point.Count)
                    pointI = 0;
            }
            nav.SetDestination(point[pointI].position);
        }
    }
   public void OnCollisionEnter(Collision c)
    {
        nav.SetDestination(point[pointI].position);
    }
}
