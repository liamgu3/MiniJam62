using System;
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
	private bool hasUpdated;
	private string scoreString;
    // Start is called before the first frame update
    void Start()
    {
		hasUpdated = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (!hasUpdated)
		{
			loadHighScore();
			hasUpdated = true;
		}
    }

	public void saveHighScore(float score)
	{
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
			scoreString = input.ReadLine();
			highScore.text = "High Score:\n" + scoreString;
			scoreHigh = float.Parse(scoreString);
			input.Close();
		}
		catch
		{
			Console.WriteLine("There was an error loading data.");
		}
	}

	private void OnEnable()
	{
		highScore = GetComponent<Text>();
		timer = GameObject.Find("Timer").GetComponent<stopWatch>();

		loadHighScore();
	}
}
