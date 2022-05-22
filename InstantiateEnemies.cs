using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
	public int spawnCounter;

	public GameObject enemy;
	public GameObject collect;
	public PlayerController player;
	public UIController UI;

	public int spawnLimit = 11;
	public int randomNumber = -1;

	public float spawnInterval = 1f;
	public float spawnTime = 1f;

	private int dc = -1;

	public Transform[] enemySpawnPos = new Transform[15];

	private void Start()
	{
		StartCoroutine("spawnRoutine");
	}

	private void Update()
	{
		if (UI.fourByFour)
		{
			spawnLimit = 16;
		}
		if (player.isDead)
		{
			spawnCounter = 0;
			StopCoroutine("spawnRoutine");
		}
	}

	private IEnumerator spawnRoutine()
	{
		while (!player.isDead)
		{
			yield return new WaitForSeconds(100f / ((float)spawnCounter + 100f));
			randomNumber = Random.Range(0, spawnLimit);
			newSpawner();
			updateSpawner();
			spawnCounter++;
		}
	}

	private void updateSpawner()
	{
		if (spawnCounter % 5 == 0)
		{
			EnemyScript.moveSpeed += 1f;
		}
	}

	private void newSpawner()
	{
		if (UIController.dodgeBall)
		{
			Object.Instantiate(enemy, enemySpawnPos[randomNumber].position, enemySpawnPos[randomNumber].rotation);
		}
		else if (UIController.collectBall)
		{
			Object.Instantiate(collect, enemySpawnPos[randomNumber].position, enemySpawnPos[randomNumber].rotation);
		}
		else if (UIController.dcBall)
		{
			dc = Random.Range(0, 2);
			if (dc == 0)
			{
				Object.Instantiate(enemy, enemySpawnPos[randomNumber].position, enemySpawnPos[randomNumber].rotation);
			}
			else if (dc == 1)
			{
				Object.Instantiate(collect, enemySpawnPos[randomNumber].position, enemySpawnPos[randomNumber].rotation);
			}
		}
	}
}