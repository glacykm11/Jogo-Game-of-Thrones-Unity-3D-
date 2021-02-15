using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 20;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    
    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider [] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("We hit"+enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }



    /*
    public Animator anim;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.9f;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 20;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
     }

        if(Input.GetMouseButtonDown(0))
        {
            lastClickedTime = Time.time;
            noOfClicks++;
            if(noOfClicks == 1)
            {
                anim.SetBool("1",true);
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0 , 3);
        }
    }

    public void return1()
    {
        if(noOfClicks >= 2)
        {
            anim.SetBool ("2", true);
        }else
        {
            anim.SetBool ("1", false);
            noOfClicks = 0;
        }
    }

    public void return2()
    {
        if(noOfClicks >= 3)
        {
            anim.SetBool ("3", true);
        }else
        {
            anim.SetBool ("1", false);
            anim.SetBool ("2", false);
            noOfClicks = 0;
        }
    }

    public void return3()
    {
        anim.SetBool ("1", false);
        anim.SetBool ("2", false);
        anim.SetBool ("3", false);
        noOfClicks = 0;
    }

    public void attack()
    {
        Collider [] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }*/
}
