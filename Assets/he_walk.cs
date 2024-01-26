using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class path : MonoBehaviour
{

    [Header("walk Parameters")]
    public float speed = 4f;
    private NavMeshAgent agent;

    [Header("Path Targets")]
    public Transform pointsParent;
    private Transform[] targets;
    [SerializeField]
    private int pointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.enabled = true;
        targets = new Transform[pointsParent.childCount];

        for (int i = 0; i < pointsParent.childCount; i++)
        {
            targets[i] = pointsParent.GetChild(i);
        }



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (agent.enabled)
        {

            if (Vector3.Distance(transform.position, targets[pointIndex].position) < agent.stoppingDistance || !agent.hasPath)
            {
                pointIndex = Random.Range(0, pointsParent.childCount - 1);
                agent.enabled = false;
                StartCoroutine(waitToLeavePoint());
            }
        }

    }

    private void flyTowards(Vector3 aimFor, float flySpeed)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimFor - transform.position, Vector3.up), 4f);
        transform.position = Vector3.MoveTowards(transform.position, aimFor, flySpeed);
    }

    private IEnumerator waitToLeavePoint()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        agent.enabled = true;
        agent.destination = targets[pointIndex].position;
    }

}
