using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public TuretBall BallPrefab;
	public float Range = 5f;
	public Transform Player;
	public Transform LaunchPoint;
	public float LaunchDelayReset = 1f;

	private float launchDelay = 0f;

	private void Update()
	{
		launchDelay -= Time.deltaTime;

		float dist = Vector3.Distance(transform.position, Player.position);
		if (dist <= Range)
		{
			LaunchPoint.parent.LookAt(Player);
			if (launchDelay <= 0f)
			{
				TuretBall ball = Instantiate(BallPrefab, LaunchPoint.position, Quaternion.identity);
				ball.Launch(LaunchPoint.parent.forward, dist);
				launchDelay = LaunchDelayReset;
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position, Range);
	}
}
