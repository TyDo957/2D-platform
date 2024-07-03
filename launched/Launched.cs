using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launched : MonoBehaviour
{
    public float force = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }


}
