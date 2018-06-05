using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrownobject : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision col)
    {
        if (this.tag == "thrown")
        {

            if (col.collider.tag == "enemy")
            {
                enemyhealth ehit = col.collider.GetComponent<enemyhealth>();
                ehit.TakeDamage(101);
            }


            this.tag = "Pickupobject";
        }
    }
}

