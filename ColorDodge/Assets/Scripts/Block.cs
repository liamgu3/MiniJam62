using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public float speed;

    // Start is called before the first frame update
    void Start()
    {
		speed = .05f;
	}

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector2(transform.position.x, transform.position.y - speed);

		if (transform.position.y < -25)
		{
			Destroy(gameObject);
		}
    }

}
