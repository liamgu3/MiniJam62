using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float speed;

	private Rigidbody2D rb;
	private Vector2 hMove;
	private Vector2 vMove;

    // Start is called before the first frame update
    void Start()
    {
		speed = 50.0f;
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;

		hMove = Vector2.zero;
		vMove = Vector2.zero;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.W))
		{
			//transform.position = new Vector2(transform.position.x, transform.position.y + speed);
			//rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
			vMove = Vector2.up * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			//transform.position = new Vector2(transform.position.x, transform.position.y - speed);
			//rb.MovePosition(rb.position + -Vector2.up * speed * Time.deltaTime);
			vMove = -Vector2.up * speed * Time.deltaTime;
		}
		else
		{
			vMove = Vector2.zero;
		}

		if (Input.GetKey(KeyCode.D))
		{
			//transform.position = new Vector2(transform.position.x + speed, transform.position.y);
			//rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
			hMove = Vector2.right * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.A))
		{
			//transform.position = new Vector2(transform.position.x - speed, transform.position.y);
			//rb.MovePosition(rb.position + -Vector2.right * speed * Time.deltaTime);
			hMove = -Vector2.right * speed * Time.deltaTime;
		}
		else
		{
			hMove = Vector2.zero;
		}
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + (hMove + vMove) * speed * Time.deltaTime);
	}
}
