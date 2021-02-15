using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger ("Hurt");
        
        if (currentHealth<=0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        //Die anim
        anim.SetBool("Die", true);

        //Disable Enemy
        GetComponent<BoxCollider>().enabled = false;
        this.enabled = false;
    }
}
