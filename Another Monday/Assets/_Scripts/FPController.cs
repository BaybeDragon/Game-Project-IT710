using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FPController : MonoBehaviour {

    public float walkSpeed = 3f;
    public float jumpheight = 3f;
    public float sprintspeed = 6f;
    public bool isWalking;
    public bool isGrounded;

    //These values change the Health Regen Rate
    //These values change the Health Regen Rate
    public float nextHealthRegenTime = 0f;
    public float regenHealthRateMin = 0f;
    public float regenHealthRateMax = 1f;
    public float regenHealtAmountMin = 0f;
    public float regenHealtAmountMax = 5f;
    //These values change the Health Regen Rate
    //These values change the Health Regen Rate



    Rigidbody rb;

    public float playerHealth = 100;

    public Transform rayOrigin;
    public float range = 0.05f;

    public Text htext;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        htext.text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && isGrounded == true)
        {
            rb.velocity = Vector3.zero;
        }

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 inputDirection = input.normalized;

        Vector3 jumping = new Vector3(0, jumpheight, 0);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumping, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(inputDirection * sprintspeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(inputDirection * walkSpeed * Time.deltaTime);
        }
        if (input.magnitude > 0)
        {
            isWalking = true;
            if (Time.time > nextHealthRegenTime)
            {
                nextHealthRegenTime = Time.time + Random.Range(regenHealthRateMin, regenHealthRateMax);
                TakeDamage(-Random.Range(regenHealtAmountMin, regenHealtAmountMax));
            }
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

    public void TakeDamage(float dmg)
    {
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        else
        {
            htext.text = playerHealth.ToString();
            playerHealth -= dmg;
        }
        Debug.Log(playerHealth);

        if (playerHealth <= 0)
        {
            //death screen
            Debug.Log("Boi he ded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
