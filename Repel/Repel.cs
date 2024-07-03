using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel : MonoBehaviour
{
    // Public variables
    public float knockbackForce = 100f; // Force to push the player back
    public float knockbackDistance = 5f; // Distance to push the player back
    public float knockbackDuration = 0.5f; // Duration of the knockback effect
    public Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody2D

    // Private variables
    private Rigidbody2D enemyRigidbody; // Reference to the enemy's Rigidbody2D

    // Start function
    void Start()
    {
        // Get references to rigidbodies
        enemyRigidbody = GetComponent<Rigidbody2D>();
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // OnCollisionEnter2D function
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate the knockback direction based on the collision point
            Vector2 knockbackDirection = (playerRigidbody.position - enemyRigidbody.position).normalized;

            // Calculate the distance to the player
            float distanceToPlayer = Vector2.Distance(enemyRigidbody.position, playerRigidbody.position);

            // Apply knockback force to the player, ensuring a fixed distance
            playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            playerRigidbody.MovePosition(playerRigidbody.position + (knockbackDirection * knockbackDistance));

            // Add a delay to prevent immediate collision again
            Invoke("ResetKnockback", knockbackDuration);
        }
    }

    // ResetKnockback function
    void ResetKnockback()
    {
        playerRigidbody.velocity = Vector2.zero; // Reset player's velocity
    }
}



