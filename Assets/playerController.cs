using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	// Start is called before the first frame update

	public Vector2 moveDir = Vector2.zero;
	Vector2 dir;
	Rigidbody2D rb;
	SpriteRenderer SR;
	public float speed= 10 ;
	Animator anim;
	public bool grounded;
	public GameObject Panel;
	public float jumpSpeed;
    void Start()
    {
		
		rb = GetComponent<Rigidbody2D>();
		SR = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {



		/*		moveDir.x = moveDir.x + Input.GetAxis("Horizontal");
				moveDir.y = moveDir.y + Input.GetAxis("Vertical");


				rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);*/


		float hor = Input.GetAxis("Horizontal");

/*
		if (hor != 0)
		{
			SR.flipX = hor < 0;
			print("hi");
			anim.SetBool("walk", hor < 0); 

		}*/
		if( hor > 0)
		{
			SR.flipX = false;
			anim.SetBool("walk", true);
		}
		else if ( hor < 0)
		{
			SR.flipX = true;
			anim.SetBool("walk", true);

		}
		else
		{
			anim.SetBool("walk", false);
		}

		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{

			

			rb.AddForce(Vector2.up*jumpSpeed);
			
		}

		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y) ;



	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("ground"))
		{
			anim.SetBool("jump", false);
			grounded = true;
		}

		
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("ground"))
		{
			anim.SetBool("jump", true);
			grounded = false;
		}

		

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("sign"))
		{
			print("hioi");
			Panel.gameObject.SetActive(true);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("sign"))
		{

			Panel.gameObject.SetActive(false);
		}
	}

}
