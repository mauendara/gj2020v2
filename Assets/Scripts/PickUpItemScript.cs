using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public float throwForce = 10;
    private bool isPlayerOver = false;
    private bool isBeingCarried = false;


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
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingCarried)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<Rigidbody2D>().isKinematic = false;
                transform.parent = null;
                isBeingCarried = false;
                GetComponent<Rigidbody2D>().AddForce(player.forward * throwForce);
                Debug.Log("Droping");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && isPlayerOver)
            {
                GetComponent<Rigidbody2D>().isKinematic = true;
                transform.parent = player;
                isBeingCarried = true;
                Debug.Log("Picking up");
            }
        }
    }
}
