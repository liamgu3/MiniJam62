using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
	private BlockSpawner blocksHolder;
	private GameObject colorChange;
	private GameObject player;
	private GameObject player2;
	private GameObject timer;
	private GameObject highScore;
	private AudioSource deathSound;
	private GameObject camera1;
	public GameObject controls;

	public bool playerKilled;

	// Start is called before the first frame update
	void Start()
    {
		blocksHolder = GameObject.Find("BlockSpawner").GetComponent<BlockSpawner>();
		player = GameObject.Find("Player");
		timer = GameObject.Find("Timer");
		highScore = GameObject.Find("HighScore");
		deathSound = GetComponent<AudioSource>();
		camera1 = GameObject.Find("Main Camera");
		colorChange = GameObject.Find("Background");

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
			highScore.GetComponent<HighScore>().saveHighScore(Time.time - timer.GetComponent<stopWatch>().startTime);
			timer.GetComponent<stopWatch>().stopTime = true;
			if (playerKilled)
			{
				player2.GetComponent<Collider2D>().enabled = false;
				player2.GetComponent<PlayerMovement>().enabled = false;
				player2.GetComponent<Rigidbody2D>().freezeRotation = false;
				StartCoroutine(ScaleOverTime(2.0f, player2));    //shrinks
			}
			else
			{
				player.GetComponent<Collider2D>().enabled = false; 
				player.GetComponent<PlayerMovement>().enabled = false;
				player.GetComponent<Rigidbody2D>().freezeRotation = false;
				StartCoroutine(ScaleOverTime(2.0f, player));    //shrinks
			}
			playerKilled = true;
			camera1.GetComponent<MusicController>().PauseMusic();
			deathSound.Play();


			

			for(int i = 0; i < blocksHolder.blockCount; i++)
			{
				blocksHolder.blocksHolder[i].GetComponent<Block>().enabled = false;
			}
			blocksHolder.enabled = false;
			for (int i = 0; i < colorChange.transform.childCount; i++)
			{
				colorChange.transform.GetChild(i).GetComponent<ColorChange>().stopChange = true;
			}


			blocksHolder.enabled = false;
			timer.GetComponent<stopWatch>().enabled = false;
			highScore.GetComponent<HighScore>().enabled = false;
		}

		
	}

	IEnumerator ScaleOverTime(float time, GameObject player)
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
		controls.SetActive(true);
		if (highScore.GetComponent<HighScore>().higherScore)
		{
			highScore.GetComponent<HighScore>().HighScoreSound();
		}
	}

	public void AssignPlayer(GameObject player2)
	{
		this.player2 = player2;
	}
}
