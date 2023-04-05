using System.Threading;
using UnityEngine;

public class target : MonoBehaviour
{
    public float health = 50f;
    public Animator anim;


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
    }


}
