using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oceanMove : MonoBehaviour
{
    public int moveAmount;
    public float speedCoefficient;
    private Vector3 highTide;
    private Vector3 lowTide;
    private bool moveUp = true;

    // Start is called before the first frame update
    void Start()
    {
        lowTide = transform.position;
        highTide = transform.position + (Vector3.forward * -moveAmount);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;

        float toHigh = Vector3.Distance(transform.position, highTide);
        float toLow = Vector3.Distance(transform.position, lowTide);
          
        float speed = Mathf.Sqrt(toHigh <= toLow ? toHigh : toLow) * speedCoefficient + 0.01f;

        if (moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, highTide, speed * time);
            if (transform.position == highTide)
            {
                moveUp = false;
            }
        } 
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, lowTide, speed * time);
            if (transform.position == lowTide)
            {
                moveUp = true;
            }
        }
    }
}
