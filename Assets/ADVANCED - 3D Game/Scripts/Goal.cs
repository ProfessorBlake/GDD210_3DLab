using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	public ParticleSystem WinEffect;

	private void OnTriggerEnter(Collider other)
	{
		WinEffect.Emit(Random.Range(50, 60));
	}
}
