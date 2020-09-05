using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorChange : MonoBehaviour
{
	private Color32[] colors;
	private float changeTimer;

	private Renderer renderer1;
	public bool stopChange;

    // Start is called before the first frame update
    void Start()
    {
		colors = new Color32[5];
		colors[0] = new Color32(255, 0, 255, 255);	//purple
		colors[1] = new Color32(0, 0, 255, 255);	//blue
		colors[2] = new Color32(0, 255, 0, 255);	//gree
		colors[3] = new Color32(255, 255, 0, 255);	//yellow
		colors[4] = new Color32(255, 127, 0, 255);	//orange

		changeTimer = 1.5f;

		RandomHolder.rng = new System.Random();

		renderer1 = gameObject.GetComponent<Renderer>();

		stopChange = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (!stopChange)
		{
			changeTimer += Time.deltaTime;
		}

		if (changeTimer > .3f)
		{
			renderer1.material.color = colors[RandomHolder.rng.Next(5)];

			changeTimer = 0.0f;
		}
    }
}
