using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverlayScript : MonoBehaviour
{
	public static int score;
	public static int timer;

	public Text scoreText;
	public Text timerText;
	public Text deathRecapScore;

	public Button replayButton;
	public Button menuButton;

	public SpriteRenderer blackBG;
	private PlayerController player;

	private void Start()
	{
		player = Object.FindObjectOfType<PlayerController>();
		StartCoroutine("gameTimer");
		deathRecapScore.enabled = false;
		blackBG.enabled = false;
	}

	private IEnumerator gameTimer()
	{
		while (!player.isDead)
		{
			yield return new WaitForSeconds(1f);
			timer++;
		}
	}

	private void Update()
	{
		if (UIController.collectBall || UIController.dcBall)
		{
			scoreText.text = "Score: " + score;
		}
		else
		{
			timerText.text = "Time: " + timer;
		}
		if (player.isDead)
		{
			blackBG.enabled = true;
			scoreText.enabled = false;
			timerText.enabled = false;
			replayButton.gameObject.SetActive(value: true);
			menuButton.gameObject.SetActive(value: true);
			deathRecapScore.enabled = true;
			if (UIController.dodgeBall)
			{
				deathRecapScore.text = "Nice!\nYou survived for " + timer + " seconds!";
			}
			else if (UIController.collectBall)
			{
				deathRecapScore.text = "Nice!\nYou got a score of " + score + "!";
			}
			else if (UIController.dcBall)
			{
				deathRecapScore.text = "Nice!\nYou survived for " + timer + " seconds\nand got a score of " + score + "!";
			}
		}
		else
		{
			replayButton.gameObject.SetActive(value: false);
			menuButton.gameObject.SetActive(value: false);
		}
	}

	public void replayLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		player.isDead = false;
		timer = 0;
		score = 0;
	}

	public void returnToMenu()
	{
		timer = 0;
		score = 0;
		SceneManager.LoadScene("Menu");
	}
}