using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
	public GameObject blockPrefab;

	private Block[,] blocksHolder;

	Color[] colors;
	Color color;

	Vector2[] positions;
	Vector2 position;

	float spawnTimer;

	// Start is called before the first frame update
	void Start()
    {
		blocksHolder = new Block[5,3];

		colors = new Color[5];
		colors[0] = Color.blue;
		colors[1] = Color.green;
		colors[2] = Color.yellow;
		colors[3] = Color.magenta;
		colors[4] = Color.red;

		positions = new Vector2[5];
		positions[0] = new Vector2(-6, 13.25f);
		positions[1] = new Vector2(-3, 13.25f);
		positions[2] = new Vector2(0, 13.25f);
		positions[3] = new Vector2(3, 13.25f);
		positions[4] = new Vector2(6, 13.25f);

		spawnTimer = 0.0f;
	}

    // Update is called once per frame
    void Update()
    {
		spawnTimer += Time.deltaTime;

		if (spawnTimer > 1.0f)
		{
			color = colors[RandomHolder.rng.Next(5)];
			position = positions[RandomHolder.rng.Next(5)];
			CreateBlock();

			spawnTimer = 0.0f;
			Debug.Log("Spawn");
		}
    }

	protected void CreateBlock()
	{
		Instantiate(blockPrefab, position, color);
	}

	public static Object Instantiate(GameObject prefab, Vector2 position, Color color)
	{
		GameObject block = Object.Instantiate(prefab) as GameObject;
		block.transform.position = position;
		block.GetComponent<SpriteRenderer>().color = color;
		return block;
	}
}
