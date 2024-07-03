using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyFlasl : MonoBehaviour
{

   
    public Flasl flashEffect; // Flash effect script reference

   
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Gây sát thương
         

            // Kích hoạt flash
            if (flashEffect != null)
            {
                flashEffect.FlashScreen();
            }
            Destroy(gameObject , 1f);
        }
       
    }
    
}
