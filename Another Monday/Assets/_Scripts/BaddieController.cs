using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaddieController : MonoBehaviour
{
    public GameObject rayOrigin;
    public GameObject player;
    float range = 30;

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
            agent.destination = player.transform.position;
            if (Vector3.Distance(player.transform.position, this.transform.position) <= 21)
            {
                agent.destination = this.transform.position;
                anim.SetBool("TooClose", true);
            }
            else
            {
                agent.destination = player.transform.position;
                anim.SetBool("TooClose", false); 
            }



            if (Time.time > nextFire)
            {
                float acc = Random.Range(0, 100);
                nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);

                RaycastHit hit;
                rayOrigin.transform.LookAt(new Vector3(player.transform.position.x,     7, player.transform.position.z));
                Ray rayTest = new Ray(rayOrigin.transform.position, rayOrigin.transform.forward);
                if (Physics.Raycast(rayTest, out hit, range))
                {
                    Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.forward * range, Color.blue);
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