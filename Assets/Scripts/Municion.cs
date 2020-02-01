using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{
    public float velocidad = 5;
    private Rigidbody2D rb;
    private SpriteRenderer sp;

    private float posicionInicial;

    // Use this for initialization
    void Start()
    {
        rb= GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        sp = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();

        if (sp.flipX)
        {
            velocidad = velocidad * -1;
        }
        posicionInicial = transform.position.x;
        GetComponent<Rigidbody2D>().velocity = transform.right * velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > posicionInicial + 20 && velocidad>0)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < posicionInicial - 20 && velocidad < 0)
        {
            Destroy(gameObject);
        }
    }
}
