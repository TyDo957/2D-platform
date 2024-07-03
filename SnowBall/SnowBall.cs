using System.Collections;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    
     [SerializeField] public float slowRadius = 5f; // Bán kính hiệu ứng làm chậm
     [SerializeField] public float slowAmount = 0.5f; // Mức độ làm chậm (0 - 1)
     [SerializeField] public float slowDuration = 2f; // Thời gian hiệu ứng làm chậm

     [SerializeField] private GameObject explosionEffect;
      
    private void Update()
     {

     }
     private void OnCollisionEnter2D(Collision2D collision)
      {
          // Làm chậm người chơi khi va chạm với vật thể ném
          if (collision.gameObject.tag == "Player")
          {
              PlayeMove playerMovement = collision.gameObject.GetComponent<PlayeMove>();
              playerMovement.speed *= slowAmount;

             // Bắt đầu coroutine để tắt hiệu ứng làm chậm
             StartCoroutine(SlowTimer(playerMovement, slowDuration));

             GameObject ExplosionEffectIn = Instantiate(explosionEffect, transform.position, Quaternion.identity);
             Destroy(ExplosionEffectIn, 3f);
            // Hiển thị hiệu ứng làm chậm (tùy chọn)
        }
      
        // Destroy(gameObject);

    }

      IEnumerator SlowTimer(PlayeMove  playerMovement, float duration)
      {
          yield return new WaitForSeconds(duration);

          // Khôi phục tốc độ di chuyển của người chơi
          playerMovement.speed /= slowAmount;

         // Hủy vật thể sau 1 giây
         yield return new WaitForSeconds(1f);
         Destroy(gameObject);

     }
   
}






