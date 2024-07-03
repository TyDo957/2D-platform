using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R : MonoBehaviour
{
    
    [SerializeField] private GameObject buletPlayerl;
    [SerializeField] private Transform firePos;
    [SerializeField] private float TimeBwFire = 0.2f;
    [SerializeField] private float bulletForce;
    private float timeBtfire;


    // Update is called once per frame
    void Update()
    {

        timeBtfire -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Keypad1) && timeBtfire < 0)
        {

            this.Bulet();

        }


    }

    public void Bulet()
    {

        timeBtfire = TimeBwFire;
        GameObject bullettmp = Instantiate(buletPlayerl, firePos.position, firePos.rotation);
        Rigidbody2D rb = bullettmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        Sound.instance.SkillPlayer1();

    }
   
}

