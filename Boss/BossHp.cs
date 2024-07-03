using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;
using System.Net.NetworkInformation;

public class BossHp : MonoBehaviour
{
    public float hp = 500f;
    public Slider enemySkider;
    private Animator amin;
    private void Start()
    {
        enemySkider.maxValue = hp;
        enemySkider.value = hp;
        amin = GetComponent<Animator>();
    }
    public void takeDame(float damage)
    {
        hp -= damage;
        enemySkider.value = hp;
        if (hp <= 0)
        {

          // this.Diel();
        }
    }
    private void Update()
    {
        if (hp <= 0)
        {
            amin.SetTrigger("Dead");
        }
    }
    public void Diel()
    {
       
        Destroy(gameObject);
    }
}