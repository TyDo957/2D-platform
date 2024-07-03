using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    public GameObject player;
    public float speed;
    public float distanbeetwen;

    private float distan;


    private void Update()
    {
        distan = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.x) * Mathf.Rad2Deg;

        if (distan < distanbeetwen)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector2.up * angle);
        }
        // SoundController.instance.EnemyGhost();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hitbox")
        {
            Vector2 differen = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + differen.x, transform.position.y + differen.y);

           
        }
       
    }
}
