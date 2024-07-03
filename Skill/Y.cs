using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y : MonoBehaviour
{
    [SerializeField] private GameObject buletPlayerl;
    [SerializeField] private Transform firePos;
    [SerializeField] private float TimeBwFire = 0.2f;
    [SerializeField] private float bulletForce;
    private float timeBtfire;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timeBtfire -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Keypad0) && timeBtfire < 0)
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
        Sound.instance.PlayerSkill0();

    }
}
