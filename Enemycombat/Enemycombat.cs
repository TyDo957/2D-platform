using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycombat : MonoBehaviour
{
    public float attackRange = 5; // Attack range
    public Animator animator; // Enemy animator

    private Transform playerTransform; // Reference to the player
    private bool isAttacking = false; // Flag to track attack state

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Get player reference
    }

    void Update()
    {
        // Get positions of enemy and player
        Vector2 enemyPosition = transform.position;
        Vector2 playerPosition = playerTransform.position;

        // Calculate distance between enemy and player
        float distance = Vector2.Distance(enemyPosition, playerPosition);

        // Check if player is within attack range
        if (distance <= attackRange)
        {
            // Attack if player is within range and not already attacking
            if (!isAttacking)
            {
                animator.SetTrigger("Atack"); // Replace "Attack" with your actual trigger name
                isAttacking = true;
               // Sound.instance.AttackEnemy();
            }
           
        }
        else
        {
            // Stop attacking and reset animation if player moves out of range
            if (isAttacking)
            {
                animator.ResetTrigger("Atack"); // Reset attack trigger to stop animation
                animator.SetTrigger("Idle"); // Replace "Idle" with your actual idle animation trigger
                isAttacking = false;
            }
        }
    }


}
