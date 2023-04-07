using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public float health = 50f;
    KillCounter killCounterScript;
    void Start()
    {
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
        Animator animator = gameObject.GetComponent<Animator>();
    }
    
    public void TakeDamage( float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
            health = 0;
        }
        
        
    }

    

    void Die()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        UnityEngine.AI.NavMeshAgent agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator.SetTrigger("Die");
        agent.enabled = false;
        Destroy(gameObject, 3f);
        killCounterScript.AddKill();
    }
}
