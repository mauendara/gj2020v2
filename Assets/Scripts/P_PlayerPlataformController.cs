using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class P_PlayerPlataformController : P_PhysicsObject {
	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;

	private SpriteRenderer spriteRenderer;
	private Animator animator;
    private bool special, crouch;
	private Vector3 initialPosition;

	// Use this for initialization
	void Awake () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		animator = GetComponent<Animator> ();
        
		initialPosition = GetComponent<Rigidbody2D>().transform.position ;

	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");


		if (Input.GetButtonDown ("Jump") && grounded) {
			velocity.y = jumpTakeOffSpeed;
		} else if (Input.GetButtonUp ("Jump")) 
		{
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}
        if (Input.GetKeyDown(KeyCode.H) && grounded )
        {
            attack = true;
            animator.SetBool("attack", attack);
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            attack = false;
            animator.SetBool("attack", attack);
            movement = true;
        }
        if (Input.GetKeyDown(KeyCode.G) && grounded)
        {
            special = true;
            animator.SetBool("special", special);
        }
        else if (Input.GetKeyUp(KeyCode.G) && grounded)
        {
            special = false;
            animator.SetBool("special", special);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && grounded)
        {
            crouch = true;
            animator.SetBool("crouch", crouch);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && grounded)
        {
            crouch = false;
            animator.SetBool("crouch", crouch);
        }
        if (move.x < 0) 
		{
            spriteRenderer.flipX = true;
        }
        else if (move.x > 0)
        {
            spriteRenderer.flipX = false;
        } 
		animator.SetBool ("grounded", grounded);
		animator.SetBool ("runnin", Mathf.Abs (velocity.x)!=0);

		//animator.SetFloat ("velocityX", Mathf.Abs (velocity.x));
		targetVelocity = move * maxSpeed;
	}

    void AttackEnd()
    {
        attack = false;
    }


    void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag.Equals("P_projectile") || col.gameObject.tag.Equals("P_enemy"))
        {
			rb2d.transform.position = initialPosition;
			animator.SetBool ("hurt", true);
			rb2d.AddForce (new Vector2 (-4, 3), ForceMode2D.Impulse);
		}
        if (col.gameObject.tag.Equals("P_enemyHead"))
        {
            rb2d.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
            Destroy(col.gameObject);
		}
        if (col.gameObject.tag.Equals("DeadZone"))
        {
            SceneManager.LoadScene("ira");
        }
	}
	void OnTriggerExit2D(Collider2D col)
	{
        if (col.gameObject.tag.Equals("P_projectile") || col.gameObject.tag.Equals("P_enemy"))
		{
			animator.SetBool ("hurt", false);
		}
	}

}
