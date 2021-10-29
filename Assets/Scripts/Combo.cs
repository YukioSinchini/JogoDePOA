using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public Animator anim;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.9f;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask TestLayers;

    public int attackDamage = 10;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
        {
            lastClickedTime = Time.time;
            noOfClicks++;
            if (noOfClicks == 1)
            {
                anim.SetBool("1", true);
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        }
    }
    public void return1()
    {
        if (noOfClicks >= 2)
        {
            anim.SetBool("2", true);
        }
        else
        {
            anim.SetBool("1", false);
            noOfClicks = 0;
        }
    }
    public void return2()
    {
        if (noOfClicks >= 3)
        {
            anim.SetBool("3", true);
        }
        else
        {
            anim.SetBool("2", false);
            anim.SetBool("1", false);
            noOfClicks = 0;
        }
    }
    public void return3()
    {
        anim.SetBool("1", false);
        anim.SetBool("2", false);
        anim.SetBool("3", false);
        noOfClicks = 0;
    }
    public void attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, TestLayers);

        foreach(Collider Test in hitEnemies)
        {
            Test.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}