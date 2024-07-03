using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject xpclump;
    public float xpAmout;

   public void Dropxp()
    {
        GameObject xpDropped = Instantiate(xpclump, transform.position, transform.rotation);
        xpclump.GetComponent<XpClub>().heldxp = xpAmout;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
