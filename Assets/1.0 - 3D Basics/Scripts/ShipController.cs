using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
	public float MoveSpeed = 10f;

	private void Update()
	{
		//Move direction will be along X and Z axis in this case.
		Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

		transform.position += (moveInput * MoveSpeed * Time.deltaTime);
	}
}
