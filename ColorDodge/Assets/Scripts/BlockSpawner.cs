using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
	public GameObject blockPrefab;

	public GameObject[] blocksHolder;
	public int blockCount;

	Color32[] colors;
	Color32 color;

	Vector2[] positions;
	Vector2 position;
	private int num;

	private float spawnTimer;
	private float difficultyTimer;

	// Start is called before the first frame update
	void Start()
    {
		blocksHolder = new GameObject[50];
		blockCount = 0;

		colors = new Color32[5];
		colors[0] = new Color32(148, 0, 211, 255);
		colors[1] = new Color32(0, 0, 255, 255);
		colors[2] = new Color32(0, 255, 0, 255);
		colors[3] = new Color32(255, 255, 0, 255);
		colors[4] = new Color32(255, 127, 0, 255);

		positions = new Vector2[5];
		positions[0] = new Vector2(-6, 11.75f);
		positions[1] = new Vector2(-3, 11.75f);
		positions[2] = new Vector2(0, 11.75f);
		positions[3] = new Vector2(3, 11.75f);
		positions[4] = new Vector2(6, 11.75f);

		spawnTimer = 1.0f;
		difficultyTimer = 0.0f;
	}

    // Update is called once per frame
    void Update()
    {
		spawnTimer += Time.deltaTime;
		difficultyTimer += Time.deltaTime;

		if (difficultyTimer < 15.0f)    //difficulty level 1
		{
			if (spawnTimer > 1.0f)
			{
				color = colors[RandomHolder.rng.Next(5)];
				position = positions[RandomHolder.rng.Next(5)];
				CreateBlock(10.0f);

				spawnTimer = 0.0f;
			}
		}
		else if (difficultyTimer < 30.0f)   //difficult level 2
		{
			if (spawnTimer > .66f)
			{
				color = colors[RandomHolder.rng.Next(5)];
				position = positions[RandomHolder.rng.Next(5)];
				CreateBlock(15.0f);

				spawnTimer = 0.0f;
			}
		}
		else if (difficultyTimer < 45.0f)   //difficulty level 3
		{
			if (spawnTimer > .66f)
			{
				num = RandomHolder.rng.Next(5);

				color = colors[RandomHolder.rng.Next(5)];   //first block
				position = positions[num];
				CreateBlock(15.0f);

				TwoBlockPosition();
				CreateBlock(15.0f);
				blocksHolder[blockCount - 1].transform.position = new Vector2(blocksHolder[blockCount - 1].transform.position.x, blocksHolder[blockCount - 2].transform.position.y);	//sets blocks to same y position

				spawnTimer = 0.0f;
			}
		}
		else if (difficultyTimer < 60.0f)	//difficulty level 4
		{
			if (spawnTimer > .33f)
			{
				num = RandomHolder.rng.Next(5);

				color = colors[RandomHolder.rng.Next(5)];   //first block
				position = positions[num];
				CreateBlock(15.0f);

				TwoBlockPosition();
				CreateBlock(15.0f);

				spawnTimer = 0.0f;
			}
		}
    }

	protected void CreateBlock(float speed)
	{
		addBlock(Instantiate(blockPrefab, position, color, speed));
	}

	public static GameObject Instantiate(GameObject prefab, Vector2 position, Color32 color, float speed)
	{
		GameObject block = Instantiate(prefab) as GameObject;
		block.transform.position = position;

		Renderer renderer1 = block.GetComponent<Renderer>();
		renderer1.material.color = color;

		block.GetComponent<Block>().speed = speed;

		return block;
	}

	protected void addBlock(GameObject block)
	{
		blocksHolder[blockCount] = block;
		blockCount++;
	}

	public void removeBlock()
	{
		blocksHolder[0] = null;
		for (int i = 0; i < blockCount; i++)
		{
			blocksHolder[i] = blocksHolder[i + 1];
		}
		blockCount--;
	}

	/// <summary>
	/// assigns position of second block in pair
	/// </summary>
	private void TwoBlockPosition()
	{
		if (num == 0)
		{
			position = positions[1];
		}
		else if (num == 4)
		{
			position = positions[3];
		}
		else
		{
			if (RandomHolder.rng.Next(2) == 1)
			{
				position = positions[num + 1];
			}
			else
			{
				position = positions[num - 1];
			}
		}
	}
}
