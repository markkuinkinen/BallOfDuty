using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	public PlayerController player;
	public InstantiateEnemies spawner;

	public bool fourByFour;

	public static bool dodgeBall;
	public static bool collectBall;
	public static bool dcBall;

	private void Start()
	{
		player = Object.FindObjectOfType<PlayerController>();
	}

	private void Update()
	{
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("4x4"))
		{
			fourByFour = true;
		}
		else
		{
			fourByFour = false;
		}
	}

	public void LoadLevel(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void exitGame()
	{
		Application.Quit();
	}

	public void startDodgeball()
	{
		collectBall = false;
		dcBall = false;
		dodgeBall = true;
	}

	public void startCollectBall()
	{
		dodgeBall = false;
		dcBall = false;
		collectBall = true;
	}

	public void startDcBall()
	{
		dodgeBall = false;
		collectBall = false;
		dcBall = true;
	}
}
