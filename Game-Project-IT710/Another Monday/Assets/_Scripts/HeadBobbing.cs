using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour {

	public float timer = 0.0f;
	public float bobbingSpeed = 0.18f;
	public float bobbingAmount = 0.2f;
	public float midpoint = 0.5f;
	FPController player;

	void Start(){
		player = GameObject.Find ("Player").GetComponent<FPController> ();
	}

	// Update is called once per frame
	void Update () {
		if (player.isGrounded) {

			if (Input.GetKey(KeyCode.LeftShift)){
				bobbingSpeed = 0.3f;
			} else {bobbingSpeed = 0.18f;}
			float waveslice = 0.0f;
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");

			Vector3 cSharpConversion = transform.localPosition;

			if (Mathf.Abs (horizontal) == 0 && Mathf.Abs (vertical) == 0) {
				timer = 0.0f;
			} else {
				waveslice = Mathf.Sin (timer);
				timer = timer + bobbingSpeed;
				if (timer > Mathf.PI * 2) {
					timer = timer - (Mathf.PI * 2);
				}
			}

			if (waveslice != 0) {
				float translatChange = waveslice * bobbingAmount;
				float totalAxes = Mathf.Abs (horizontal) + Mathf.Abs (vertical);
				totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f);
				translatChange = totalAxes * translatChange;
				cSharpConversion.y = midpoint + translatChange;
			} else {
				cSharpConversion.y = midpoint;
			}
			transform.localPosition = cSharpConversion;
		}
	}
}
