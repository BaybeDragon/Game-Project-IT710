using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Start : MonoBehaviour {

	public Image blackscreen;
	public Text starttext;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
		starttext.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		Time.timeScale = 0f;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Time.timeScale = 1f;
			Destroy(blackscreen);
			starttext.enabled = false;
			Destroy(this);
		}
	}
}
