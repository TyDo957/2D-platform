using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour
{

    public float pullStrength = 10.0f;
    public float pullRange = 5.0f;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) <= pullRange)
        {
            // Kéo người chơi về phía mình
            Vector2 direction = (transform.position - playerTransform.position).normalized;
            playerTransform.GetComponent<Rigidbody2D>().AddForce(direction * pullStrength * Time.deltaTime);
        }
    }

   
}
