using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_arrowBeha : MonoBehaviour {

    public float lifespaw = 3.0f;
    private Rigidbody2D move;
    public float speed;
	// Use this for initialization
	void Start () {
        move = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        move.transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        lifespaw -= Time.deltaTime;
        if (lifespaw < 0)
        {
            Explode();
        }
	}
    void Explode()
    {
        Destroy(gameObject);
    }
}
