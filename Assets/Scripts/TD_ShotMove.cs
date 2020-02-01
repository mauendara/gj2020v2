using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_ShotMove : MonoBehaviour {


    //Characteristics
    public float speed;
    public float damage;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "lab")
        {
            Destroy(gameObject);
        }

    }
}
