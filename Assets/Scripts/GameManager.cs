using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	int score = 0;
	int bestScore = 0;

	bool gameOver = false;
	public bool gameStarted = false;

	Text scoreText;
	Text finalScoreText;
	GameObject gameOverPanel;
	GameObject startPanel;

	PipeSpawner pipeSpawner;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}
	}

	void Start()
	{
		Time.timeScale = 1;

		// Find UI safely (Unity 5 compatible)
		GameObject obj;

		obj = GameObject.Find("ScoreText");
		if (obj != null)
			scoreText = obj.GetComponent<Text>();

		obj = GameObject.Find("FinalScoreText");
		if (obj != null)
			finalScoreText = obj.GetComponent<Text>();

		gameOverPanel = GameObject.Find("GameOverPanel");
		startPanel = GameObject.Find("StartPanel");

		pipeSpawner = FindObjectOfType<PipeSpawner>();

		bestScore = PlayerPrefs.GetInt("BestScore", 0);

		if (scoreText != null)
			scoreText.text = "0";

		if (gameOverPanel != null)
			gameOverPanel.SetActive(false);

		if (startPanel != null)
			startPanel.SetActive(true);

		if (pipeSpawner != null)
			pipeSpawner.enabled = false;
	}

	public void StartGame()
	{
		if (gameStarted) return;

		gameStarted = true;

		if (startPanel != null)
			startPanel.SetActive(false);

		if (pipeSpawner != null)
			pipeSpawner.enabled = true;
	}

	public void AddScore()
	{
		if (gameOver || !gameStarted) return;

		score++;

		if (scoreText != null)
			scoreText.text = score.ToString();
	}

	public void GameOver()
	{
		if (gameOver) return;
		gameOver = true;

		if (pipeSpawner != null)
			pipeSpawner.enabled = false;

		if (score > bestScore)
		{
			bestScore = score;
			PlayerPrefs.SetInt("BestScore", bestScore);
		}

		if (finalScoreText != null)
			finalScoreText.text = score.ToString();

		if (gameOverPanel != null)
			gameOverPanel.SetActive(true);

		Time.timeScale = 0;
	}

	public void RestartGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
