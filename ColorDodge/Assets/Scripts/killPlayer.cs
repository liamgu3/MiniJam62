using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
	private BlockSpawner blocksHolder;
	private GameObject colorChange;

	// Start is called before the first frame update
	void Start()
    {
		blocksHolder = GameObject.Find("BlockSpawner").GetComponent<BlockSpawner>();
		colorChange = GameObject.Find("Background");
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 8)        //checks if colliding object is player
		{
			Debug.Log("hit back wall");
			collision.gameObject.GetComponent<Collider2D>().enabled = false;
			collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
			for(int i = 0; i < blocksHolder.blockCount; i++)
			{
				blocksHolder.blocksHolder[i].GetComponent<Block>().enabled = false;
			}
			blocksHolder.enabled = false;
			for (int i = 0; i < colorChange.transform.childCount; i++)
			{
				colorChange.transform.GetChild(i).GetComponent<ColorChange>().stopChange = true;
			}
		}
	}

	//private void OnCollisionEnter2D(Collision2D collision)
	//{
	//	if (collision.gameObject.layer == 8)        //checks if colliding object is player
	//	{
	//		Debug.Log("hit back wall");
	//		collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
	//	}
	//}
}
