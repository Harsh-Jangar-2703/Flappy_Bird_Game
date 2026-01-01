using UnityEngine;

public class PipeMove : MonoBehaviour
{
	public float speed = 2f;

	void Update()
	{
		if (GameManager.instance == null) return;
		if (!GameManager.instance.gameStarted) return;

		transform.Translate(Vector3.left * speed * Time.deltaTime);

		if (transform.position.x < -10f)
		{
			Destroy(gameObject);
		}
	}
}
