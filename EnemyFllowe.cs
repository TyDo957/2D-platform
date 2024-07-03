using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFllowe : MonoBehaviour
{
    /*
   
    
    [SerializeField] private float speed = 2.0f; // Tốc độ di chuyển của kẻ thù

    private Rigidbody2D rb; // Tham chiếu đến Rigidbody2D của kẻ thù
    private Transform playerTransform; // Tham chiếu đến Transform của người chơi

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").transform; // Tìm kiếm Transform của người chơi
    }

    void Update()
    {
        // Tính toán hướng từ kẻ thù đến người chơi trên mặt phẳng ngang
        Vector2 horizontalDirectionToPlayer = new Vector2(playerTransform.position.x - transform.position.x, 0f);
        horizontalDirectionToPlayer = horizontalDirectionToPlayer.normalized;

        // Áp dụng lực theo hướng song song với người chơi trên mặt phẳng ngang
        Vector2 movementForce = horizontalDirectionToPlayer * speed;
        rb.AddForce(movementForce);

        // Giữ kẻ thù trên mặt đất
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
   */
    [SerializeField] private float speed = 2.0f; // Tốc độ di chuyển của kẻ thù
    [SerializeField] private float jumpForce = 5.0f; // Lực nhảy
    [SerializeField] private float timeBetweenJumps = 2.0f; // Thời gian giữa các lần nhảy

    private Rigidbody2D rb; // Tham chiếu đến Rigidbody2D của kẻ thù
    private Transform playerTransform; // Tham chiếu đến Transform của người chơi
    private bool canJump = true; // Biến kiểm soát khả năng nhảy
    private float timeSinceLastJump = 0.0f; // Thời gian từ lần nhảy trước

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").transform; // Tìm kiếm Transform của người chơi
    }

    void Update()
    {
        // Tính toán hướng từ kẻ thù đến người chơi trên mặt phẳng ngang
        Vector2 horizontalDirectionToPlayer = new Vector2(playerTransform.position.x - transform.position.x, 0f);
        horizontalDirectionToPlayer = horizontalDirectionToPlayer.normalized;

        // Áp dụng lực theo hướng song song với người chơi trên mặt phẳng ngang
        Vector2 movementForce = horizontalDirectionToPlayer * speed;
        rb.AddForce(movementForce);

        // Giữ kẻ thù trên mặt đất
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        // Nhảy lên tấn công người chơi ngẫu nhiên
        timeSinceLastJump += Time.deltaTime;
        if (canJump && timeSinceLastJump >= timeBetweenJumps)
        {
            Jump();
            timeSinceLastJump = 0.0f;
            canJump = false;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        canJump = true;
    }
    
}
