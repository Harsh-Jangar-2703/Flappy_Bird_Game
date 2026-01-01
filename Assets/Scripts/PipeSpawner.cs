using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
	public GameObject pipePrefab;

	public float spawnRate = 2f;
	public float minY = -1.5f;
	public float maxY = 1.5f;

	float timer;

	void Update()
	{
		if (!GameManager.instance.gameStarted) return;

		timer += Time.deltaTime;

		if (timer >= spawnRate)
		{
			SpawnPipe();
			timer = 0f;
		}
	}

	void SpawnPipe()
	{
		float y = Random.Range(minY, maxY);
		Vector3 pos = new Vector3(transform.position.x, y, 0f);
		Instantiate(pipePrefab, pos, Quaternion.identity);
	}
}
