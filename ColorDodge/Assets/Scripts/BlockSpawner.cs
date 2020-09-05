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

		spawnTimer = 0.0f;
		difficultyTimer = 0.0f;
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
		addBlock(Instantiate(blockPrefab, position, color));
	}

	public static GameObject Instantiate(GameObject prefab, Vector2 position, Color32 color)
	{
		GameObject block = Object.Instantiate(prefab) as GameObject;
		block.transform.position = position;

		Renderer renderer1 = block.GetComponent<Renderer>();
		renderer1.material.color = color;

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
}
