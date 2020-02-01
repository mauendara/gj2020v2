using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TD_PlayerController : MonoBehaviour
{

    //Timer
    public float timeLeft = 30;
    public Text txtTimer;

    //Characteristics
    public float speed = 3;
    private int lives = 5;
    public Text txtLives;


    //Weapon
    Quaternion rotation;
    public float fireRate;
    private float nextFire;
    private int flagShot = 0;
    public Sprite[] images;
    public Image imageContainer;
    public Text txtCount;
    public int[] counts;

    //stone
    public GameObject objStone;

    //Plants
    private bool ingPlant = false;
    private int typePlant = 0;
    public GameObject objSeedPrim;
    public GameObject objSeedCala;
    public GameObject objSeedHele;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        timeLeft -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeLeft / 60F);
        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        txtTimer.text = niceTime;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            flagShot = 0;
            changeWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            flagShot = 1;
            changeWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            flagShot = 2;
            changeWeapon();
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            fire();
        }



    }


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && ingPlant)
        {
            counts[typePlant] += 1;
            Debug.Log("Recolectando");
            if (flagShot == typePlant)
            {
                txtCount.text = counts[typePlant].ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && ingPlant)
        {
            if (typePlant == 1)
            {
                getLive();
            }
           
        }

        //Weapon direcction
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Move
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        this.transform.position += Movement * speed * Time.deltaTime;

    }

    private void lostLive()
    {
        this.lives -= 1;
        txtLives.text = lives.ToString();
    }

    private void getLive()
    {
        this.lives += 1;
        txtLives.text = lives.ToString();
    }


    private void fire()
    {
        if (flagShot == 0 && counts[flagShot] != 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(objStone, transform.position, rotation);
            counts[flagShot] -= 1;
        }
        else if (flagShot == 1 && counts[flagShot] != 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(objSeedPrim, transform.position, rotation);
            counts[flagShot] -= 1;
        }

        else if (flagShot == 2 && counts[flagShot] != 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(objSeedCala, transform.position, rotation);
            counts[flagShot] -= 1;
        }

        txtCount.text = counts[flagShot].ToString();
    }

    private void changeWeapon()
    {
        imageContainer.sprite = images[flagShot];
        txtCount.text = counts[flagShot].ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TD_Stone")
        {
            counts[0] += 1;
            Destroy(collision.gameObject);

            if (flagShot == 0)
            {
                txtCount.text = counts[0].ToString();
            }

        }

        if (collision.gameObject.tag == "TD_Plant")
        {
            ingPlant = true;
            Debug.Log("Entre en: "+ collision.gameObject.name);

            if (collision.gameObject.name == "TD_PF_Primula")
            {
                typePlant = 1;
            }
            else if (collision.gameObject.name == "TD_PF_Calabaza")
            {
                typePlant = 2;
            }
            else if (collision.gameObject.name == "TD_PF_Helecho")
            {
                typePlant = 3;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TD_Plant")
        {
            ingPlant = false;
            Debug.Log("Sali en planta");
        }

    }


}
