using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private UnityEngine.AI.NavMeshAgent navMesh;
    public int maxHealth = 30;
    private int currentHealth;
    private bool CanAttack;

    public Animator anim;

    void Start()
    {
        CanAttack = true;
        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentHealth = maxHealth;    
    }
    
    void update()
    {
        navMesh.destination = player.transform.position;
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (CanAttack == true)
        {
            StartCoroutine("TimeToAttack");
            player.GetComponent<PlayerController>().Life -= 10;
        }
    }

    IEnumerator TimeToAttack()
    {
        CanAttack = false;
        yield return new WaitForSeconds(1);
        CanAttack = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        anim.SetBool("Die", true);

        GetComponent<BoxCollider>().enabled = false;
        this.enabled = false;
    }
}
