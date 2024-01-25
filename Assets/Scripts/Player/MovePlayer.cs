using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField]
    private Animator anim;

    Rigidbody rb;
    public float thrust = 3200f;
    public float jumpForce = 1000f;

    //public float sensitivity = 1000f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //GOD I HATE THE INPUT SYSTEM UNREAL IS SO MUCH BETTER
        //MAYBE A MORE EFFECIENT WAY TO DO IT!!!


        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            rb.AddForce(transform.forward * thrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalking", true);
            rb.AddForce(transform.forward * thrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalking", true);
            rb.AddForce(transform.forward * thrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
            rb.AddForce(transform.forward * thrust * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        //space = jump and i know its scuffed!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);
        }
       
        //float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        //transform.Rotate(Vector3.up * mouseX);
    }
}
