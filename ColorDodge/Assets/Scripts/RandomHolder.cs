using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomHolder : MonoBehaviour
{
	public static System.Random rng;

	// Start is called before the first frame update
	void Start()
    {
		rng = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
