using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class stopWatch : MonoBehaviour
{
	private Text Text;
	public float startTime;
	public bool stopTime;
	
    // Start is called before the first frame update
    void Start()
    {
		Text = GetComponent<Text>();
		stopTime = false;

		startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		if (!stopTime)
		{
			stopWatchIncrement();
		}
    }

	private void stopWatchIncrement()
	{
		Text.text = "Time:\n" + String.Format("{0:0.00}", Time.time - startTime);
	}

	
}
