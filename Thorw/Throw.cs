using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Throw : MonoBehaviour
{
    
     public float throwCooldown = 2f; // Time between throws
     public float throwForce = 10f; // Throw force
     public GameObject projectilePrefab;
     private float timer = 0f;
     private Transform playerTransform;
     public float throwRange = 10f; // Range to detect player for throwing
     public float recoilForce = 10f;
     public Transform firePos;
    
    private void Start()
     {
         playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
     }

     private void Update()
     {
         // Increase cooldown timer
         timer += Time.deltaTime;

         // Check if player is in range
         float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

         // Throw projectile if cooldown is ready and player is in range
         if (timer >= throwCooldown && distanceToPlayer <= throwRange)
         {
             // Create projectile object
             GameObject projectile = Instantiate(projectilePrefab, firePos.position, firePos.rotation);
           
            // Throw projectile towards player
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
             projectileRb.AddForce((playerTransform.position - transform.position).normalized * throwForce, ForceMode2D.Impulse);

             // Reset cooldown timer
             timer = 0f;
             GetComponent<Rigidbody2D>().AddForce(Vector2.left * recoilForce); // Apply recoil
             Sound.instance.EneemyBullet();
            // Start self-destruct timer for the projectile
            //  StartCoroutine(DestroyProjectile(projectile, 3.0f));
        }


    }

     IEnumerator DestroyProjectile(GameObject projectile, float delay)
     {
         yield return new WaitForSeconds(delay);
         Destroy(projectile);
     }

  

   

}





