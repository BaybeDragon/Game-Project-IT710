using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrownobject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(){
		if (this.tag == "thrown") {
			this.tag = "Pickupobject";
		}
	}
}
