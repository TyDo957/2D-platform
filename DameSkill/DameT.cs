using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameT : MonoBehaviour
{
    [SerializeField] private float Damege;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHp enemy = collision.GetComponent<EnemyHp>();
        if (enemy != null)
        {
            enemy.TakeDamege(Damege);
        }
    }
}
