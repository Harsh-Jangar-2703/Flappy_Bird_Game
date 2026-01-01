using UnityEngine;

public class BirdController : MonoBehaviour
{
	public float jumpForce = 5f;

	Rigidbody2D rb;
	bool isAlive = true;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.simulated = false;   // physics OFF at start
	}

	void Update()
	{
		if (!isAlive) return;

		if (Input.GetMouseButtonDown(0))
		{
			if (!GameManager.instance.gameStarted)
			{
				GameManager.instance.StartGame();
				rb.simulated = true; // enable physics
			}

			rb.velocity = Vector2.zero;
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (!isAlive) return;

		isAlive = false;
		GameManager.instance.GameOver();
	}
}
