using System.Threading;
using UnityEngine;

public class targetBoss : MonoBehaviour
{
    public float health = 50f;
    public Animator anim;
    public GameObject Plane;


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f){
            Die();
        }
    }

    void Die ()
    {
        anim.SetTrigger("die");
        Destroy(gameObject, 4f);
        Plane.SetActive(false);
    }


}
