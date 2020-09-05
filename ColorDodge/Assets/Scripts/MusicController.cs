using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

	private bool playerKilled;
	private AudioSource music;
	bool musicChanged;

    // Start is called before the first frame update
    void Start()
    {
		playerKilled = GameObject.Find("backWall").GetComponent<killPlayer>().playerKilled;
		music = GetComponent<AudioSource>();
		musicChanged = false;
		music.Play();
    }

    // Update is called once per frame
    void Update()
    {
		
	}

	public void PauseMusic()
	{
		music.Pause();
		Debug.Log("in here");
	}
}
