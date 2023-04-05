using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy : MonoBehaviour
{
    public GameObject player;
    public float dist;
    NavMeshAgent nav; 
    private Animator anim;
    public ParticleSystem DamageFlash;
    public float timer = 0f; 
    public float timerDef = 3f; 
    public float damage = 1f;

    public float range = 100f;
    public float Radius = 15f;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist = Vector3.Distance (player.transform.position, transform.position);
        if (dist >Radius) {
            nav.enabled = false;
            anim.SetTrigger("idle");
        }
        if (dist <Radius & 1<dist) {
            nav.enabled = true;
            nav.SetDestination (player.transform.position);
            anim.SetTrigger("run");
        }
        if (dist<1)
        {
            anim.SetTrigger("idle");
            if(timer<=0){
                DamageFlash.Play();
                nav.enabled = false;
                anim.SetTrigger("attack");
                Shoot();
                timer = timerDef;
            }
            else{
                timer-=Time.deltaTime;
            }
       
        }

        void Shoot()
    {
        RaycastHit hit;
       if (Physics.Raycast(transform.position, transform.forward, out hit, range))
       {
            Debug.Log(hit.transform.name);

            targetPlayer targetPlayer = hit.transform.GetComponent<targetPlayer>();
            if (targetPlayer != null)
            {
                targetPlayer.TakeDamage(damage);
            }
            
       } 
    }

    }
}
