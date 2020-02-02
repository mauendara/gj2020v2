using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickUpItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public float throwForce = 10;
    private bool isPlayerOver = false;
    public bool isBeingCarried = false;
    public bool isFire = false;

    private float posicionInicial;

    public float velocidad = 5;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public string description;
    private GameObject descriptionText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOver = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOver = false;
        }
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        sp = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        descriptionText = GameObject.FindWithTag("DescText");
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingCarried)
        {
            descriptionText.GetComponent<Text>().text = description;
            if (Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<Rigidbody2D>().isKinematic = false;
                transform.parent = null;
                isBeingCarried = false;
                GetComponent<Rigidbody2D>().AddForce(player.forward * throwForce);
                descriptionText.GetComponent<Text>().text = "";
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
                descriptionText.GetComponent<Text>().text = "";
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
