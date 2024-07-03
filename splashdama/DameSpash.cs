using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.VisualScripting;

public class DameSpash : MonoBehaviour
{

    public float damageRadius = 5.0f;
    public float damageAmount = 10.0f;
    public float damageCooldown = 1.0f;
    public GameObject explosionEffect;

    private float _lastDamageTime = 0.0f;

    private void Update()
    {
        // Check for cooldown and trigger damage if ready
        if (Time.time - _lastDamageTime >= damageCooldown)
        {
            _lastDamageTime = Time.time;
            CauseDamage();
        }
    }

    private void CauseDamage()
    {
        // Get all colliders within damage radius (consider using OverlapCircle for efficiency if appropriate)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, damageRadius); // Use OverlapCircleAll for 2D colliders

        // Iterate through colliders and apply damage/effects
        foreach (Collider2D collider in colliders)
        {
            // Ensure collider has a Health component before applying damage
            if (collider.gameObject.TryGetComponent<EnemyHp>(out EnemyHp health))
            {
                health.TakeDamege(damageAmount);
              // Instantiate(explosionEffect, collider.transform.position, Quaternion.identity);
                
            }
            else
            {
                Debug.LogWarning($"Object '{collider.gameObject.name}' within damage radius lacks a 'Health' component. Consider adding it for damage application.");
            }
         
        }
       
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
      //  Instantiate(explosionEffect, transform.position, Quaternion.identity);
        GameObject ExplosionEffectIn = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIn , 1f);
        Destroy(gameObject);
    }
}


