using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public static int collected;

	public bool isDead;

	private float posTrackX;
	private float posTrackY;
	public float moveDistance = 2.5f;
	private float moveLimit = 2.5f;

	private EnemyScript enemy;

	public UIController UI;
	public Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		enemy = Object.FindObjectOfType<EnemyScript>();
		isDead = false;
	}

	private void Update()
	{
		if (!isDead)
		{
			move();
		}
	}

	private void move()
	{
		base.transform.position = new Vector3(posTrackX, posTrackY, 0f);
		if (UI.fourByFour)
		{
			moveLimit = 5f;
		}
		else
		{
			moveLimit = 2.5f;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow) && posTrackY != moveLimit)
		{
			posTrackY += moveDistance;
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) && posTrackY != -2.5f)
		{
			posTrackY -= moveDistance;
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) && posTrackX != -2.5f)
		{
			posTrackX -= moveDistance;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) && posTrackX != moveLimit)
		{
			posTrackX += moveDistance;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			isDead = true;
		}
		else if (other.gameObject.tag == "Collect")
		{
			Object.Destroy(other.gameObject);
			overlayScript.score++;
		}
	}
}
