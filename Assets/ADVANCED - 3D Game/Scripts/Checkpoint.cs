using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	public Material CheckpointMaterial;
	public MeshRenderer Renderer;
	public GamePlayer Player;

	private bool triggered;

	private void OnTriggerEnter(Collider other)
	{
		if (!triggered)
		{
			triggered = true;
			Renderer.material = CheckpointMaterial;
			Player.SetCheckpointPosition(transform.position);
			Invoke(nameof(ClearMaterial), 1f);
		}
	}

	private void ClearMaterial()
	{
		Renderer.enabled = false;
	}
}
