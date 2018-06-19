using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	public void PlayGame()
	{
		Debug.Log ("start scene");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

	}

	public void QuitGame()
	{
		Debug.Log ("quit");
		Application.Quit ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
