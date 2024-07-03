using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAging : MonoBehaviour
{
   
    [SerializeField] private Animator anim;
    [SerializeField] float attackTimer = 0f;  // Timer for tracking attack window
    [SerializeField] float attackWindow = 0.5f; // Adjust this value to control combo window duration (in seconds)  // Flag to prevent multiple attacks within the window
    [SerializeField] private Collider2D attackCollider; // Reference to attack trigger collider
    [SerializeField] private int damageAmount = 10; // Base damage per attack
    private bool canAttack = true;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            anim.SetTrigger("Atack");
            attackTimer = attackWindow;
            canAttack = false;
            Sound.instance.PlayerBullet();
            attackCollider.enabled = true;
            Invoke("DisableCollider", 0.2f);
        }

        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                canAttack = true;  // Reset attack availability after the window closes
            }
        }


    }
   

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an enemy
        if (collision.gameObject.tag == "Enemy")
        {
            // Deal damage to the enemy
            collision.gameObject.GetComponent<EnemyHp>().TakeDamege(damageAmount);
        }
    }

    private void DisableCollider()
    {
        attackCollider.enabled = false;
    }
}



