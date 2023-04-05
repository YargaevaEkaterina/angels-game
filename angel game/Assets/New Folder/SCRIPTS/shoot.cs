using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject player;
    public ParticleSystem Flash;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot()
    {
        Flash.Play();

        RaycastHit hit;
       if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range))
       {
            Debug.Log(hit.transform.name);

            target target = hit.transform.GetComponent<target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

       } 

         RaycastHit hitBoss;
       if (Physics.Raycast(player.transform.position, player.transform.forward, out hitBoss, range))
       {
            Debug.Log(hitBoss.transform.name);

            targetBoss targetBoss = hitBoss.transform.GetComponent<targetBoss>();
            if (targetBoss != null)
            {
                targetBoss.TakeDamage(damage);
            }

       } 

    }
}
