using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
  //  public float damageAmount = 10.0f;
    public float knockbackForce = 100.0f;
   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Kiểm tra kẻ thù
        if (collider.gameObject.tag == "Enemy")
        {
            // Gây sát thương
         //   collider.gameObject.GetComponent<EnemyHp>()?.TakeDamege(damageAmount);

            // Hất tung kẻ thù
            Rigidbody2D enemyRigidbody = collider.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody)
            {
                enemyRigidbody.AddForce(Vector2.up * knockbackForce , ForceMode2D.Impulse);
            }

           
        }
    }
  
}


