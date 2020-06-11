using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	private float spinSpeed = 50f;

	private void Start()
	{
		transform.eulerAngles = new Vector3(0f, Random.Range(0f,360f), 0f);
	}

	private void Update()
	{
		transform.eulerAngles += new Vector3(0f, spinSpeed * Time.deltaTime, 0f);
	}
}
