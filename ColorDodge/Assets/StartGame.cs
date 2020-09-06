using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
	public GameObject camera1;
	public GameObject blockSpawner;
	public GameObject stopWatch;
	public GameObject highScore;
	public GameObject playerMovement;
	private GameObject firstPlayer;
	private GameObject colorChange;
	private GameObject player2;
	private killPlayer killPlayer;
	public GameObject controls;

	private bool firstPlay;

    // Start is called before the first frame update
    void Start()
    {
		firstPlayer = GameObject.Find("Player");
		firstPlay = true;

		colorChange = GameObject.Find("Background");
		killPlayer = GameObject.Find("backWall").GetComponent<killPlayer>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ButtonClicked()
	{
		blockSpawner.GetComponent<BlockSpawner>().enabled = true;
		stopWatch.GetComponent<stopWatch>().enabled = true;
		highScore.GetComponent<HighScore>().enabled = true;
		if (firstPlay == true)
		{
			firstPlay = false;
			firstPlayer.GetComponent<PlayerMovement>().enabled = true;
			firstPlayer.GetComponent<Collider2D>().enabled = true;
			firstPlayer.GetComponent<Rigidbody2D>().freezeRotation = true;
		}
		else
		{
			player2 = Instantiate(playerMovement);
			killPlayer.AssignPlayer(player2);
			playerMovement.GetComponent<PlayerMovement>().enabled = true;
			playerMovement.GetComponent<Collider2D>().enabled = true;
			playerMovement.GetComponent<Rigidbody2D>().freezeRotation = true;

			camera1.GetComponent<MusicController>().PlayMusic();
		}
		playerMovement.transform.position = Vector3.zero;

		for (int i = 0; i < colorChange.transform.childCount; i++)
		{
			colorChange.transform.GetChild(i).GetComponent<ColorChange>().stopChange = false;
		}

		controls.SetActive(false);
	}
}
