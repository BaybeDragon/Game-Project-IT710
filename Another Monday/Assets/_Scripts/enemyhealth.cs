using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{

    public float health = 100;
    Animator anim;
    enemyhealth hea;
    BaddieController cont;
    CapsuleCollider cc;

    // Use this for initialization
    void Start()
    {
        cc = this.GetComponent<CapsuleCollider>();
        anim = this.GetComponent<Animator>();
        hea = this.GetComponent<enemyhealth>();
        cont = this.GetComponent<BaddieController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(anim);
            Destroy(hea);
            Destroy(cont);
            Destroy(cc);
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
