using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaddieController : MonoBehaviour
{
    public GameObject main;
    public GameObject rayOrigin;
    public GameObject player;
    public float range = 10;

    bool triggered;
    Animator anim;
    public float fireRateMin = 0.25f;
    public float fireRateMax = 1.5f;
    private float nextFire = 0f;
    FPController playerScript;
    NavMeshAgent agent;


    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        triggered = true;
        anim = GetComponent<Animator>();
        playerScript = player.GetComponent<FPController>();
    }

    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x,this.transform.position.y, player.transform.position.z));
        
        if (triggered)
        {
            //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            agent.destination = transform.position;
            if (Time.time > nextFire)
            {
                float acc = Random.Range(0, 100);
                nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);

                RaycastHit hit;
                rayOrigin.transform.LookAt(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));
                Ray rayTest = new Ray(rayOrigin.transform.position, rayOrigin.transform.forward);
                if (Physics.Raycast(rayTest, out hit, 100f))
                {
                    Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.forward * 100, Color.blue);
                    //Debug.Log("Seen");
                    if (hit.collider.tag == "Player")
                    {
                        if (acc < 75)
                        {
                            Debug.Log("Bang!");
                            playerScript.TakeDamage(10);
                        }
                    }
                    Debug.Log(hit.collider.tag);
                }
            }
        }
    }

    public void Triggered()
    {
        triggered = true;
        nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);
    }
}