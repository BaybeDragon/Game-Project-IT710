using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{

    public float health = 100;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;

    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "thrown")
        {
            health = health - 50;
            Debug.Log(health);
        }
    }

    public void shockwave()
    {
        health = health - 100;
    }
}
