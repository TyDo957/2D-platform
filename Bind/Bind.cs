using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bind : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Lưu trữ tốc độ di chuyển ban đầu
            float originalSpeed = other.gameObject.GetComponent<PlayeMove>().speed;

            // Làm chậm người chơi trước khi bất động
            //  other.gameObject.GetComponent<PlayeMove>().speed *= 0.5f;
            other.gameObject.GetComponent<PlayeMove>().speed = 0f;
            // Bất động Rigidbody
           // other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            // Kích hoạt hiệu ứng bất động (tùy chọn)
            other.gameObject.GetComponent<Animator>().SetTrigger("Stunned");
            
            // Gỡ bỏ hiệu ứng bất động sau 2 giây (tùy chỉnh thời gian)
            StartCoroutine(UnstunPlayer(other.gameObject, 3.0f, originalSpeed));

            GameObject ExplosionEffectIn = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(ExplosionEffectIn, 3f);
        }
      
    }

    IEnumerator UnstunPlayer(GameObject player, float delay, float originalSpeed)
    {
        yield return new WaitForSeconds(delay);

        // Khôi phục tốc độ di chuyển ban đầu
        player.GetComponent<PlayeMove>().speed = originalSpeed;

        // Bỏ bất động Rigidbody
        player.GetComponent<Rigidbody2D>().isKinematic = false;
      Destroy(gameObject);
    }
}
