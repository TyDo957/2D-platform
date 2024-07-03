using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public float hitStunTime = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra đòn tấn công của người chơi
        if (collision.gameObject.tag == "PlayerAttack")
        {
            // Hạn chế di chuyển khi bị hất tung
            StartCoroutine(HitStun());
        }
    }

    IEnumerator HitStun()
    {
        Rigidbody2D enemyRigidbody = GetComponent<Rigidbody2D>();
        if (enemyRigidbody)
        {
            enemyRigidbody.velocity = Vector2.zero;
        }

        // Khóa di chuyển trong thời gian hitStun
       // GetComponent<EnemyController>()?.enabled = false;

        yield return new WaitForSeconds(hitStunTime);

        // Mở khóa di chuyển sau hitStun
      //  GetComponent<EnemyController>()?.enabled = true;
    }
}
