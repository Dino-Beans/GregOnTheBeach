using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    [SerializeField]
    private Animator anim;

    Rigidbody rb;
    public float thrust;

    public float sensitivity = 1000f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            rb.AddForce(transform.forward * thrust * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
    }
}
