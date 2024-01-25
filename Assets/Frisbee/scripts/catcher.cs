using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catcher : MonoBehaviour
{
    private bool hasTarget = false;
    private Vector3 catchTarget;
    public Transform frisbeePosition;
    public Animator animator;
    public float speed;

    public void chaseFrisbee(float throwRange, Transform thrower, Vector3 Vx)
    {
        Vector3 R = Vx.normalized * throwRange;

        catchTarget = thrower.position + R;
        hasTarget = true;
    }

    public Vector3 getFrisbeePosition()
    {
        return frisbeePosition.position;
    }

    public void catchFrisee()
    {
        animator.SetTrigger("catch");
        
    }

    private void Update()
    {
        if (hasTarget)
        {
            float time = Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, catchTarget, speed * time);
            if (catchTarget.x - transform.position.x < 0)
            {
                animator.SetBool("running right", true);
                animator.SetBool("running left", false);
            } 
            else if (catchTarget.x - transform.position.x > 0)
            {
                animator.SetBool("running right", false);
                animator.SetBool("running left", true);
            }
            else
            {
                animator.SetBool("running right", false);
                animator.SetBool("running left", false);
            }
        }
    }
}
