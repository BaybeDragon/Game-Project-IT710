using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPController : MonoBehaviour {

    public float walkSpeed = 3f;
    public float jumpheight = 3f;
    public float sprintspeed = 6f;
    public bool isWalking;
    public bool isGrounded;
    Rigidbody rb;

    public int playerHealth = 100;

    public Transform rayOrigin;
    public float range = 0.05f;

    public Text htext;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        htext.text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && isGrounded == true) {
            rb.velocity = Vector3.zero;
        }

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 inputDirection = input.normalized;

        Vector3 jumping = new Vector3(0, jumpheight, 0);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(jumping, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            transform.Translate(inputDirection * sprintspeed * Time.deltaTime);
        } else {
            transform.Translate(inputDirection * walkSpeed * Time.deltaTime);
        }
        if (input.magnitude > 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        //GroundCheck ();
    }

    void GroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, Vector3.down, out hit, range)) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }

    public void TakeDamage(int dmg)
    {
        playerHealth -= dmg;
        htext.text = playerHealth.ToString();

        if (playerHealth >= 0)
        {
            //death screen
            Debug.Log("Boi he ded");

        }
    }


	/*
    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
         if (isGrounded)
        {
            isGrounded = false;
        }
    }*/
}
