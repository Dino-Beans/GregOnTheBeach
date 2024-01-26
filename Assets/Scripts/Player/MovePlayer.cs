using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField]
    private Animator anim;

    [SerializeField] GameObject PauseMenu;
    public GameObject footstep;

    Rigidbody rb;
    public float thrust = 3200f;
    public float jumpForce = 1000f;

    public float sensitivity = 1000f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        footstep.SetActive(false);
    }

    void Update()
    {
        //GOD I HATE THE INPUT SYSTEM UNREAL IS SO MUCH BETTER
        //THIS IS SO BAD BUT I COULD NOT GET IT TO WORK WITHOUT DOING SOME DUMBSTUFF I HATE THIS WITH A BURNING PASSION
        //arrrrrrrrrrrrrrrrrrrrrrrrrrrrrggggggggggggggghhhhhhhhhhhhhhhhh
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            rb.AddForce(transform.forward * thrust * Time.deltaTime);
            footstep.SetActive(true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            footstep.SetActive(false);
        }


        //Turn Player
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
    }
}
