using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayer : MonoBehaviour
{
	public float MoveSpeed;
	public float JumpSpeed;
	public Rigidbody RB;
	public TMP_Text ScoreText;

	private bool onGround;
	private Vector3 startPosition;
	private int coins;

	private void Start()
	{
		startPosition = transform.position;
	}

	private void Update()
	{
		if(onGround && Input.GetKeyDown(KeyCode.Space))
		{
			RB.AddForce(new Vector3(0f, JumpSpeed, 0f));
			onGround = false;
		}

		if(transform.position.y < -10f)
		{
			RB.position = startPosition;
			RB.velocity = Vector3.zero;
			RB.angularVelocity = Vector3.zero;
		}
	}

	private void FixedUpdate()
	{
		Vector3 moveInput = new Vector3(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"));
		RB.AddForce(moveInput * MoveSpeed);
	}

	private void OnTriggerEnter(Collider other)
	{
		Coin coin = other.GetComponent<Coin>();
		if(coin != null)
		{
			coins++;
			ScoreText.text = "Coins:" + coins.ToString().PadLeft(3,'0');
			Destroy(other.gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		//Touched ground
		if(RB.velocity.y <= 0f && collision.collider.CompareTag("Ground") && collision.GetContact(0).point.y < transform.position.y)
		{
			onGround = true;
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		//Touched ground
		if (RB.velocity.y <= 0f && collision.collider.CompareTag("Ground") && collision.GetContact(0).point.y < transform.position.y)
		{
			onGround = true;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		//Left ground
		if (collision.collider.CompareTag("Ground"))
		{
			onGround = false;
		}
	}

	public void SetCheckpointPosition(Vector3 position)
	{
		startPosition = position;
	}
}
