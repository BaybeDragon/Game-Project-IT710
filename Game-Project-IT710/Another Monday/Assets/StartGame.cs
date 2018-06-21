using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public Image blackscreen;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = 0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            Destroy(blackscreen);
            Destroy(this);
        }
    }
}
