using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesTroySkill : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hitbox")
        {
            Vector2 differen = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + differen.x, transform.position.y + differen.y);
        }
       
       
        Destroy(gameObject);
    }
   
}
