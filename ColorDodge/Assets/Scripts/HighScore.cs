﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
	private Text highScore;
	private stopWatch timer;

	public float scoreHigh;

    // Start is called before the first frame update
    void Start()
    {
        highScore = GetComponent<Text>();
		timer = GameObject.Find("Timer").GetComponent<stopWatch>();

		loadHighScore();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void saveHighScore(float score)
	{
		Debug.Log(score);
		Debug.Log(scoreHigh);
		if (score > scoreHigh)
		{
			try
			{
				StreamWriter output = new StreamWriter("HighScore.txt");
				output.WriteLine(String.Format("{0:0.00}", Time.time - timer.startTime));
				output.Close();
			}
			catch
			{
				Debug.Log("Error saving score");
			}
		}
	}

	protected void loadHighScore()
	{
		try
		{
			StreamReader input = new StreamReader("HighScore.txt");
			scoreHigh = float.Parse(input.ReadLine());
			highScore.text = "High Score:\n" + scoreHigh;
			input.Close();
		}
		catch
		{
			Console.WriteLine("There was an error loading data.");
		}
	}
}