using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletR : MonoBehaviour
{
    public R weapon;
    public Transform shortPoint;
    public GameObject projecttile;
    public float timebetweenshort;
    private float nextshort;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (Time.time > nextshort)
            {
                nextshort = Time.time + timebetweenshort;
                Instantiate(projecttile, shortPoint.position, shortPoint.rotation);
            }

        }

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
