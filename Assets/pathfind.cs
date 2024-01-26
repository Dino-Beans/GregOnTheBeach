
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TestAgentIA : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    NavMeshPath path;
    private float elapsed = 0.0f;
    int index = 0;
    public bool DrawGizmo = false;
    public Color GizmoColor;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        path = new NavMeshPath();
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {


        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
            index = 0;
        }
        MoveToPath();
    }
    void MoveToPath()
    {
        if (path != null && path.corners.Length > 0)
        {
            float distance = (path.corners[index] - transform.position).magnitude;
            if (distance <= agent.stoppingDistance)
            {
                index = (int)Mathf.Clamp(index + 1, 0, path.corners.Length - 1);
            }
            agent.SetDestination(path.corners[index]);
        }
    }
    private void OnDrawGizmos()
    {
        if (!DrawGizmo || path == null) return;
        Gizmos.color = GizmoColor;
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Gizmos.DrawLine(path.corners[i], path.corners[i + 1]);
            if (index != i && index != i + 1)
            {
                Gizmos.DrawSphere(path.corners[i], radius);
                Gizmos.DrawSphere(path.corners[i + 1], radius);
            }

        }
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(path.corners[index], radius);
    }
}