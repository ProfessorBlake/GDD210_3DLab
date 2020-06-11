using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuretBall : MonoBehaviour
{
	public Rigidbody RB;

	public void Launch(Vector3 direction, float distance)
	{
		RB.velocity = (direction + new Vector3(Random.Range(-0.05f,0.05f),(distance * 0.04f), Random.Range(-0.05f, 0.05f))) * 9f;
	}

	private void FixedUpdate()
	{
		if (transform.position.y < -10f)
			Destroy(gameObject);
	}
}
