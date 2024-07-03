using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    
    public Transform target;
    [SerializeField] private float attackDame = 10f;
    [SerializeField] private float atackSpeed = 1f;
    private float canAtack;

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (atackSpeed <= canAtack)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDame);
                canAtack = 0f;
            }
            else
            {
                canAtack += Time.deltaTime;
            }

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
   
    
   
    
  
  
}





