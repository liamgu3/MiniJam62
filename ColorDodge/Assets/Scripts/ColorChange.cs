using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorChange : MonoBehaviour
{
	private Color[] colors;
	private float changeTimer;

    // Start is called before the first frame update
    void Start()
    {
		colors = new Color[5];
		colors[0] = Color.blue;
		colors[1] = Color.green;
		colors[2] = Color.yellow;
		colors[3] = Color.magenta;
		colors[4] = Color.red;

		changeTimer = 1.5f;

		RandomHolder.rng = new System.Random();
	}

    // Update is called once per frame
    void Update()
    {
		changeTimer += Time.deltaTime;

		if (changeTimer > 1.0f)
		{
			GetComponent<SpriteRenderer>().color = colors[RandomHolder.rng.Next(5)];

			changeTimer = 0.0f;
		}
    }
}
