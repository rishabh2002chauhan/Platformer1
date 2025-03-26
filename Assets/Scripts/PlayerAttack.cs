using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        if ( Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        cooldownTimer = 0;

        int fireballIndex = FindFireball();
        fireballs[fireballIndex].transform.position = firePoint.position;
        fireballs[fireballIndex].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for(int i=0; i<fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }

        return 0;
    }
}
