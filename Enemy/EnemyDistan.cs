using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistan : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform pointA;
    public Transform pointB;
    private bool isMovingToA = true;

    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if (isMovingToA)
            {
                transform.position = Vector2.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, pointA.position) < 0.1f)
                {
                    isMovingToA = false;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, pointB.position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
                {
                    isMovingToA = true;
                }
            }
            yield return null;
        }
    }
}




