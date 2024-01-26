using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class car : MonoBehaviour
{

    [Header("Drive Parameters")]
    public float speed = 10f;
    private NavMeshAgent agent;

    [Header("Path Targets")]
    private Transform[] targets;
    [SerializeField]
    private int pointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.enabled = true;
        targets = new Transform[transform.parent.childCount - 1];
        Debug.Log(targets);

        for (int i = 1; i < transform.parent.childCount; i++)
        {
            targets[i-1] = transform.parent.GetChild(i);
        }
        Debug.Log(targets);

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (agent.enabled)
        {
            
            if (Vector3.Distance(transform.position, targets[pointIndex].position) < agent.stoppingDistance || !agent.hasPath)
            {
                incrementIndex();
                agent.destination = targets[pointIndex].position;
            }
        }

    }

    private void flyTowards(Vector3 aimFor, float flySpeed)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimFor - transform.position, Vector3.up), 4f);
        transform.position = Vector3.MoveTowards(transform.position, aimFor, flySpeed);
    }


    void incrementIndex()
    {
        pointIndex++;
        if (pointIndex > targets.Length -1)
        {
            pointIndex = 0;
        }
    }

}
