﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public float throwForce = 10;
    private bool isPlayerOver = false;
    private bool isBeingCarried = false;
    public bool isFire = false;

    private float posicionInicial;

    public float velocidad = 5;
    private Rigidbody2D rb;
    private SpriteRenderer sp;

    void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerOver = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOver = false;
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        sp = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingCarried)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<Rigidbody2D>().isKinematic = false;
                transform.parent = null;
                isBeingCarried = false;
                GetComponent<Rigidbody2D>().AddForce(player.forward * throwForce);

            }
            if (Input.GetKeyDown(KeyCode.G)&& isFire)
            {
                if (sp.flipX)
                {
                    velocidad = velocidad * -1;
                }
                GetComponent<Rigidbody2D>().isKinematic = false;
                transform.parent = null;
                isBeingCarried = false;
                GetComponent<Rigidbody2D>().velocity = transform.right * velocidad;
                posicionInicial = transform.position.x;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && isPlayerOver)
            {
                GetComponent<Rigidbody2D>().isKinematic = true;
                transform.parent = player;
                isBeingCarried = true;
            }

        }

        if (transform.position.x > posicionInicial + 20 && velocidad > 0)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < posicionInicial - 20 && velocidad < 0)
        {
            Destroy(gameObject);
        }

    }
}
