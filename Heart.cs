using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int healAmount = 10; // Lượng máu hồi phục

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Hồi máu cho người chơi
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.maxHealth += healAmount;

            // Xóa prefab trái tim
            Destroy(gameObject);
        }
    }
}



