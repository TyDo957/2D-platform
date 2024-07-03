using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tes : MonoBehaviour
{
    public float attackDistan;
    public float seeDistan;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        float distan = Vector3.Distance(transform.position, player.transform.position);
        if (distan < attackDistan)
        {
            Invoke("Atack", 0.2f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
