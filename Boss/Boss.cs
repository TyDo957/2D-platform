using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool flip = false;
  
    public void LoolAtPlayer()
    {
        Vector3 flipped = transform.localScale;
         flipped.z *= -1;

        if (transform.position.x > player.position.x && flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            flip = false;
        }
        else if(transform.position.x  < player.position.x && !flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            flip = true;
        }
    }

    private void Update()
    {
        
    }
}
