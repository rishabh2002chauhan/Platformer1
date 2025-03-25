using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float attackCooldown;
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
    }
}
