using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	Animator anim;
	public float speed = 0.1f;
	public bool pistol;
	Vector3 velocity;

	int jumpHash = Animator.StringToHash("Jump");
	int sprintHash = Animator.StringToHash("Sprint");

	bool holdingHandgun;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();

	}

	void Update () 
	{
		Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		Vector3 direction = input.normalized;
		velocity = direction * speed;

		//jump trigger on space
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			anim.SetTrigger (jumpHash);
		}

		//sprint trigger on L-shift
		if (Input.GetKey (KeyCode.LeftShift))
		{
			anim.SetTrigger (sprintHash);
		}

        //weapon swap
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!holdingHandgun)//select handgun
            {
                anim.SetLayerWeight(1, 1.0f);
                holdingHandgun = true;

                Debug.Log("handgun");

            }
            else
            {
                anim.SetLayerWeight(2, 0.0f);
                anim.SetLayerWeight(1, 0.0f);
                holdingHandgun = false;

                Debug.Log("unarmed");

            }
        }
	}

	void FixedUpdate () 
	{
		float v = Input.GetAxisRaw ("Vertical");
		anim.SetFloat ("SpeedV", v);
		float h = Input.GetAxisRaw ("Horizontal");
		anim.SetFloat ("SpeedH", h);
		transform.Translate (velocity);
	}
}
