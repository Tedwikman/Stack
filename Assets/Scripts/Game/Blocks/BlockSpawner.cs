using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour 
{
	public static BlockSpawner Instance
	{ get { return _instance; } }
	private static BlockSpawner _instance = null;

	[SerializeField] private BlockObject blockPrefab;

	private void Awake()
	{
		_instance = this;
	}

	private void OnDestroy()
	{
		_instance = null;
	}

	public void SpawnBlockAt(Vector3 spawnPoint, float scaleFactor, int playerID)
	{
		BlockObject obj = Instantiate(this.blockPrefab, spawnPoint, Quaternion.identity) as BlockObject;
		obj.transform.localScale = Vector3.one * scaleFactor;
		obj.SetPlayerID(playerID);

		BlockManager.Instance.AddBlock(obj);

		MainMessenger.Instance.BlockPlaced();
	}
}
