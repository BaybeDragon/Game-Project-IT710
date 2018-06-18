using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour {

    public Image endGame;
    public Image disret;

    float health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            disret.enabled = false;
            endGame.enabled = true;
            Time.timeScale = 0f;
        }
	}



    public void TakeDamage(int dmg)
    {
        health -= dmg;

    }
}
