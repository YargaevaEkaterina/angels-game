using System.Threading;
using UnityEngine;

public class targetPlayer : MonoBehaviour
{
    public float health = 50f;
    public Animator anim;
    public int Potion = 5;
    public ParticleSystem FlashHill;
    public GameManager Gam;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f){
            Die();
        }
    }

    void Die ()
    {
        anim.SetTrigger("Die");
        Destroy(gameObject, 4f);
        Gam.EndGame();
    }

    public void TakeHill(float aHill)
    {
        if (Potion > 0){
            health += aHill;
            Potion -= 1;
            FlashHill.Play();
        }
    }

}
