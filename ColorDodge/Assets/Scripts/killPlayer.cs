using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
	private BlockSpawner blocksHolder;
	private GameObject colorChange;
	private GameObject player;
	private GameObject timer;
	private GameObject highScore;
	private AudioSource deathSound;
	private GameObject camera;

	public bool playerKilled;

	// Start is called before the first frame update
	void Start()
    {
		blocksHolder = GameObject.Find("BlockSpawner").GetComponent<BlockSpawner>();
		colorChange = GameObject.Find("Background");
		player = GameObject.Find("Player");
		timer = GameObject.Find("Timer");
		highScore = GameObject.Find("HighScore");
		deathSound = GetComponent<AudioSource>();
		camera = GameObject.Find("Main Camera");

		playerKilled = false;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 8)        //checks if colliding object is player
		{
			timer.GetComponent<stopWatch>().stopTime = true;
			highScore.GetComponent<HighScore>().saveHighScore(Time.time - timer.GetComponent<stopWatch>().startTime);
			playerKilled = true;
			camera.GetComponent<MusicController>().PauseMusic();
			deathSound.Play();


			player.GetComponent<Collider2D>().enabled = false;
			player.GetComponent<PlayerMovement>().enabled = false;
			player.GetComponent<Rigidbody2D>().freezeRotation = false;

			for(int i = 0; i < blocksHolder.blockCount; i++)
			{
				blocksHolder.blocksHolder[i].GetComponent<Block>().enabled = false;
			}
			blocksHolder.enabled = false;
			for (int i = 0; i < colorChange.transform.childCount; i++)
			{
				colorChange.transform.GetChild(i).GetComponent<ColorChange>().stopChange = true;
			}

			StartCoroutine(ScaleOverTime(2.0f));    //shrinks
		}

		
	}

	IEnumerator ScaleOverTime(float time)
	{
		Vector3 originalScale = player.transform.localScale;
		Vector3 destinationScale = new Vector3(0.01f, 0.01f, 0.01f);

		float currentTime = 0.0f;

		do
		{
			player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			player.transform.Rotate(Vector3.forward, 5.0f);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);

		Destroy(player);
	}
}
