using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float speed;

	private Rigidbody2D rb;
	private Vector2 wMove;
	private Vector2 sMove;
	private Vector2 dMove;
	private Vector2 aMove;

	// Start is called before the first frame update
	void Start()
    {
		speed = 30.0f;
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;

		wMove = Vector2.zero;
		sMove = Vector2.zero;
		dMove = Vector2.zero;
		aMove = Vector2.zero;
	}

    // Update is called once per frame
    void Update()
    {
		
	}

	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.W))
		{
			//transform.position = new Vector2(transform.position.x, transform.position.y + speed);
			//rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
			wMove = Vector2.up * speed * Time.deltaTime;
		}
		else
		{
			wMove = Vector2.zero;
		}


		if (Input.GetKey(KeyCode.S))
		{
			//transform.position = new Vector2(transform.position.x, transform.position.y - speed);
			//rb.MovePosition(rb.position + -Vector2.up * speed * Time.deltaTime);
			sMove = -Vector2.up * speed * Time.deltaTime;
		}
		else
		{
			sMove = Vector2.zero;
		}

		if (Input.GetKey(KeyCode.D))
		{
			//transform.position = new Vector2(transform.position.x + speed, transform.position.y);
			//rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
			dMove = Vector2.right * speed * Time.deltaTime;
		}
		else
		{
			dMove = Vector2.zero;
		}

		if (Input.GetKey(KeyCode.A))
		{
			//transform.position = new Vector2(transform.position.x - speed, transform.position.y);
			//rb.MovePosition(rb.position + -Vector2.right * speed * Time.deltaTime);
			aMove = -Vector2.right * speed * Time.deltaTime;
		}
		else
		{
			aMove = Vector2.zero;
		}

		rb.MovePosition(rb.position + (wMove + sMove + dMove + aMove) * speed * Time.deltaTime);
	}
}
