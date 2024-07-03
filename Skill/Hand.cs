using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    /*
    [SerializeField] private GameObject buletPlayerl;
    [SerializeField] private Transform firePos;
    [SerializeField] private float TimeBwFire = 0.2f;
    [SerializeField] private float bulletForce;
    private float timeBtfire;

    // Update is called once per frame
    void Update()
    {

        timeBtfire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBtfire < 0)
        {

            this.Bulet();

        }

    }

    public void Bulet()
    {

        timeBtfire = TimeBwFire;
        GameObject bullettmp = Instantiate(buletPlayerl, firePos.position,firePos.rotation);
        Rigidbody2D rb = bullettmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);


    }
    */
    [SerializeField] private GameObject bulletPlayerl;
    [SerializeField] private Transform firePos;
    [SerializeField] private float timeBwFire = 0.2f;
    [SerializeField] private float bulletForce;
    private float timeBtfire;
    [SerializeField] private float destroyDistance = 10.0f; // Adjust this value to control the destruction distance

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeBtfire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBtfire < 0)
        {
            this.Bulet();
        }
    }

    public void Bulet()
    {
        timeBtfire = timeBwFire;
        GameObject bulletTmp = Instantiate(bulletPlayerl, firePos.position, firePos.rotation);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);

        // Destroy the bullet after traveling the specified distance
        Destroy(bulletTmp, destroyDistance / rb.velocity.magnitude);
    }
}
