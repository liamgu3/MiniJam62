using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public float speed;

	private BlockSpawner blocksHolder;

	private Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
    {
		//speed = 7.5f;
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;

		blocksHolder = GameObject.Find("BlockSpawner").GetComponent<BlockSpawner>();
	}

    // Update is called once per frame
    void Update()
    {

		if (transform.position.y < -25)
		{
			blocksHolder.removeBlock();
			Destroy(gameObject);
		}
    }

	private void FixedUpdate()
	{
		//transform.Translate(-Vector2.up * speed * Time.deltaTime);
		rb.MovePosition(rb.position + -Vector2.up * speed * Time.deltaTime);
	}

	//private void OnCollisionEnter2D(Collision2D collision)
	//{
	//	if (collision.gameObject.layer == 9)
	//	{
	//		Physics2D.IgnoreCollision(collision.collider, GetComponent<BoxCollider2D>());
	//	}
	//}

}
