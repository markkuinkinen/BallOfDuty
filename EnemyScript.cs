using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public static float moveSpeed = 4f;

	public int lives = 2;
	public Rigidbody2D enemyRb;

	private PlayerController player;

	private void Start()
	{
		enemyRb = GetComponent<Rigidbody2D>();
		player = Object.FindObjectOfType<PlayerController>();
	}

	private void Update()
	{
		if (!player.isDead)
		{
			if (lives > 0)
			{
				move();
				return;
			}
			if (UIController.collectBall)
			{
				player.isDead = true;
			}
			Object.Destroy(base.gameObject);
		}
		else
		{
			Object.Destroy(base.gameObject);
			moveSpeed = 4f;
		}
	}

	private void move()
	{
		if (base.transform.position.x < -7.9f)
		{
			enemyRb.velocity = new Vector2(moveSpeed, 0f);
		}
		else if (base.transform.position.x > 10f)
		{
			enemyRb.velocity = new Vector2(0f - moveSpeed, 0f);
		}
		else if (base.transform.position.y > 9.9f)
		{
			enemyRb.velocity = new Vector2(0f, 0f - moveSpeed);
		}
		else if (base.transform.position.y < -8.2f)
		{
			enemyRb.velocity = new Vector2(0f, moveSpeed);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Destroyer")
		{
			lives--;
		}
	}
}