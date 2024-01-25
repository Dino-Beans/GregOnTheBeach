using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class flight : MonoBehaviour
{
    [Header("Flight Parameters")]
    public float speed = 10f;
    public int lookDistance = 60;
    private NavMeshAgent agent;

    [Header("Path Targets")]
    [SerializeField]
    private Vector3 target;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    private Transform[] targets;

    private int pointIndex = 0;

    [Header("Player")]
    public Transform player;
    private bool timing = false;
    [SerializeField]
    private float timer;
    public float detectionTime;


    private bool diving = false;
    private bool climbing = false;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.enabled = true;

        targets = new Transform[3] { target1, target2, target3 };

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (agent.enabled)
        {
            if (Vector3.Distance(transform.position, targets[pointIndex].position) < 2 || !agent.hasPath)
            {
                agent.destination = targets[pointIndex].position;
                incrementIndex();
            }

            // player detection
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < lookDistance)
            {
                RaycastHit hit;
                if (timing)
                {
                    timer += Time.deltaTime;
                    if (timer >= detectionTime)
                    {
                        timer = 0;
                        timing = false;

                        if (Physics.Raycast(transform.position, (player.position - transform.position), out hit, lookDistance))
                        {
                            if (hit.transform.tag == "Player")
                            {
                                Debug.DrawRay(transform.position, (player.position - transform.position), Color.red);
                                Debug.Log("dive");
                                diving = true;
                                agent.enabled = false;
                            }
                        }
                    }
                }
                else if (Physics.Raycast(transform.position, (player.position - transform.position), out hit, lookDistance))
                {
                    if (hit.transform.tag == "Player")
                    {
                        timing = true;
                        timer = 0;
                    }
                }
            }
            else if (timing)
            {
                timing = false;
                timer = 0;

            }
        }
        else if (diving)
        {
            flyTowards(player.position, 1f);
            if (transform.position == player.position)
            {
                diving = false;
                climbing = true;
            }
        }
        else if (climbing)
        {
            flyTowards(targets[pointIndex].position, 0.5f);
            if (transform.position == targets[pointIndex].position)
            {
                climbing = false;
                agent.enabled = true;
                incrementIndex();
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
        if (pointIndex > 2)
        {
            pointIndex = 0;
        }
    }

}
