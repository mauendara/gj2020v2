using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    public GameObject municion;
    public Transform posicionInicial;
    public float speed = 20f;          

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(municion, transform.position, posicionInicial.rotation);
        }
    }
}
