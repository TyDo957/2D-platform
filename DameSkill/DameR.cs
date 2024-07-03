using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameR : MonoBehaviour
{
    [SerializeField] private float Damege;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHp enemy = collision.GetComponent<EnemyHp>();
        BossHp boss = collision.GetComponent<BossHp>();

        if(boss != null)
        {
            boss.takeDame(Damege);
        }

        if (enemy != null)
        {
            enemy.TakeDamege(Damege);
        }
    }

   
}


