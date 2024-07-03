using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private SpriteRenderer charactor;
    private Color col;
    private float activationTime;
    private bool invisble;

    // Start is called before the first frame update
    void Start()
    {
        charactor = GetComponent<SpriteRenderer>();
        activationTime = 0;
        invisble = false;
        col = charactor.color;
    }

    // Update is called once per frame
    void Update()
    {
        activationTime += Time.deltaTime;
        if (invisble && activationTime >= 5)
        {
            invisble = false;
            col.a = 1;
            charactor.color = col;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
           // this.Ak();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Invisble" )
        {
           invisble = true;
            activationTime = 0;
            col.a = .2f;
            charactor.color = col;
        }
    }

    public void Ak()
    {
        activationTime += Time.deltaTime;
        if (invisble && activationTime >= 3)
        {
            invisble = false;
            col.a = 1;
            charactor.color = col;
        }
    }
}
