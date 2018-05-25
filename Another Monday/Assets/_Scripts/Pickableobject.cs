using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickableobject : MonoBehaviour {

	public Transform TransformCamera;
	public LayerMask RayMask;
	private RaycastHit Hit;

	private Transform currentTransform;
	private float length;
	public float throwingforce = 5f;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)){
			if (Physics.Raycast (TransformCamera.position, TransformCamera.forward, out Hit, 20f, RayMask)) {
				if (Hit.transform.tag == "Pickupobject") {
					SetNewTransform (Hit.transform);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			RemoveTransform (Hit.rigidbody, Hit.collider,Hit.collider.gameObject);
		}

		if (currentTransform) {
			MoveTransformAround ();
		}
	}

	public void SetNewTransform(Transform newTransform){
		if (currentTransform) {
			return;
		}
		currentTransform = newTransform;
		length = Vector3.Distance (TransformCamera.position, newTransform.position);
		//currentTransform.GetComponent<Rigidbody> ().isKinematic = true;
	}

	private void MoveTransformAround(){
		currentTransform.position = TransformCamera.position + TransformCamera.forward * length;
	}

	public void RemoveTransform(Rigidbody rigid, Collider col, GameObject thing){
		if (!currentTransform)
			return;

		//currentTransform.GetComponent<Rigidbody> ().isKinematic = false;
		currentTransform = null;
		rigid.AddForce (TransformCamera.forward * throwingforce);
		thing.tag = "thrown";
	}
}
