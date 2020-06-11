using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform Target;
	public float MoveSpeed;

	private Vector3 startPostion;
	private Vector3 offset;

	private void Start()
	{
		startPostion = transform.position;
		offset = Target.position - transform.position;
	}

	private void Update()
	{
		Vector3 movePosition = Target.position - offset;
		movePosition.y = startPostion.y;
		transform.position = Vector3.Lerp(transform.position, movePosition, Time.deltaTime * MoveSpeed);
	}
}
