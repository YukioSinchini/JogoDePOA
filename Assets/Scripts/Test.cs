using System.Collections;
using UnityEngine;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Test : MonoBehaviour
{
    public float Speed;
    public int Life = 30;
    private int currentHealth;
    private GameObject player;
    private UnityEngine.AI.NavMeshAgent navMesh;
    private bool CanAttack;

    public Animator anim;

    void Start()
    {
        CanAttack = true;
        player = GameObject.FindWithTag ("Player");
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentHealth = Life;
    }
    
    void Update()
    {
        navMesh.destination = player.transform.position;
        if (Vector3.Distance(transform.position,player.transform.position) < 1.5f)
        {
            Attack();
        }
        if (Life <= 0)
        {
            Life = 0;
            Die();
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        anim.SetBool("Die", true);
    }

        IEnumerator TimeToAttack()
    {
        CanAttack = false;
        yield return new WaitForSeconds(1);
        CanAttack = true;
    }
}
