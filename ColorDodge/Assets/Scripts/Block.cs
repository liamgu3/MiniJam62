using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public float speed;

	private BlockSpawner blocksHolder;

    // Start is called before the first frame update
    void Start()
    {
		speed = 7.5f;

		blocksHolder = GameObject.Find("BlockSpawner").GetComponent<BlockSpawner>();
	}

    // Update is called once per frame
    void Update()
    {
		transform.Translate(-Vector2.up * speed * Time.deltaTime);

		if (transform.position.y < -25)
		{
			blocksHolder.removeBlock();
			Destroy(gameObject);
		}
    }

}
