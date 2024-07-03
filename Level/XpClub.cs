using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpClub : MonoBehaviour
{
    public float heldxp;
    private Transform player;
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.TryGetComponent<PlayerStar>(out PlayerStar playerstar))
        {
            playerstar.gainxp(heldxp);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerStar>().transform;
    }

    // Update is called once per frame
    void Update()
    {
      transform.position =  Vector2.MoveTowards(transform.position, player.position, 5 * Time.deltaTime);
    }
}
