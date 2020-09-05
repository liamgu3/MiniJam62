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
		speed = .05f;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.W))
		{
			transform.position = new Vector2(transform.position.x, transform.position.y + speed);
		}

		if (Input.GetKey(KeyCode.S))
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - speed);
		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.position = new Vector2(transform.position.x + speed, transform.position.y);
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.position = new Vector2(transform.position.x - speed, transform.position.y);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision");
	}
}
