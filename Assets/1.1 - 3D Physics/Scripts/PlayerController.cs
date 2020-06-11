using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float WalkSpeed = 1f;
	public Rigidbody RB;

	private Vector3 startPosition;
	private bool canMove = false;

	private void Start()
	{
		startPosition = transform.position;
	}

	private void Update()
	{
		//Reset if we fall off.
		if(transform.position.y < -10f)
		{
			transform.position = startPosition;
			RB.velocity = Vector3.zero;
			RB.angularVelocity = Vector3.zero;
			canMove = false;
		}
	}

	private void FixedUpdate()
	{
		//Prevent player from moving until they land.
		if (canMove == false)
			return;

		//Move direction will be along X and Z axis.
		Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

		RB.AddForce(moveInput * WalkSpeed);
	}

	private void OnTriggerEnter(Collider other)
	{
		//Allow player to move after they hit the trigger.
		EnableMovementTrigger trigger = other.GetComponent<EnableMovementTrigger>();
		if(trigger != null)
		{
			canMove = true;
			return;
		}

		//Pick up coins if they touch one.
		Coin coin = other.GetComponent<Coin>();
		if(coin != null)
		{
			Destroy(other.gameObject);
		}
	}
}
