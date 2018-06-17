using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionpower : MonoBehaviour {

	public float radius = 5.0f;
	public float power = 10.0f;
	private Vector3 explosionPos;
	public float rechargetime = 2f;
	public float waittime = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q) && waittime < 0) {
			explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			foreach (Collider hit in colliders) {
				Rigidbody rb = hit.GetComponent<Rigidbody> ();
				if (rb != null && rb.gameObject.tag != "Player") {
					rb.AddExplosionForce (power, explosionPos, radius, 3.0f);
					if (rb.gameObject.tag == "enemy") {
						rb.gameObject.SendMessage ("shockwave");
					}
				}
			}
			waittime = rechargetime;
		}

		if (waittime > -1) {
			waittime -= Time.deltaTime;
		}
	}
}
