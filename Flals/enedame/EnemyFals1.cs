using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFals1 : MonoBehaviour
{
    public FlalsEnemy flashEffect;
    public KeyCode flashkey;

    private void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        flashEffect.Flash();
    }
}



