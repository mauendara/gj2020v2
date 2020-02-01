using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    public float speed,jumpForce,cooldownHit;
	public bool running,up,down,jumping,crouching,dead,attacking,special;
    private Rigidbody2D rb;
    private Animator anim;
	private SpriteRenderer sp;
	private float rateOfHit;
	private int qtdLife;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		sp=GetComponent<SpriteRenderer>();
		running=false;
		up=false;
		down=false;
		jumping=false;
		crouching=false;
        dead = false;
        rateOfHit =Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Character doesnt choose direction in Jump									//If you want to choose direction in jump
			if(attacking==false){													//just delete the (jumping==false)
				if(jumping==false&&crouching==false){
					Movement();
					Attack();
					Special();
				}
				Jump();
				Crouch();
			}

	}

	void Movement(){
		//Character Move
		float move = Input.GetAxisRaw("Horizontal");
		if(Input.GetKey(KeyCode.LeftShift)){
			//Run
			rb.velocity = new Vector2(move*speed*Time.deltaTime*3,rb.velocity.y);
			running=true;
		}else{
			//Walk
			rb.velocity = new Vector2(move*speed*Time.deltaTime,rb.velocity.y);
			running=false;
		}

		//Turn
		if(rb.velocity.x<0){
			sp.flipX=true;
		}else if(rb.velocity.x>0){
			sp.flipX=false;
		}
		//Movement Animation
		if(rb.velocity.x!=0&&running==false){
			anim.SetBool("Walking",true);
		}else{
			anim.SetBool("Walking",false);
		}
		if(rb.velocity.x!=0&&running==true){
			anim.SetBool("Running",true);
		}else{
			anim.SetBool("Running",false);
		}
	}

	void Jump(){
		//Jump
		if(Input.GetButtonDown("Jump") && rb.velocity.y==0){
			rb.AddForce(new Vector2(rb.velocity.x, jumpForce));

		}
		//Jump Animation
		if(rb.velocity.y>0&&up==false){
			up=true;
			jumping=true;
			anim.SetTrigger("Up");
		}else if(rb.velocity.y<0&&down==false){
			down=true;
			jumping=true;
			anim.SetTrigger("Down");
		}else if(rb.velocity.y==0&&(up==true||down==true)){
			up=false;
			down=false;
			jumping=false;
			anim.SetTrigger("Ground");
		}
	}

	void Attack(){																//I activated the attack animation and when the 
		//Atacking																//animation finish the event calls the AttackEnd()
		if(Input.GetKeyDown(KeyCode.H)){
			rb.velocity=new Vector2(0,0);
			anim.SetTrigger("Attack");
			attacking=true;
		}
	}

	void AttackEnd(){
		attacking=false;
	}

	void Special(){
		if(Input.GetKey(KeyCode.G)){
			anim.SetBool("Special",true);
		}else{
			anim.SetBool("Special",false);
		}
	}

	void Crouch(){
		//Crouch
		if(Input.GetKey(KeyCode.LeftControl)){
			anim.SetBool("Crouching",true);
		}else{
			anim.SetBool("Crouching",false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){							//Case of Bullet
		
	}								

	void OnCollisionEnter2D(Collision2D other) {						//Case of Touch
		
	}

	


}
