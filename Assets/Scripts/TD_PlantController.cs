using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_PlantController : MonoBehaviour {

    //Items
    public Sprite plantC, plantE;
    public GameObject objDestroy;
    public bool ingPlant = false;
    Collider2D colliderObj;
    private float counter = -10;

    // Use this for initialization
    void Start () {
        colliderObj = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
        else if (counter != -10 && counter <= 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = plantC;
            colliderObj.enabled = true;
            counter = -10;
        }

        if (Input.GetKeyDown(KeyCode.E) && ingPlant)
        {
            this.GetComponent<SpriteRenderer>().sprite = plantE;

            ingPlant = false;
            counter = 10;
            colliderObj.enabled = false;
        }


        if (Input.GetKeyDown(KeyCode.Mouse1) && ingPlant)
        {
            Destroy(gameObject);
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "TD_Player")
        {
            ingPlant = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TD_Player")
        {
            ingPlant = false;

        }
    }

}
