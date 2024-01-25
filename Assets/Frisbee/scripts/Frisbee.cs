using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frisbee : MonoBehaviour
{

    private Rigidbody frisbody;
    private Transform catcher;
    private Transform thrower;
    private bool held = true;

    [Header("Throw Parameters")]
    public float impulse = 30;
    public float heightOffset = 0.2f;
    public float widthOffsetRange = 10f;
    public float frisbeeMass = 1;

    // Start is called before the first frame update
    void Start()
    {
        thrower = transform.parent;
        Transform gameParent = transform.parent.parent;
        for (int i = gameParent.childCount - 1; i >= 0; i--)
        {
            Transform t = gameParent.GetChild(i);
            if (t != thrower)
            {
                catcher = t;
                break;
            }
        }
        frisbody = GetComponent<Rigidbody>();
        frisbody.mass = frisbeeMass;
        throwFrisbee();
    }

    private float calculateFlightRange(Vector3 Vx, Vector3 V0)
    {
        float alpha = Vector3.Angle(Vx, V0) * Mathf.Deg2Rad;
        return Mathf.Pow(V0.magnitude, 2) * Mathf.Sin(2 * alpha) / 9.8f;
    }

    private Vector3 splitHypotenuse(float h)
    {
        //split horizontal offset based on rotation
        float angle = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
        return new Vector3(h * Mathf.Sin(angle), 0, h * Mathf.Cos(angle));
    }

    private void throwFrisbee()
    {
        // b - a
        Vector3 a = thrower.position;
        Vector3 b = catcher.position;

        float widthOffset = Random.Range(-widthOffsetRange, widthOffsetRange);

        Vector3 horizontalOffset = splitHypotenuse(widthOffset);

        Vector3 Vx = ((b - a).normalized * impulse) + horizontalOffset;
        Vector3 Vy = new Vector3(0, heightOffset, 0) * impulse;

        // calculate initial velocity of the projectile
        Vector3 V0 = Vx + Vy;

        held = false;
        frisbody.AddForce(V0, ForceMode.Impulse);
        frisbody.useGravity = true;

        float throwRange = calculateFlightRange(Vx, V0);

        catcher.GetComponent<catcher>().chaseFrisbee(throwRange, thrower, Vx);
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.transform == catcher)
        {
            // stop frisbee
            frisbody.useGravity = false;
            frisbody.angularVelocity = Vector3.zero;
            frisbody.velocity = Vector3.zero;
            held = true;
            catcher.GetComponent<catcher>().catchFrisee();

            transform.SetParent(catcher);
            // swapping catcher and thrower
            Transform temp = thrower;
            thrower = catcher;
            catcher = temp;

            StartCoroutine(waitBeforeThrow());
        }
    }

    private void Update()
    {
        if (held)
        {
            Vector3 goTo = thrower.GetComponent<catcher>().getFrisbeePosition();
            transform.position = goTo;
        }
    }

    IEnumerator waitBeforeThrow()
    {
        yield return new WaitForSeconds(2.5f);
        throwFrisbee();
    }
}
