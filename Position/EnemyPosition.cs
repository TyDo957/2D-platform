using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
   
    public float maxRadius = 10.0f;
    public float cooldown = 1.0f;

    private float lastSwapTime = 0.0f;

    private void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Time.time - lastSwapTime >= cooldown)
            {
                // Tạo vị trí ngẫu nhiên bên phải
                float randomOffset = Random.Range(10f, maxRadius);
                Vector3 newPosition = collision.gameObject.transform.position + Vector3.left * randomOffset;

                // Hoán đổi vị trí người chơi
                collision.gameObject.transform.position = newPosition;

                // Cập nhật thời gian hoán đổi
                lastSwapTime = Time.time;

                // Thêm hiệu ứng
                // ...
            }
        }
    }
}

