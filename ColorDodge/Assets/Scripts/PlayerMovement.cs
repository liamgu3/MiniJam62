using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float speed;

    // Start is called before the first frame update
    void Start()
    {
		speed = 10.0f;
		GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.W))
		{
			//transform.position = new Vector2(transform.position.x, transform.position.y + speed);
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.S))
		{
			//transform.position = new Vector2(transform.position.x, transform.position.y - speed);
			transform.Translate(-Vector2.up * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.D))
		{
			//transform.position = new Vector2(transform.position.x + speed, transform.position.y);
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.A))
		{
			//transform.position = new Vector2(transform.position.x - speed, transform.position.y);
			transform.Translate(-Vector2.right * speed * Time.deltaTime);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision");
	}
}
