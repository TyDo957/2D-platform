using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyShoot: MonoBehaviour
{ // Tham chiếu đến đối tượng kẻ thù
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float recoilForce = 10f;

    private float lastFireTime = 0f;

    void Update()
    {
        if (Time.time - lastFireTime >= fireRate)
        {
            // Tạo đạn mới
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Áp dụng lực cho đạn
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10f);

            // Áp dụng lực giật lùi cho kẻ thù
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * recoilForce);

            lastFireTime = Time.time;
        }
    }
}

