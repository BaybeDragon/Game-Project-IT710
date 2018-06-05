using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject[] bulletHole;
    public float range;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * range;
        RaycastHit hit;
        Debug.DrawRay(transform.position, fwd, Color.green);

        if (Input.GetButtonDown("Fire1") && Physics.Raycast(transform.position, fwd, out hit, range))
        {
            Debug.Log("We hit something");
            if (hit.collider.tag == "enemy")
            {
                Debug.Log(hit.collider.tag);
                enemyhealth ehit = hit.collider.GetComponent<enemyhealth>();
                ehit.TakeDamage(51);
            }
            else
            {
                Instantiate(bulletHole[Random.Range(0, bulletHole.Length)], hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }

        }
    }
}


