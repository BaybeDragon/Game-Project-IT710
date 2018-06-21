using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public Image blackscreen;
	public Text starttext;
	private AudioSource introvoice;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0f;
		starttext.enabled = true;
		introvoice = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = 0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
			introvoice.Stop ();
            Time.timeScale = 1f;
            Destroy(blackscreen);
			starttext.enabled = false;
            Destroy(this);
        }
    }
}
