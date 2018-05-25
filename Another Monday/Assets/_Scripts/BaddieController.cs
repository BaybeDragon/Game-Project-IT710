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

    public string AnimWalk = "BaddieWalking";
    public string AnimTrig = "BaddieTriggered";
    public string AnimShoot = "BaddieShoot";


    void Start()
    {
        agent = main.GetComponent<NavMeshAgent>();
        triggered = true;
        anim = GetComponent<Animator>();
        playerScript = player.GetComponent<FPController>();
    }

    void Update()
    {
        transform.LookAt(player.transform.position);
        if (triggered)
        {
            anim.SetBool(AnimTrig, true);
            //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            if (Vector3.Distance(transform.position, player.transform.position) <= range)
            {
                
                anim.SetBool(AnimWalk, false);
                agent.destination = transform.position;
                if (Time.time > nextFire)
                {
                    float acc = Random.Range(0, 100);
                    nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);
                    anim.SetTrigger(AnimShoot);

                    RaycastHit hit;
                    rayOrigin.transform.LookAt(player.transform.position);
                    Ray rayTest = new Ray(rayOrigin.transform.position, rayOrigin.transform.forward);
                    if (Physics.Raycast(rayTest, out hit, 100f))
                    {
                        Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.forward * 100, Color.blue);
                        //Debug.Log("Seen");
                        if (hit.collider.tag == "Player")
                        {
                            if (acc < 80)
                            {

                            }
                        }
                    }
                }
            }
            else
            {
                agent.destination = player.transform.position;
                //anim.SetBool(AnimWalk, true);
            }
        }
    }

    public void Triggered()
    {
        triggered = true;
        nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);
    }
}