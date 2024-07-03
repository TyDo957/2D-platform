using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;
using System.Net.NetworkInformation;

public class EnemyHp : MonoBehaviour
{
    public float health = 3f;
    [SerializeField] private float maxHealth = 3f;

    public Slider enemySkider;
    private Animator amin;
   // public GameObject popUpdamageprefab;
    // public TMP_Text popUptext;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        enemySkider.maxValue = maxHealth;
        enemySkider.value = maxHealth; 
        amin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "Weapon")
        {
           // TakeDamege(other.GetComponent<Proticle>().damage);
        }
    }
    public void TakeDamege(float damageamoput)
    {
        // showDamage(damageamoput.ToString());
        health -= damageamoput;
        //  Instantiate(popUpdamageprefab, transform.position, Quaternion.identity);
        enemySkider.value = health;
        if (health <= 0)
        {
            //Destroy(gameObject);
            //GetComponent<EnemyDrop>().Dropxp();
            this.Diehh();
        }
        
    }

    public void Diehh()
    {
        Destroy(gameObject);
       
    }
   int expAmout = 100;
}
