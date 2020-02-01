using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_enemyMoves : MonoBehaviour {

    private Vector3 initialPosition;
    public float maxDist = 5;
    private int direction;
    public float movingSpeed= 5;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d=GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (direction == 1)
        {
            if(transform.position.x - initialPosition.x > maxDist){
                spriteRenderer.flipX = true;
                direction = -1;
            }

        }
        else
        {
            if (transform.position.x < initialPosition.x )
            {
                spriteRenderer.flipX = false;
                direction = 1;
            }
        }
        rb2d.velocity = new Vector2(direction*movingSpeed, rb2d.velocity.y);

	}
}
